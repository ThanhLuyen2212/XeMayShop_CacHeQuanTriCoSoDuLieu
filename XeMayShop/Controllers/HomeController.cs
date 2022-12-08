using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XeMayShop.Models;
namespace XeMayShop.Controllers
{
    public class HomeController : Controller
    {
        QuanLyXeMayEntities data = new QuanLyXeMayEntities();
        public ActionResult Index()
        {

            ViewBag.banner = data.Xes.Take(3).ToList();

            /*những sản phẩm mới nhất*/
            /*ViewBag.newProduct = data.Xes.Take(8).OrderByDescending(x => x.NamSanXuat).ToList();*/
            List<Xe> xes = data.sp_8ChiecXeMoiNhat().ToList();
            ViewBag.newProduct = xes;


            List<Xe> xes1 = data.sp_8SanPhamBanChayTrongMotThang().ToList();
            ViewBag.SanPhamBanChayNhat = xes1;
            

/*            // lấy danh sách xe tay côn
            ViewBag.xetaycon = data.Xes.Take(8).Where(x => x.LoaiXe.MaLoaiXe == 1);
            // Lấy danh sách xe tay ga
            ViewBag.xetayga = data.Xes.Take(8).Where(x => x.LoaiXe.MaLoaiXe == 2);
            // Lấy danh sách xe số
            ViewBag.xeso = data.Xes.Take(8).Where(x => x.LoaiXe.MaLoaiXe == 3);*/

            return View();
        }
    }
}