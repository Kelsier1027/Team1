using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.Models.EFModels;

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

            return View(hotelRooms);
        }
    }
}