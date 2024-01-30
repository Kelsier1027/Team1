using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Team1.InterFace.IRepositories.Admin;
using Team1.InterFace.admin;
using Team1.Models.EFModels;
using Team1.Models.Exts.Admin;
using Team1.Models.Repositories.Admins;
using Team1.Models.ViewModels.Admin;
using Team1.Services.Admin;

namespace Team1.Controllers
{
	public class BEAdminsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		private IAdminRepository _repo = new AdminEFRepository();
		private AdminService _service;
		public BEAdminsController()
		{
			_service = new AdminService(_repo);
		}

		// GET: BEAdmins
		public ActionResult Index()
		{
			return View(db.BEAdmins.ToList());
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(AdminLoginVm vm)
		{
			if (!ModelState.IsValid) // 如果欄位驗證失敗, 就回到 lgoin page
			{
				return View(vm);
			}

			try
			{
				ValidLogin(vm); // 驗證帳密是否ok,且是有效的會員
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}

			var processResult = ProcessLogin(vm); // 將相關資訊(如帳號)準備好並回傳

			Response.Cookies.Add(processResult.Cookie); // 將回傳的 cookie 加到Browser

			return Redirect(processResult.ReturnUrl); // 轉向到它原本應該要去的網址
		}

		private (string ReturnUrl, HttpCookie Cookie) ProcessLogin(AdminLoginVm vm) // value tuple 元組
		{
			var readminMe = false; // 如果LoginVm有ReadminMe屬性, 記得要設定
			var account = vm.Account;
			var roles = string.Empty; // 在本範例, 沒有用到角色權限,所以存入空白

			// 建立一張認證票
			var ticket =
				new FormsAuthenticationTicket(
					1,          // 版本別, 沒特別用處
					account,
					DateTime.Now,   // 發行日
					DateTime.Now.AddDays(1), // 到期日
					readminMe,     // 是否續存
					roles,          // userdata
					"/" // cookie位置
				);

			// 將它加密
			var value = FormsAuthentication.Encrypt(ticket);

			// 存入cookie
			var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			// 取得return url
			var url = FormsAuthentication.GetRedirectUrl(account, true); //第二個引數沒有用處

			return (url, cookie);

		}

		private void ValidLogin(AdminLoginVm vm)
		{
			var db = new AppDbContext();

			// 根據account(帳號)取得 admin
			var admin = db.admins.FirstOrDefault(p => p.Account == vm.Account);
			if (admin == null)
			{
				throw new Exception("帳號或密碼有誤");// 原則上, 不要告知細節
			}

			// 檢查是否已經確認
			if (admin.IsConfirmed == false)
			{
				throw new Exception("您尚未開通會員資格, 請先收確認信, 並點選信裡的連結, 完成認證, 才能登入本網站");
			}

			// 將vm裡的密碼先雜湊之後,再與db裡的密碼比對
			var salt = HashUtility.GetSalt();
			var hashedPassword = HashUtility.ToSHA256(vm.Password, salt);

			if (string.Compare(admin.EncryptedPassword, hashedPassword, true) != 0)
			{
				throw new Exception("帳號或密碼有誤");
			}
		}

		// GET: BEAdmins/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BEAdmins/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateAdminVm vm)
		{
			if (ModelState.IsValid)
			{
				vm.ToDto();
				try
				{
					int newAdminId = _service.Create(vm.ToDto());
					TempData["CreateSuccess"] = true; // 設置標記 ， 用於判斷是否顯示成功提示
					TempData["NewAdminId"] = newAdminId; // 內跳轉到成功提示頁面時，需要用到的參數
					return RedirectToAction("CreateSuccess");
				}
				catch (Exception ex)
				{
					// 在頁面中顯示錯誤訊息
					var errorMessage = ex.Message;
					ViewBag.ErrorMessage = errorMessage;
					return View(vm);
				}
			}
			else
			{
				return View(vm);
			}
		}

		[HttpGet]
		public ActionResult CreateSuccess()
		{
			if (TempData["CreateSuccess"] == null)
			{
				return RedirectToAction("Index", "Home"); // 將非法訪問導向到首頁
			}
			// 取得剛剛創建的新管理員的Id
			int newAdminId = 0; // 預設為 0

			// 判斷 TempData["NewAdminId"] 是否為 null 且能否轉換為 int
			if (TempData["NewAdminId"] != null && int.TryParse(TempData["NewAdminId"].ToString(), out int parsedValue))
			{
				newAdminId = parsedValue; // 轉換成功，賦值給 newAdminId
				NewAdminVm admin = _service.GetById(newAdminId).ToNewAdminVm();
				return View(admin); // 將新管理員的資料傳遞到前端
			}
			else
			{
				// 在頁面中顯示錯誤訊息
				ViewBag.ErrorMessage = "無法取得新管理員的資料，管理員創建失敗，請重新創建";
				return View();
			}
		}

		// GET: BEAdmins/ConfirmEmail?adminId={0}&verificationCode={1}
		public ActionResult ConfirmEmail(int adminId,string verificationCode)
		{
			// 驗證傳入值是否合理
			if (adminId <= 0 || string.IsNullOrEmpty(verificationCode))
			{
				return View(); // 在view中,我們會顯示'已開通,謝謝'
			}

			// 根據 adminId, confirmCode 取得 未確認的 admin
			BEAdmin admin = GetEmailUnConfirmedAdmin(adminId, verificationCode);
			if (admin == null) return View();

			// 如果有找到, 將它更新為已確認
			ConfirmEmail(adminId);
			return View();
		}

		// 透過 AdminId, verificationCode 取得Email未確認的管理員
		private BEAdmin GetEmailUnConfirmedAdmin(int adminId, string verificationCode)
		{
			return new AppDbContext().BEAdmins.FirstOrDefault(a => a.Id == adminId && a.IsEmailConfirmed == false && a.VerificationCode == verificationCode);
		}

		// 將管理員的的 IsEmailConfirmed 設為 true，同時清空 VerificationCode
		private void ConfirmEmail(int adminId)
		{
			var db = new AppDbContext();
			var admin = db.BEAdmins.Find(adminId); //一定能找到,所以不必防呆沒關係
			admin.IsEmailConfirmed = true; // 視為已確認的會員
			admin.VerificationCode = null; // 清空 confirm code 欄位

			db.SaveChanges();
		}

		// GET: BEAdmins/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BEAdmin bEAdmin = db.BEAdmins.Find(id);
			if (bEAdmin == null)
			{
				return HttpNotFound();
			}
			return View(bEAdmin);
		}

		// POST: BEAdmins/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Account,EncryptedPassword,Email,Name,RegistrationDate,ActiveStatus,Salt")] BEAdmin bEAdmin)
		{
			if (ModelState.IsValid)
			{
				db.Entry(bEAdmin).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(bEAdmin);
		}

		// GET: BEAdmins/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BEAdmin bEAdmin = db.BEAdmins.Find(id);
			if (bEAdmin == null)
			{
				return HttpNotFound();
			}
			return View(bEAdmin);
		}

		// GET: BEAdmins/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BEAdmin bEAdmin = db.BEAdmins.Find(id);
			if (bEAdmin == null)
			{
				return HttpNotFound();
			}
			return View(bEAdmin);
		}

		// POST: BEAdmins/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			BEAdmin bEAdmin = db.BEAdmins.Find(id);
			db.BEAdmins.Remove(bEAdmin);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
