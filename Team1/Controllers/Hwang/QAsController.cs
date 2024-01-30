using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            List<QAsVm> vm = QAsExts.DisplayGetAll();
            IEnumerable<SelectListItem> list = new List<SelectListItem>();

            ViewBag.list = list;

            return View(vm);
        }
        public ActionResult Create()
        {
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
                _service.Update(QAsExts.VmToDto(vm));
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
        private IEnumerable<SelectListItem> GetSelectListItems(ISelectListService service)
        {
            var list = service.SearchAll();

            var result = new List<SelectListItem>();

            foreach (var item in list)
            {
                result.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            return result.Prepend(new SelectListItem { Value = "", Text = "請選擇..." });
        }

        private SelectList GetSelectList(ISelectListService service, int selectId)
        {
            return new SelectList(service.SearchAll(), "Id", "Name", selectId);
        }
    }
}