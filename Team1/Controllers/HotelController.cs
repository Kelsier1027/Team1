using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Team1.Models;
using Team1.Models.EFModels;

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
        public ActionResult Create([Bind(Include = "Id,Name,DistrictId,Address,Grade,Phone,Level,MainImage,CheckinStart,CheckinEnd,CheckoutStart,CheckoutEnd,AddBedFee,BreakfastPrice,HotelTypeId,HotelFacilities,Email")] Hotel hotel, int[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                // 序列化成 JSON 格式
                string json = JsonConvert.SerializeObject(new { FacilityIds = hotel.SelectedCategoryIds });

                // 指定給 HotelFacilities 欄位
                hotel.HotelFacilities = json;
                db.Hotels.Add(hotel);
                db.SaveChanges();
                Session["HotelId"] = hotel.Id;
                return RedirectToAction("CreateRoom");
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
    }
}