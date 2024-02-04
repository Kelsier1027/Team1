using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team1.Models.EFModels;
using Team1.Models.Infra;

namespace Team1.Controllers
{
    public class HotelRoomController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: HotelRoom
        public ActionResult Index(int? id)
        {
            // 使用 LINQ 查询来找出所有匹配 hotelId 的 HotelRooms
            var hotelRooms = db.HotelRooms.Where(h => h.HotelId == id).ToList();
            ViewBag.hotelId = id;

            return View(hotelRooms);
        }

        // GET: HotelRooms/Create
        public ActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name", id.HasValue ? id.Value : -1);
                ViewBag.SelectedHotelId = id.HasValue ? id.Value : -1; // 确保有默认值或合理的备选值
                ViewBag.SelectedHotelId = id; // 用于在视图中设置隐藏字段的值
            }
            else
            {
                ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name");
            }
            return View();
        }

        // POST: HotelRooms/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,HotelId,Size,RoomFacilities,Capacity,BedCapacity,MainImage,WeekdayPrice,WeekendPrice,AddTimeFee,Count")] HotelRoom hotelRoom, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                hotelRoom.RoomFacilities = "1"; //沒見到資料表 先都預設為1 之後再看是否使用
                //上傳圖片檔案
                string path = Server.MapPath("/Uploads");
                string newFileName = new UploadFileHelper().UploadFile(file1, path);
                hotelRoom.MainImage = "../" + newFileName;
                db.HotelRooms.Add(hotelRoom);
                db.SaveChanges();
                return RedirectToAction("Index","Hotel");
            }

            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name", hotelRoom.HotelId);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = id;
            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            // 假设HotelRoom模型中有一个名为HotelId的属性，指向Hotel的外键
            int hotelId = hotelRoom.HotelId;
            db.HotelRooms.Remove(hotelRoom);
            db.SaveChanges();
            // 使用hotelId作为参数重定向到Index视图
            return RedirectToAction("Index", new { id = hotelId });
        }

        // GET: HotelRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name", hotelRoom.HotelId);
            ViewBag.SelectedHotelId = id.HasValue ? id.Value : -1; // 确保有默认值或合理的备选值
            ViewBag.SelectedHotelId = id; // 用于在视图中设置隐藏字段的值
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,HotelId,Size,RoomFacilities,Capacity,BedCapacity,MainImage,WeekdayPrice,WeekendPrice,AddTimeFee,Count")] HotelRoom hotelRoom, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    string path = Server.MapPath("/Uploads");
                    string newFileName = new UploadFileHelper().UploadFile(file1, path);
                    // 更新Hotel对象的MainImage属性
                    hotelRoom.MainImage = "../" + newFileName;
                }
                hotelRoom.RoomFacilities = "1"; //忘記建資料表 先預設
                db.Entry(hotelRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = hotelRoom.HotelId });
            }
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name", hotelRoom.HotelId);
            return View(hotelRoom);
        }

    }
}