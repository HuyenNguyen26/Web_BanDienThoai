using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNWeb_BTL_BanLaNha.Models;
using CNWeb_BTL_BanLaNha.Views.Classs;

namespace CNWeb_BTL_BanLaNha.Controllers
{
    public class ProductController : Controller
    {
        SalePhone context = new SalePhone();
        // GET: Product
        public ActionResult Detail(int id)
        {
            var product = context.spMois.Find(id);
            var model = context.spMois.Where(x => x.MaSP == id).Take(1);
            var maloai = context.spMois.Where(x => x.MaSP != id && x.MaLoai == product.MaLoai).Take(6);
            ViewBag.SPLienQuan = maloai;

            return View(model);
        }

        public ActionResult ProductsList(int ?page)
        {
            var model = context.spMois.Where(x => x.TenSP != null).OrderByDescending(x => x.GiaSP).ToPagedList(page?? 1, 12);
            //var model = context.SANPHAMs.Where(x => x.TenSP != null).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Timkiem(string search, int ?page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains(search)).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12); ;
            return View("ProductsList", model);
        }

        public ActionResult DT(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP != null && x.MaLoai == 1).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult PK(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP != null && (x.MaLoai == 2 || x.MaLoai == 3 || x.MaLoai == 4)).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPSS(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains("SamSung") && x.MaLoai == 1).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPIP(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains("Iphone") && x.MaLoai == 1).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPOP(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains("OPPO") && x.MaLoai == 1).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPXM(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains("XiaoMi") && x.MaLoai == 1).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPTN(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains("Tai nghe") && x.MaLoai == 2).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPOL(int? page)
        {
            var model = context.spMois.Where(x => (x.TenSP.Contains("Ốp lưng") || x.TenSP.Contains("Bao da")) && x.MaLoai == 3).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SPL(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP.Contains("Loa") && x.MaLoai == 4).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SXT(int ?page)
        {
            var model = context.spMois.Where(x => x.TenSP != null).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }

        public ActionResult SXG(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP != null).OrderByDescending(x => x.GiaSP).ToPagedList(page ?? 1, 12);
            return View("ProductsList", model);
        }
        public ActionResult HT24(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP != null).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 24);
            return View("ProductsList", model);
        }
        public ActionResult HT36(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP != null).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 36);
            return View("ProductsList", model);
        }
        public ActionResult HT48(int? page)
        {
            var model = context.spMois.Where(x => x.TenSP != null).OrderByDescending(x => x.TenSP).ToPagedList(page ?? 1, 48);
            return View("ProductsList", model);
        }
    }
}