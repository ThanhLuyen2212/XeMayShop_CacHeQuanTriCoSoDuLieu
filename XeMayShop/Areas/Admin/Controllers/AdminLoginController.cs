using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XeMayShop.Models;

namespace XeMayShop.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {

        QuanLyXeMayEntities data = new QuanLyXeMayEntities();   

        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(XeMayShop.Models.Admin admin)
        {            
            var check = data.sp_CheckLogin(admin.TenDangNhap, admin.MatKhau);
                        
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai thông tin tài khoản";
                return View("Index");
            }
            else
            {
                XeMayShop.Models.Admin temp = data.Admins.Where(s => s.TenDangNhap == admin.TenDangNhap && s.MatKhau == admin.MatKhau).FirstOrDefault();
                data.Configuration.ValidateOnSaveEnabled = false;   
              
                Session["Admin"] = temp;

                return RedirectToAction("Index", "AdminHome", new { Areas = "Admin" });
            }
        }
    }
}