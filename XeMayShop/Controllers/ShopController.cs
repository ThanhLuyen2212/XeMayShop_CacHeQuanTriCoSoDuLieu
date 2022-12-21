using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XeMayShop.Models;
using PagedList;
namespace XeMayShop.Controllers
{
    public class ShopController : Controller
    {
        QuanLyXeMayEntities data = new QuanLyXeMayEntities();
        // GET: Shop
        public ActionResult Index(string MaXe, string TenXe, string TenDongXe,  int page = 1, int pagelist = 6)
        {
            ViewBag.XeTayCon = data.DongXes.Where(x => x.MaLoaiXe == 3).ToList();
            ViewBag.XeTayGa = data.DongXes.Where(x => x.MaLoaiXe == 2).ToList();
            ViewBag.XeSo = data.DongXes.Where(x => x.MaLoaiXe == 1).ToList();

            if (TenDongXe != null)
            {
                return View(data.Xes.OrderByDescending(x => x.TenXe).Where(s => s.DongXe.TenDongXe == TenDongXe).ToPagedList(page, pagelist));
            }

            if (MaXe == null && TenXe == null)
            {
                return View(data.Xes.OrderByDescending(x => x.TenXe).ToPagedList(page, pagelist));
            }
            int a;
            if (int.TryParse(MaXe, out a) == false) 
                return View(data.sp_TimKiemXe(TenXe,null).OrderByDescending(x => x.TenXe).ToPagedList(page, pagelist));
            else
                return View(data.sp_TimKiemXe(TenXe, a).OrderByDescending(x => x.TenXe).ToPagedList(page, pagelist));
        }
    }
}