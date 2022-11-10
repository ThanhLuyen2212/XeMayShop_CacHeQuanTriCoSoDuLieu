using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XeMayShop.Models;

namespace XeMayShop.Areas.Admin.Controllers
{
    public class AdminDongXeController : Controller
    {
        private QuanLyXeMayEntities db = new QuanLyXeMayEntities();

        // GET: Admin/AdminDongXe
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
                return View(db.DongXes.ToList());
        }

        // GET: Admin/AdminDongXe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongXe dongXe = db.DongXes.Find(id);
            if (dongXe == null)
            {
                return HttpNotFound();
            }
            return View(dongXe);
        }

        // GET: Admin/AdminDongXe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDongXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDongXe,TenDongXe,SoLuongHienCo")] DongXe dongXe)
        {
            if (ModelState.IsValid)
            {
                db.DongXes.Add(dongXe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dongXe);
        }

        // GET: Admin/AdminDongXe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongXe dongXe = db.DongXes.Find(id);
            if (dongXe == null)
            {
                return HttpNotFound();
            }
            return View(dongXe);
        }

        // POST: Admin/AdminDongXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDongXe,TenDongXe,SoLuongHienCo")] DongXe dongXe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dongXe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dongXe);
        }

        // GET: Admin/AdminDongXe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongXe dongXe = db.DongXes.Find(id);
            if (dongXe == null)
            {
                return HttpNotFound();
            }
            return View(dongXe);
        }

        // POST: Admin/AdminDongXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DongXe dongXe = db.DongXes.Find(id);
            db.DongXes.Remove(dongXe);
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
