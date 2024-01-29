using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team1.InterFace.IRepositories.Admin;
using Team1.InterFace.Member;
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
					TempData["Created"] = newAdminId; // 內跳轉到成功提示頁面時，需要用到的參數
					return RedirectToAction("CreateSuccess");
				}
                catch (Exception ex)
                {
                    // 在頁面中顯示錯誤訊息
                    var errorMessage = ex.Message;
                    ViewBag.ErrorMessage = errorMessage;

                }
            }
            return View(vm);
        }

		[HttpGet]
		[ValidateAntiForgeryToken]
		public ActionResult CreateSuccess()
		{
			if (TempData["CreateSuccess"] == null)
			{
				return RedirectToAction("Index","Home"); // 將非法訪問導向到首頁
			}

			// 取得剛剛創建的新管理員的Id
			int newAdminId = 0; // 預設為 0

			// 判斷 TempData["NewAdminId"] 是否為 null 且能否轉換為 int
			if (TempData["NewAdminId"] != null && int.TryParse(TempData["NewAdminId"].ToString(), out newAdminId))
			{
				// 轉換成功，newAdminId 為轉換後的值
                // 取得新管理員的資料
				NewAdminVm admin = _service.GetById(newAdminId).ToNewAdminVm();
				return View(admin); // 將新管理員的資料傳遞到前端
			}
			else
			{
				// 在頁面中顯示錯誤訊息
                ViewBag.ErrorMessage = "無法取得新管理員的資料，管理員創建失敗，請重新創建";
			}
			return RedirectToAction("Index", "Home"); // 將非法訪問導向到首頁
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
