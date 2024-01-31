using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class QAsController : Controller
    {
        private static IQAsRepository GetRepository = new QAsEFRepository();
        QAsService _service = new QAsService(GetRepository);
        // GET: QAs
        public ActionResult Index(int id = 0)
        {
            var vm = new List<QAsVm>();
            if (id == 0) 
            {
                return View(QAsExts.DisplayGetAll());
            }
            else
            {
                vm = _service.SerchByCategoryId(id).DtoToVm();
            }            
            return View(vm);
        }
        public ActionResult Create()
        {
            var repo = new ServiceCategoryEFRepository();

            var service = new ServiceCategoryService(repo);

            ViewBag.Createlist = service.GetSelectListItems();

            return View();
        }
        [HttpPost]
        public ActionResult Create(QAsVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                _service.Create(QAsExts.VmToDto(vm));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }
        public ActionResult Edit(int id)
        {            
            var currentCate = Get(id);
            ViewBag.Editlist = new ServiceCategoryService(new ServiceCategoryEFRepository()).GetSelectList(id);
            return View(currentCate);
        }
        [HttpPost]
        public ActionResult Edit(QAsVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                _service.Update(vm.VmToDto());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }

        }
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        private QAsVm Get(int id)
        {
            var get = _service.Get(id);
            return new QAsVm
            {
                Id = get.Id,
                ServiceCategoryId = get.ServiceCategoryId,
                QName = get.QName,
                AnsText = get.AnsText,
            };
        }
        
    }
}