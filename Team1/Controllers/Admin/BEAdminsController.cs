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
using Team1.Filters;
using Team1.InterFace.IRepositories.Admin;
using Team1.Models.EFModels;
using Team1.Models.Exts.Admin;
using Team1.Models.Infra;
using Team1.Models.Repositories.Admins;
using Team1.Models.ViewModels.Admin;
using Team1.Services.Admin;
using Team1.ViewModels.Admin;

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
		[CustomAuthorize(Roles = "SystemAdmin")]
		public ActionResult Index()
		{
			return View(db.BEAdmins.ToList());
		}
		
		public ActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ForgetPassword(AdminForgetPasswordVm vm)
		{
			if (!ModelState.IsValid) return View(vm);

			var urlTemplate = Request.Url.Scheme + "://" +  // 生成 http:.// 或 https://
							  Request.Url.Authority + "/" + // 生成網域名稱或 ip
							  "BEAdmins/ResetPassword?adminId={0}&confirmCode={1}"; // 生成網頁 url
			try
			{
				ProcessResetPassword(vm.Account, vm.Email, urlTemplate);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}
			return View("ForgetPasswordConfirm");
		}

		/// <summary>
		/// 重設密碼, 使用者經由信件裡的超連結而來,並不是在網站裡提供本網址
		/// </summary>
		/// <param name="adminId"></param>
		/// <param name="confirmCode"></param>
		/// <returns></returns>
		public ActionResult ResetPassword(int AdminId, string verificationCode)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ResetPassword(int AdminId, string verificationCode, AdminResetPasswordVM vm)
		{
			// 檢查 vm 是否通過驗證
			if (!ModelState.IsValid) return View(vm);
			try
			{
				ProcessResetPassword(AdminId, verificationCode, vm);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}
			// 顯示重設密碼成功畫面
			return View("AdminConfirmResetPassword");
		}

		/// <summary>
		/// 基於安全考量, 若 adminId, confirmCode有錯, 都不會顯示錯誤訊息, 只會顯示重設密碼畫面
		/// </summary>
		/// <param name="adminId"></param>
		/// <param name="confirmCode"></param>
		/// <param name="vm"></param>
		private void ProcessResetPassword(int adminId, string verificationCode, AdminResetPasswordVM vm)
		{
			var db = new AppDbContext();
			// 檢查 adminId, confirmCode 是否正確
			var adminInDb = db.BEAdmins.FirstOrDefault(m => m.Id == adminId &&
														m.IsEmailConfirmed == true &&
														m.VerificationCode == verificationCode);
			if (adminInDb == null) return; // 不動聲色的離開

			// 重設密碼 使用 bcrypt 雜湊
			var salt = BCrypt.Net.BCrypt.GenerateSalt(11);
			var hashedPassword = BCrypt.Net.BCrypt.HashPassword(vm.Password, salt);

			adminInDb.EncryptedPassword = hashedPassword;
			adminInDb.VerificationCode = null;
			db.SaveChanges();
		}


		private void ProcessResetPassword(string account, string email, string urlTemplate)
		{
			var db = new AppDbContext();
			// 檢查account,email正確性
			var adminInDb = db.BEAdmins.FirstOrDefault(m => m.Account == account);
			if (adminInDb == null) throw new Exception("帳號不存在");
			if (string.Compare(email, adminInDb.Email, StringComparison.CurrentCultureIgnoreCase) != 0) throw new Exception("帳號或 Email 錯誤");

			// 檢查 IsEmailConfirmed必需是true, 因為只有信箱已驗證的帳號才能重設密碼
			if (adminInDb.IsEmailConfirmed == false) throw new Exception("您還沒有驗證信箱, 請先至信箱接收驗證信進行驗證");

			// 更新記錄, 填入 verificationCode
			var verificationCode = Guid.NewGuid().ToString("N");
			adminInDb.VerificationCode = verificationCode;
			db.SaveChanges();

			// 發送重設密碼信
			var url = string.Format(urlTemplate, adminInDb.Id, verificationCode);

			new AdminsEmailHelper().SendForgetPasswordEmail(url, adminInDb.Name, email);

		}

		[Authorize]
		public ActionResult EditPassword()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditPassword(AdminEditPasswordVm vm)
		{
			if (!ModelState.IsValid) return View(vm);
			try
			{
				var currentAccount = User.Identity.Name;
				ChangePassword(vm, currentAccount);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}
			return RedirectToAction("Index","Home");
		}

		private void ChangePassword(AdminEditPasswordVm vm, string account)
		{
			var db = new AppDbContext();
			var adminInDb = db.BEAdmins.FirstOrDefault(p => p.Account == account);
			if (adminInDb == null) throw new Exception("帳號不存在");

			// 判斷輸入的原始密碼是否正確
			var verify = BCrypt.Net.BCrypt.Verify(vm.Password, adminInDb.EncryptedPassword);
			
			if (verify)
			{
				throw new Exception("原始密碼不正確");
			}

			// 使用 BCrypt 將密碼雜湊
			var salt = BCrypt.Net.BCrypt.GenerateSalt(11);
			var hashedPassword = BCrypt.Net.BCrypt.HashPassword(vm.Password, salt);

			// 更新記錄
			adminInDb.EncryptedPassword = hashedPassword;
			db.SaveChanges();
		}

		[Authorize]
		public ActionResult EditAdminProfileVm()
		{
			var currentAdminAccount = User.Identity.Name;
			var vm = GetAdminProfile(currentAdminAccount);

			return View(vm);
		}

		[Authorize]
		[HttpPost]
		public ActionResult EditAdminProfileVm(EditAdminProfileVm vm)
		{
			var currentAdminAccount = User.Identity.Name;
			if (!ModelState.IsValid) return View(vm);

			try
			{
				UpdateProfile(vm, currentAdminAccount);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}
			return RedirectToAction("Index","Home"); // 回到首頁
		}

		private void UpdateProfile(EditAdminProfileVm vm, string account)
		{
			// 利用 vm.Id去資料庫取得 Member
			var db = new AppDbContext();
			var AdminInDb = db.BEAdmins.FirstOrDefault(p => p.Id == vm.Id);

			// 如果這筆記錄與目前使用者不符, 就拒絕
			int result = string.Compare(AdminInDb.Account, account, StringComparison.OrdinalIgnoreCase);
			if (result != 0)
			//if (adminInDb.Account != account)
			{
				throw new Exception("您沒有權限修改別人的資料");
			}
			
			AdminInDb.Name = vm.Name;
			AdminInDb.Email = vm.Email;
			
			db.SaveChanges();
		}

		private EditAdminProfileVm GetAdminProfile(string account)
		{
			var db = new AppDbContext();

			var admin = db.BEAdmins.FirstOrDefault(p => p.Account == account);
			if (admin == null)
			{
				throw new Exception("帳號不存在");
			}

			var vm = admin.ToEditProfileVm();

			return vm;
		}

		[Authorize]
		public ActionResult Logout()
		{
			Session.Abandon();
			FormsAuthentication.SignOut();
			return Redirect("/BEAdmins/Login");
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
			var rememberMe = false; // 如果LoginVm有RememberMe屬性, 記得要設定
			var account = vm.Account;
			// 取得帳號 Id
			var db = new AppDbContext();
			//string adminId = db.BEAdmins.FirstOrDefault(p => p.Account == account).ToString();
			string adminId = "7";

			// 取得該帳號的擁有的權限清單
			string permissions = Roles.GetRolesForUser(account).ToString();


			// 建立一張認證票
			var ticket =
				new FormsAuthenticationTicket(
					1,          // 版本別, 沒特別用處
					account,
					DateTime.Now,   // 發行日
					DateTime.Now.AddDays(1), // 到期日
					rememberMe,     // 是否續存
					adminId,       // userdata
					FormsAuthentication.FormsCookiePath // cookie位置
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
			var admin = db.BEAdmins.FirstOrDefault(p => p.Account == vm.Account);
			if (admin == null)
			{
				throw new Exception("帳號或密碼有誤");// 原則上, 不要告知細節
			}

			// 使用 BCrypt 進行密碼比對
			string AdminsHashPassword = admin.EncryptedPassword;

			if (!BCrypt.Net.BCrypt.Verify(vm.Password, AdminsHashPassword))
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
