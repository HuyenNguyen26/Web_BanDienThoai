using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CNWeb_BTL_BanLaNha.Models;

namespace CNWeb_BTL_BanLaNha.Controllers
{
    public class PromotionController : Controller
    {
        // GET: Promotion
        public ActionResult KhuyenMai()
        {
            SalePhone context = new SalePhone();
            var model = context.SANPHAMs.Where(x => x.MaKM != null).ToList();
            return View(model);

        }
    }
}