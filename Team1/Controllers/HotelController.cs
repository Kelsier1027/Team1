using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team1.Models;
using Team1.Models.EFModels;
using Team1.Models.Infra;

namespace Team1.Controllers
{
    public class Facilities
    {
        public List<int> FacilityIds { get; set; }

    }


    public class HotelController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Hotel
        public ActionResult Index()
        {
            var data = db.Hotels.ToList();
            var hotelCategories = db.HotelCategories.ToList();

            foreach (var singleData in data)
            {
                if (string.IsNullOrEmpty(singleData.HotelFacilities))
                {
                    continue;
                }

                Facilities obj = JsonConvert.DeserializeObject<Facilities>(singleData.HotelFacilities);
                string detail = "<ul>";

                if (obj?.FacilityIds != null)
                {
                    foreach (var facilityId in obj.FacilityIds)
                    {
                        var facility = hotelCategories.FirstOrDefault(x => x.Id == facilityId);
                        if (facility != null)
                        {
                            detail += $"<li>{facility.JAON}</li>";
                        }
                    }
                }
                detail += "</ul>";
                singleData.HotelFacilities = detail;
            }

            return View(data);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            Hotel hotel = new Hotel();
            var hotelCategories = db.HotelCategories.ToList();
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            ViewBag.HotelTypeId = new SelectList(db.HotelTypes, "Id", "Name");
            ViewBag.Categories = hotelCategories;
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DistrictId,Address,Grade,Phone,Level,MainImage,CheckinStart,CheckinEnd,CheckoutStart,CheckoutEnd,AddBedFee,BreakfastPrice,HotelTypeId,HotelFacilities,Email")] Hotel hotel, int[] SelectedCategories, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                // 序列化成 JSON 格式
                //string json = JsonConvert.SerializeObject(new { FacilityIds = hotel.SelectedCategoryIds });
                // 序列化成 JSON 格式
                var facilitiesJson = JsonConvert.SerializeObject(new { FacilityIds = SelectedCategories });

                //上傳圖片檔案
                string path = Server.MapPath("/Uploads");
                string newFileName = new UploadFileHelper().UploadFile(file1, path);
                hotel.MainImage = newFileName;

                // 指定給 HotelFacilities 欄位
                //hotel.HotelFacilities = JsonConvert.SerializeObject(new { FacilityIds = new int[] { 1, 2, 9, 11 } });
                hotel.HotelFacilities = facilitiesJson;
                db.Hotels.Add(hotel);
                db.SaveChanges();
                Session["HotelId"] = hotel.Id;
                return RedirectToAction("index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", hotel.DistrictId);
            ViewBag.HotelTypeId = new SelectList(db.HotelTypes, "Id", "Name", hotel.HotelTypeId);
            ViewBag.Categories = db.HotelCategories.ToList();  // 重新設置類別
            return View(hotel);
        }
        public ActionResult CreateRoom()
        {
            var hotelId = Session["HotelId"] as int?;
            if (hotelId == null)
            {
                return RedirectToAction("index");
            }

            var model = new HotelRoom { HotelId = hotelId.Value };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                db.HotelRooms.Add(hotelRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelRoom);
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            var data = hotel.HotelFacilities;
            Facilities obj = JsonConvert.DeserializeObject<Facilities>(data);
            string detail = "<ul>";

            foreach (var facilityId in obj.FacilityIds)
            {
                var facility = db.HotelCategories.FirstOrDefault(x => x.Id == facilityId);
                if (facility != null)
                {
                    detail += $"<li>{facility.JAON}</li>";
                }
            }
            detail += "</ul>";
            hotel.MainImage = "../" + hotel.MainImage;

            // 將設施細節存儲在 ViewBag 中，以便在視圖中顯示
            ViewBag.FacilityDetails = detail;

            return View(hotel);

        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult GetFacilities()
        {
            var facilities = db.HotelCategories
                .Select(e => e.JAON)
                .Distinct()
                .ToList();

            return Json(facilities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            // 解析 JSON 字符串以获取 FacilityIds
            var facilitiesData = JsonConvert.DeserializeObject<dynamic>(hotel.HotelFacilities);
            int[] facilityIds = facilitiesData.FacilityIds.ToObject<int[]>();

            // 获取所有可能的设施，以便在视图中显示
            var allFacilities = db.HotelCategories.ToList();

            // 将数据发送到视图
            ViewBag.SelectedFacilityIds = new HashSet<int>(facilityIds);
            ViewBag.AllFacilities = allFacilities;
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", hotel.DistrictId);
            ViewBag.HotelTypeId = new SelectList(db.HotelTypes, "Id", "Name", hotel.HotelTypeId);
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DistrictId,Address,Grade,Phone,Level,MainImage,CheckinStart,CheckinEnd,CheckoutStart,CheckoutEnd,AddBedFee,BreakfastPrice,HotelTypeId,HotelFacilities,Email")] Hotel hotel, int[] selectedFacilityIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                // 更新 HotelFacilities 字段
                var jsonFacilities = JsonConvert.SerializeObject(new { FacilityIds = selectedFacilityIds });
                hotel.HotelFacilities = jsonFacilities;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", hotel.DistrictId);
            ViewBag.HotelTypeId = new SelectList(db.HotelTypes, "Id", "Name", hotel.HotelTypeId);
            return View(hotel);
        }
    }
}