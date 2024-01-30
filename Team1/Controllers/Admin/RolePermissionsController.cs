using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team1.Models.EFModels;

namespace Team1.Controllers.Admin
{
    public class RolePermissionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RolePermissions
        public ActionResult Index()
        {
            var rolePermissions = db.RolePermissions.Include(r => r.Permission).Include(r => r.Role);
            return View(rolePermissions.ToList());
        }

        // GET: RolePermissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = db.RolePermissions.Find(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // GET: RolePermissions/Create
        public ActionResult Create()
        {
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name");
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // POST: RolePermissions/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,PermissionId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                db.RolePermissions.Add(rolePermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", rolePermission.PermissionId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", rolePermission.RoleId);
            return View(rolePermission);
        }

        // GET: RolePermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = db.RolePermissions.Find(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", rolePermission.PermissionId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", rolePermission.RoleId);
            return View(rolePermission);
        }

        // POST: RolePermissions/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,PermissionId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolePermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", rolePermission.PermissionId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", rolePermission.RoleId);
            return View(rolePermission);
        }

        // GET: RolePermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = db.RolePermissions.Find(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolePermission rolePermission = db.RolePermissions.Find(id);
            db.RolePermissions.Remove(rolePermission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
