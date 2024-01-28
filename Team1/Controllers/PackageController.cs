using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Team1.Models.EFModels;
using Team1.Scripts;
using Team1.ViewModels;

namespace Team1.Controllers
{
    public class PackageController : Controller
    {
        private AppDbContext db = new AppDbContext();
        PackgeService service = new PackgeService();

        // GET: Package
        public ActionResult Index(int? packageId = 0)
        {
            List<PackageVM> packageVM = service.Search(packageId).ToList();
            return View(packageVM);
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Package/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,LowestGo,ApplyEndDate,ApplyBeginDate,CanSold,TotalNum,Image,Description,Alert,PriceDescription")] PackageInsertVM packageVM)
        {
            if (ModelState.IsValid)
            {
                // 檢查 RoomId 是否已存在
                if (service.IsPackageIdExist(packageVM.Id))
                {
                    // 如果 RoomId 已存在，添加錯誤信息到 ModelState
                    ModelState.AddModelError("Id", "產品編號已存在");

                    // 返回 View，讓使用者重新輸入
                    return View(packageVM);
                }

                service.Create(packageVM);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageVM data = service.Search(id).FirstOrDefault();
            PackageInsertVM packageInsertVM = new PackageInsertVM();
            packageInsertVM.Id = data.Id;
            packageInsertVM.Name = data.Name;
            packageInsertVM.Description = data.Description;
            packageInsertVM.Image = data.Image;
            packageInsertVM.LowestGo = data.LowestGo;
            packageInsertVM.ApplyBeginDate = data.ApplyBeginDate;
            packageInsertVM.ApplyEndDate = data.ApplyEndDate;
            packageInsertVM.CanSold = data.CanSold;
            packageInsertVM.TotalNum = data.TotalNum;
            packageInsertVM.Alert = data.Alert;
            packageInsertVM.Price =data.Price;
            packageInsertVM.PriceDescription = data.PriceDescription;

            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Package/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,LowestGo,ApplyEndDate,ApplyBeginDate,CanSold,TotalNum,Image,Description,Alert,PriceDescription")] PackageVM packageVM)
        {
            if (ModelState.IsValid)
            {
                //service.Edit(packageVM);
                return RedirectToAction("Index");
            }
            return View(packageVM);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageVM packageVM = db.PackageVMs.Find(id);
            if (packageVM == null)
            {
                return HttpNotFound();
            }
            return View(packageVM);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // 先取得要刪除的房型
            var package = service.Search(id).FirstOrDefault();

            // 確保找到資料
            if (package != null)
            {
                // 刪除
                service.Delete(id);
                // 返回到Index頁面或其他適當的頁面
                return RedirectToAction("Index");
            }
            else
            {
                // 如果找不到房型，返回一個錯誤視圖或其他處理方式
                return HttpNotFound();
            }
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
