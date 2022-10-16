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
    public class AdminPhieuNhapController : Controller
    {
        private QuanLyXeMayEntities db = new QuanLyXeMayEntities();

        // GET: Admin/AdminPhieuNhap
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {


                var phieuNhaps = db.PhieuNhaps.Include(p => p.NhaCungCap).Include(p => p.NhanVien);
                return View(phieuNhaps.ToList());
            }
        }

        // GET: Admin/AdminPhieuNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // GET: Admin/AdminPhieuNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: Admin/AdminPhieuNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuNhap,NgayNhap,MaNhanVien,MaNhaCungCap,ThanhTienNhap")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhaps.Add(phieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", phieuNhap.MaNhaCungCap);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhap.MaNhanVien);
            return View(phieuNhap);
        }

        // GET: Admin/AdminPhieuNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", phieuNhap.MaNhaCungCap);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhap.MaNhanVien);
            return View(phieuNhap);
        }

        // POST: Admin/AdminPhieuNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuNhap,NgayNhap,MaNhanVien,MaNhaCungCap,ThanhTienNhap")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", phieuNhap.MaNhaCungCap);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhap.MaNhanVien);
            return View(phieuNhap);
        }

        // GET: Admin/AdminPhieuNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // POST: Admin/AdminPhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            db.PhieuNhaps.Remove(phieuNhap);
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
