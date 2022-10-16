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
    public class AdminKhachHangController : Controller
    {
        private QuanLyXeMayEntities db = new QuanLyXeMayEntities();

        // GET: Admin/AdminKhachHang        

        public ActionResult Index(string thongtintimkiem)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {
                if(thongtintimkiem == null)
                {
                    return View(db.LayKhachHang().ToList());
                }    
                else if (thongtintimkiem.Equals(""))
                {
                    return View(db.LayKhachHang().ToList());
                }
                else
                {
                    bool check = int.TryParse(thongtintimkiem, out _);
                    if(check) return View(db.sp_TimKiemKhachHang(thongtintimkiem, int.Parse(thongtintimkiem)).ToList());
                    return View(db.sp_TimKiemKhachHang(thongtintimkiem, null).ToList());
                }
                /*return View(db.sp_XuatTatCaKhachHang().ToList());*/                
            }
        }

        // GET: Admin/AdminKhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            KhachHang khachHang = db.KhachHangs.Find(id);
            /*var data = db.LayKhachHang();*/

            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/AdminKhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminKhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,TenKhachHang,DiaChi,DienThoai,TenDangNhap,MatKhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: Admin/AdminKhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/AdminKhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,TenKhachHang,DiaChi,DienThoai,TenDangNhap,MatKhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {   
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admin/AdminKhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/AdminKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
