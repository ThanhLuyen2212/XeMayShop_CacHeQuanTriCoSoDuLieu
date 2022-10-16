using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XeMayShop.Models;

namespace XeMayShop.Controllers
{
    public class LoginController : Controller
    {
        QuanLyXeMayEntities data = new QuanLyXeMayEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(KhachHang user)
        {
            var check = data.sp_CheckLoginKhachHang(user.TenDangNhap, user.MatKhau);
            /*KhachHang check = data.KhachHangs.Where(s => s.TenDangNhap == user.TenDangNhap && s.MatKhau == user.MatKhau).FirstOrDefault();*/
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai thông tin tài khoản";
                return View("Index");
            }
            else
            {
                data.Configuration.ValidateOnSaveEnabled = false;               
                Session["KhachHang"] = check;


                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.sp_DangKyKhachHang(khachHang.TenKhachHang, khachHang.DiaChi, khachHang.DienThoai, khachHang.TenDangNhap, khachHang.MatKhau);
                    data.KhachHangs.Add(khachHang);
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    
                }
                
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}