﻿using System;
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
    public class AdminChiTietPhieuNhapController : Controller
    {
        private QuanLyXeMayEntities db = new QuanLyXeMayEntities();

        // GET: Admin/AdminChiTietPhieuNhap
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {


                var chiTietPhieuNhaps = db.ChiTietPhieuNhaps.Include(c => c.PhieuNhap).Include(c => c.Xe);
                return View(chiTietPhieuNhaps.ToList());
            }
        }

        // GET: Admin/AdminChiTietPhieuNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhap);
        }

        // GET: Admin/AdminChiTietPhieuNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhaps, "MaPhieuNhap", "MaPhieuNhap");
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe");
            return View();
        }

        // POST: Admin/AdminChiTietPhieuNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaXe,MaPhieuNhap,SoLuongNhap,DonGiaNhap")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhaps, "MaPhieuNhap", "MaPhieuNhap", chiTietPhieuNhap.MaPhieuNhap);
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe", chiTietPhieuNhap.MaXe);
            return View(chiTietPhieuNhap);
        }

        // GET: Admin/AdminChiTietPhieuNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhaps, "MaPhieuNhap", "MaPhieuNhap", chiTietPhieuNhap.MaPhieuNhap);
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe", chiTietPhieuNhap.MaXe);
            return View(chiTietPhieuNhap);
        }

        // POST: Admin/AdminChiTietPhieuNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaXe,MaPhieuNhap,SoLuongNhap,DonGiaNhap")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhaps, "MaPhieuNhap", "MaPhieuNhap", chiTietPhieuNhap.MaPhieuNhap);
            ViewBag.MaXe = new SelectList(db.Xes, "MaXe", "TenXe", chiTietPhieuNhap.MaXe);
            return View(chiTietPhieuNhap);
        }

        // GET: Admin/AdminChiTietPhieuNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhap);
        }

        // POST: Admin/AdminChiTietPhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            db.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
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
