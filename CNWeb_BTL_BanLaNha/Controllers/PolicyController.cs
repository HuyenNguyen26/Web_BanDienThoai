using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNWeb_BTL_BanLaNha.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult StandardPolicy()
        {
            return View();
        }
        public ActionResult ExchangePolicy()
        {
            return View();
        }

        public ActionResult Guidlines()
        {
            return View();
        }
    }
}