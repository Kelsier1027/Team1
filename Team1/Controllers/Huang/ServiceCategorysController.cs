using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.個人.Huang.Exts;
using Team1.個人.Huang.Interfaces;
using Team1.個人.Huang.Repositories;
using Team1.個人.Huang.Services;
using Team1.個人.Huang.ViewModels;

namespace Team1.Controllers.Hwang
{
    public class ServiceCategorysController : Controller
    {
        private static IServiceCategoryRepository getRepository = new ServiceCategoryEFRepository();
        ServiceCategoryService _service = new ServiceCategoryService(getRepository);
        // GET: ServiceCategory
        public ActionResult Index()
        {
            List<ServiceCategoryVm> vm = ServiceCategoryExts.DisplayGetAll();
            return View(vm);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCategoryVm model)
        {
            if (!ModelState.IsValid) //沒有通過驗證
            {
                return View(model);
            }
            try
            {
                _service.Create(ServiceCategoryExts.VmToDto(model));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var currentCate = Get(id);
            return View(currentCate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceCategoryVm model)
        {
            if (!ModelState.IsValid) //沒有通過驗證
            {
                return View(model);
            }
            try
            {
                _service.Update(ServiceCategoryExts.VmToDto(model));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        

        private ServiceCategoryVm Get(int id)
        {
            var get = _service.Get(id);
            return new ServiceCategoryVm
            {
                Id = get.Id,
                Name = get.Name,
            };
        }
    }
}