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
    public class AdminChiTietPhieuXuatController : Controller
    {
        private QuanLyXeMayEntities db = new QuanLyXeMayEntities();

        // GET: Admin/AdminChiTietPhieuXuat
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {


                var chiTietPhieuXuats = db.ChiTietPhieuXuats.Include(c => c.PhieuXuat).Include(c => c.Xe);
                return View(chiTietPhieuXuats.ToList());
            }
        }

        // GET: Admin/AdminChiTietPhieuXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // GET: Admin/AdminChiTietPhieuXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieuXuat = new SelectList(db.PhieuXuats, "MaPhieuXuat", "MaPhieuXuat");
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe");
            return View();
        }

        // POST: Admin/AdminChiTietPhieuXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaXe,MaPhieuXuat,SoLuongXuat,DonGiaXuat")] ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuXuats.Add(chiTietPhieuXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieuXuat = new SelectList(db.PhieuXuats, "MaPhieuXuat", "MaPhieuXuat", chiTietPhieuXuat.MaPhieuXuat);
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe", chiTietPhieuXuat.MaXe);
            return View(chiTietPhieuXuat);
        }

        // GET: Admin/AdminChiTietPhieuXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieuXuat = new SelectList(db.PhieuXuats, "MaPhieuXuat", "MaPhieuXuat", chiTietPhieuXuat.MaPhieuXuat);
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe", chiTietPhieuXuat.MaXe);
            return View(chiTietPhieuXuat);
        }

        // POST: Admin/AdminChiTietPhieuXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaXe,MaPhieuXuat,SoLuongXuat,DonGiaXuat")] ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieuXuat = new SelectList(db.PhieuXuats, "MaPhieuXuat", "MaPhieuXuat", chiTietPhieuXuat.MaPhieuXuat);
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe", chiTietPhieuXuat.MaXe);
            return View(chiTietPhieuXuat);
        }

        // GET: Admin/AdminChiTietPhieuXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // POST: Admin/AdminChiTietPhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            db.ChiTietPhieuXuats.Remove(chiTietPhieuXuat);
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
