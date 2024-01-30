using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Team1.Models.DTO;
using Team1.Models.EFModel;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Team1.Controllers
{
    public class AttractionApiController : ApiController
    {

        [HttpPost]
        [Route("api/AttractionApi/DisplayAttraction")]
        public IHttpActionResult DisplayAttraction([FromBody] AttractionSearchDTO _search)
        {
            var db = new AppDbContext();
            var attractions = _search.CategoryId == 0 ? db.Attractions : db.Attractions.Where(a => a.AttractionCategoryId == _search.CategoryId);

            if (!string.IsNullOrEmpty(_search.Keyword))
            {
                attractions = attractions.Where(a => a.Name.Contains(_search.Keyword) || a.Description.Contains(_search.Keyword));
            }
            switch (_search.SortBy)
            {
                case "AttractionName":
                    attractions = _search.SortDirection == "ASC" ? attractions.OrderBy(a => a.Name) : attractions.OrderByDescending(a => a.Name);
                    break;
                case "AttractionId":
                    attractions = _search.SortDirection == "ASC" ? attractions.OrderBy(a => a.Id) : attractions.OrderByDescending(a => a.Id);
                    break;
                default:
                    attractions = _search.SortDirection == "ASC" ? attractions.OrderBy(a => a.Id) : attractions.OrderBy(a => a.Id);
                    break;
            }
            int totalCount = attractions.Count();
            int pageSize = _search.PageSize ?? 12;  //如果沒有給值，就給預設12
            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            int page = _search.Page ?? 1;

            var attractionsDto = attractions.Select(a => new AttractionDTO
            {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address,
                Category = a.AttractionCategory.Name,
                City = a.City.Name,
                Description = a.Description,
                CoverImage = a.MainImage,
            }).Skip((page - 1) * pageSize).Take(pageSize);

            AttractionPagingDTO attractionpageing = new AttractionPagingDTO();
            attractionpageing.TotalPages = totalPage;
            attractionpageing.Attractions = attractionsDto.ToList();


            return Json(attractionpageing);
        }


        [Route("api/AttractionApi/GetCategory")]
        public IHttpActionResult GetCategory()
        {
            var db = new AppDbContext();
            var categories = db.AttractionCategories.Select(c => new { c.Id, c.Name })
                                                    .OrderBy(c=>c.Id)
                                                    .ToList();
            return Json(categories);
        }
    }
}