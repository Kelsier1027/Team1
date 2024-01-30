using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.Models.EFModel;
using Team1.Models.ViewModel;

namespace Team1.Controllers
{
    public class AttractionController : Controller
    {
        // GET: Attraction
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Attraction()
        {
            return View();
        }
        public ActionResult AttractionList()
            
        {
            var db = new AppDbContext();
            return View(db.Attractions.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        public void CreateAttraction(AttractionVm vm)
        {
            var db = new AppDbContext();
            var attraction = new Attraction
            {
                Name=vm.Name,
                Address=vm.Address,
                MainImage=vm.CoverImage,
                Description=vm.Description,
            };
            db.Attractions.Add(attraction);
            db.SaveChanges();
        }
        public void DeleteAttraction(int id) 
        {
            var db = new AppDbContext();
            var attraction = db.Attractions.FirstOrDefault(a => a.Id == id);
            db.Attractions.Remove(attraction);
            db.SaveChanges();
        }
















    }
}