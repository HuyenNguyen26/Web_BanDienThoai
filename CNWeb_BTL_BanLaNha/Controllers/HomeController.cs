using CNWeb_BTL_BanLaNha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb_BTL_BanLaNha.Views.Classs;
namespace CNWeb_BTL_BanLaNha.Controllers
{
    public class HomeController : Controller
    {
        public class Product
        {
            public string TenSP;
            public string url;
            public int GiaSP;
        }
        SalePhone context = new SalePhone();
        public ActionResult Index()
        {
            //var spMoi = context.SANPHAMs.Where(x => x.TenSP != null && x.MaKM != null).ToList();
            //var spKM =  context.SANPHAMs.Where(x => x.TenSP != null).Take(10);
            //var spKM = context.spMois.Where(x => x.MaKM!=null).ToList();
            var spMoi = (from m in context.SANPHAMs
                         join n in context.KHUYENMAIs on m.MaKM equals n.MaKM
                         where m.TenSP != null

                         select new sanpham()
                         {
                             MaSP = m.MaSP,
                             TenSP = m.TenSP,
                             url = m.url,
                             GiaSP = m.GiaSP.Value,
                             PhanTramKM = n.PhanTramKM,
                             NgayPhatHanh = m.NgayPhatHanh
                         }
                          ).ToList();
            ViewBag.sqpmoi = spMoi.OrderByDescending(x => x.NgayPhatHanh).Take(10);
            ViewBag.spkm = (from m in context.SANPHAMs
                            join n in context.KHUYENMAIs on m.MaKM equals n.MaKM
                            where m.TenSP != null && m.MaKM !=null

                            select new sanpham()
                            {
                                MaSP = m.MaSP,
                                TenSP = m.TenSP,
                                url = m.url,
                                GiaSP = m.GiaSP.Value,
                                PhanTramKM = n.PhanTramKM,
                                NgayPhatHanh = m.NgayPhatHanh
                            }
                          ).ToList();
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