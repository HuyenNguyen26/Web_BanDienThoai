using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CNWeb_BTL_BanLaNha.Models;

namespace CNWeb_BTL_BanLaNha.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin

        SalePhone db = new SalePhone();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TimKiem(int search)
        {
            var model = db.HOADONs.Where(x => x.MaHD == search).Single();
            return View("Index", model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            string us = Request.Form["us"];
            string mk = Request.Form["mk"];
            var result = db.TAIKHOANs.Where(p => p.TenTK == us && p.MatKhau == mk);
            if (result != null)
            {

                Session["username"] = us;
                return RedirectToAction("List");

            }
            else
            {
                TempData["msg"] = "Đăng nhập không thành công !!";
                return RedirectToAction("Login");
            }

        }


    }
}