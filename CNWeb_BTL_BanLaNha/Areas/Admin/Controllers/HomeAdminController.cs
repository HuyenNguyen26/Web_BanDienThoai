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

        SalePhone context = new SalePhone();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TimKiem(int search)
        {
            var model = context.HOADONs.Where(x => x.MaHD == search).Single();
            return View("Index", model);
        }
    }
}