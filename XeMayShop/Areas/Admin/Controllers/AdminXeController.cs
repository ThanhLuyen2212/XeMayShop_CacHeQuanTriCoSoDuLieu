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
    public class AdminXeController : Controller
    {
        private QuanLyXeMayEntities db = new QuanLyXeMayEntities();

        // GET: Admin/AdminXe
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {
                var xes = db.Xes.Include(x => x.DongXe).Include(x => x.LoaiXe);
                return View(xes.ToList());
            }
        }

        // GET: Admin/AdminXe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xe xe = db.Xes.Find(id);
            if (xe == null)
            {
                return HttpNotFound();
            }
            return View(xe);
        }

        // GET: Admin/AdminXe/Create
        public ActionResult Create()
        {
            ViewBag.MaDongXe = new SelectList(db.DongXes, "MaDongXe", "TenDongXe");
            ViewBag.MaLoaiXe = new SelectList(db.LoaiXes, "MaLoaiXe", "TenLoaiXe");
            return View();
        }

        // POST: Admin/AdminXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaXe,MaLoaiXe,MaDongXe,TenXe,MoTaXe,ThongTinBaoHanh,DonGiaXe,SoLuongHienCo")] Xe xe)
        {
            if (ModelState.IsValid)
            {
                db.Xes.Add(xe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDongXe = new SelectList(db.DongXes, "MaDongXe", "TenDongXe", xe.MaDongXe);
            ViewBag.MaLoaiXe = new SelectList(db.LoaiXes, "MaLoaiXe", "TenLoaiXe", xe.MaLoaiXe);
            return View(xe);
        }

        // GET: Admin/AdminXe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xe xe = db.Xes.Find(id);
            if (xe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDongXe = new SelectList(db.DongXes, "MaDongXe", "TenDongXe", xe.MaDongXe);
            ViewBag.MaLoaiXe = new SelectList(db.LoaiXes, "MaLoaiXe", "TenLoaiXe", xe.MaLoaiXe);
            return View(xe);
        }

        // POST: Admin/AdminXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaXe,MaLoaiXe,MaDongXe,TenXe,MoTaXe,ThongTinBaoHanh,DonGiaXe,SoLuongHienCo")] Xe xe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDongXe = new SelectList(db.DongXes, "MaDongXe", "TenDongXe", xe.MaDongXe);
            ViewBag.MaLoaiXe = new SelectList(db.LoaiXes, "MaLoaiXe", "TenLoaiXe", xe.MaLoaiXe);
            return View(xe);
        }

        // GET: Admin/AdminXe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xe xe = db.Xes.Find(id);
            if (xe == null)
            {
                return HttpNotFound();
            }
            return View(xe);
        }

        // POST: Admin/AdminXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Xe xe = db.Xes.Find(id);
            db.Xes.Remove(xe);
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
