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
    public class CommentsController : Controller
    {
        private static ICommentRepository GetRepository = new CommentEFRepository();
        CommentService _service = new CommentService(GetRepository);
        // GET: Comment
        public ActionResult Index()
        {
            List<CommentVm> vm = CommentExt.DisplayGetAll();
            return View(vm);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CommentVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                _service.Create(CommentExt.VmToDto(vm));
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
        public ActionResult Edit(CommentVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                _service.Update(CommentExt.VmToDto(vm));
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
        private CommentVm Get(int id)
        {
            var get = _service.Get(id);
            return new CommentVm
            {
                Id = get.Id,
                ServiceCategoryId = get.ServiceCategoryId,
                MemberId = get.MemberId,
                Text = get.Text,
                Rating = get.Rating,
                CommentDateTime = get.CommentDateTime,
            };
        }
    }
}