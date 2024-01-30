using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
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
        public ActionResult Create([Bind(Include = "Id,Name,Price,LowestGo,ApplyEndDate,ApplyBeginDate,CanSold,TotalNum,Image,Description,Alert,PriceDescription")] PackageVM packageVM, HttpPostedFileBase ImageFile, HttpPostedFileBase DescriptionFile)
        {
            if (ModelState.IsValid)
            {
                if (packageVM.ApplyEndDate <= packageVM.ApplyBeginDate)
                {
                    // 如果 RoomId 已存在，添加錯誤信息到 ModelState
                    ModelState.AddModelError("ApplyEndDate", "報名截止日需大於報名開始日");
                    // 返回 View，讓使用者重新輸入
                    return View(packageVM);
                }
                packageVM.Image = SaveFile(ImageFile, "Image");
                packageVM.Description = SaveFile(DescriptionFile, "PackageDescription");
                service.Create(packageVM);
                return RedirectToAction("Index");
            }
            return View();
        }
        public string SaveFile(HttpPostedFileBase file,string type)
        {
            if (file != null && file.ContentLength > 0)
            {
                // 取得文件名
                string uploadFileName = Path.GetFileName(file.FileName);
                //取得副檔名
                string fileExtension = Path.GetExtension(uploadFileName);
                //存檔文件名
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                // 將文件保存到伺服器
                string filePath = Path.Combine(Server.MapPath("~/File/Pinyue/" + type), fileName);
                file.SaveAs(filePath);
                return fileName;
            }
            return null;
        }
        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageVM data = service.Search(id).FirstOrDefault();
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
        public ActionResult Edit([Bind(Include = "Id,Name,Price,LowestGo,ApplyEndDate,ApplyBeginDate,CanSold,TotalNum,Image,Description,Alert,PriceDescription")] PackageVM packageVM, HttpPostedFileBase ImageFile, HttpPostedFileBase DescriptionFile)
        {
            if (ModelState.IsValid)
            {
                if (packageVM.ApplyEndDate <= packageVM.ApplyBeginDate)
                {
                    // 如果 RoomId 已存在，添加錯誤信息到 ModelState
                    ModelState.AddModelError("ApplyEndDate", "報名截止日需大於報名開始日");
                    // 返回 View，讓使用者重新輸入
                    return View(packageVM);
                }
                packageVM.Image = SaveFile(ImageFile, "Image");
                packageVM.Description = SaveFile(DescriptionFile, "PackageDescription");
                service.Edit(packageVM);
                return RedirectToAction("Index");
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
                // 獲取圖檔路徑
                string[] path = { Server.MapPath(package.Image), Server.MapPath(package.Description) };
                foreach (var item in path)
                {
                    // 刪除圖檔
                    if (System.IO.File.Exists(item))
                    {
                        System.IO.File.Delete(item);
                    }
                }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int? id, string name, DateTime? date)
        {
            // 在這裡獲取查詢參數，執行您的查詢邏輯
            // 使用 roomTypeId, typeName, capacity 進行過濾

            // 示例：您可能有一個服務類別（service），它可以處理查詢邏輯
            var result = service.Search_Cond(id, name, date);

            // 返回查詢結果，或者進行其他適當的處理
            return View("Index", result);
        }
    }
}
