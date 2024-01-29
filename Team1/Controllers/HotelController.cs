using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.Models;

namespace Team1.Controllers
{
    public class HotelController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Hotel
        public ActionResult Index()
        {
            var data = db.Hotels.ToList();
            return View(data);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            ViewBag.HotelTypeId = new SelectList(db.HotelTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DistrictId,Address,Grade,Phone,Level,MainImage,CheckinStart,CheckinEnd,CheckoutStart,CheckoutEnd,AddBedFee,BreakfastPrice,HotelTypeId,HotelFacilities,Email")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", hotel.DistrictId);
            ViewBag.HotelTypeId = new SelectList(db.HotelTypes, "Id", "Name", hotel.HotelTypeId);
            return View(hotel);
        }
    }
}