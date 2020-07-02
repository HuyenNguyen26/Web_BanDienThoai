using CNWeb_BTL_BanLaNha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb_BTL_BanLaNha.Areas.Admin;
namespace CNWeb_BTL_BanLaNha.Controllers
{
    public class AccountController : Controller
    {
        SalePhone context = new SalePhone();
        // GET: Account
        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account acc)
        {
            var result = context.TAIKHOANs.Where(a => a.MaTK.Equals(acc.TK) &&
                                                       a.MatKhau.Equals(acc.MatKhau)).FirstOrDefault();
            if (result != null)
            {
                if (result.is_ADMIN == "1")
                {
                    return RedirectToAction("HomeAdmin", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                //Section["Login"] = acc;

            }

            return RedirectToAction("Index", "Home");
        }

    }

}