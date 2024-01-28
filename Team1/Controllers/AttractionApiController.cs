using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Team1.Models.DTO;
using Team1.Models.EFModels;

namespace Team1.Controllers
{
    public class AttractionApiController : Controller
    {
        // GET: AttractionApi
        public ActionResult DisplayAttraction([FromBody] SearchDTO _search)
        {
            var db = new AppDbContext();
            var attractions = _search.CategoryId == 0 ? db.Attractions : db.Attractions.Where(a => a.Id == _search.CategoryId);

            if(!string.IsNullOrEmpty(_search.Keyword))
            {
                attractions = attractions.Where(a => a.Name.Contains(_search.Keyword) || a.Description.Contains(_search.Keyword));
            }


           
        }

    }
}