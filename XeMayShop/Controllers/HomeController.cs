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
            ViewBag.newProduct = data.Xes.Take(8).OrderByDescending(x => x.NamSanXuat).ToList();


/*            // lấy danh sách xe tay côn
            ViewBag.xetaycon = data.Xes.Take(8).Where(x => x.LoaiXe.MaLoaiXe == 1);
            // Lấy danh sách xe tay ga
            ViewBag.xetayga = data.Xes.Take(8).Where(x => x.LoaiXe.MaLoaiXe == 2);
            // Lấy danh sách xe số
            ViewBag.xeso = data.Xes.Take(8).Where(x => x.LoaiXe.MaLoaiXe == 3);*/

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}