using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.Models;
using Team1.Models.EFModels;

namespace Team1.Controllers
{
    
    public class OrderController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Order
        public ActionResult Index()
        {
            var data = db.HotelOrders;
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.AdminId = new SelectList(db.BEAdmins, "Id", "Account");
            ViewBag.HotelOrderCancelReasonId = new SelectList(db.HotelOrderCancelReasons, "Id", "Name");
            ViewBag.HotelOrderStatusId = new SelectList(db.HotelOrderStatuses, "Id", "Name");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Account");
            return View();
        }

        // POST: Orders/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderSn,NumberOfPeople,Breakfast,HotelOrderStatusId,Phone,CreditCard,MemberId,Price,Checkin,Checkout,HotelOrderCancelReasonId,AdminId")] HotelOrder hotelOrder)
        {
            if (ModelState.IsValid)
            {
                db.HotelOrders.Add(hotelOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminId = new SelectList(db.BEAdmins, "Id", "Account", hotelOrder.AdminId);
            ViewBag.HotelOrderCancelReasonId = new SelectList(db.HotelOrderCancelReasons, "Id", "Name", hotelOrder.HotelOrderCancelReasonId);
            ViewBag.HotelOrderStatusId = new SelectList(db.HotelOrderStatuses, "Id", "Name", hotelOrder.HotelOrderStatusId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Account", hotelOrder.MemberId);
            return View(hotelOrder);
        }

    }
}