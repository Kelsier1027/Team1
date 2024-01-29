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
    }
}