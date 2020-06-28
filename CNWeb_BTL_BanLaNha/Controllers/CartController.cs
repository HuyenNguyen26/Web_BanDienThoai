using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CNWeb_BTL_BanLaNha.Models;
using CNWeb_BTL_BanLaNha.Views.Classs;
namespace CNWeb_BTL_BanLaNha.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        SalePhone context = new SalePhone();
        public ActionResult Cart()
        {
            //List<CartItem> GioHang = Session["giohang"] as List<CartItem>;
            var GioHang = (Cart)Session["giohang"];
            var list = new List<CartItem>();
            return View(GioHang);
        }
        public ActionResult ThemVaoGio(int MaSP)
        {
            var sanpham = context.spMois.Find(MaSP);
            var GioHang = (Cart)Session["giohang"];
            if (GioHang != null)
            {
                GioHang.AddItem(sanpham, 1);
                Session["giohang"] = GioHang;

            }
            else
            {
                GioHang = new Cart();
                GioHang.AddItem(sanpham, 1);
                Session["giohang"] = GioHang;
            }
            return RedirectToAction("Cart");
        }
        public ActionResult CapNhatGio(int MaSP, int SL)
        {
            var GioHang = (Cart)Session["giohang"];
            if (GioHang != null)
            {
                var product = context.spMois.Find(MaSP);
                GioHang.UpdateItem(product, SL);
                Session["giohang"] = GioHang;
            }
            return RedirectToAction("Cart");
        }
        public ActionResult XoaKhoiGio(int MaSP)
        {
            var GioHang = (Cart)Session["giohang"];
            var product = context.spMois.Find(MaSP);
            if (GioHang != null)
            {
                GioHang.RemoveLine(product);
                Session["giohang"] = GioHang;
            } 
                return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult DatHang(HOADON model)
        {
            var GioHang = (Cart)Session["giohang"];
            model.NgayLapHD = DateTime.Now;
            //model.TongTien = GioHang.ComputeTotalValue();
            context.HOADONs.Add(model);
            context.SaveChanges();
            foreach(var it in GioHang.cart)
            {
                CTHOADON obj = new CTHOADON();
                obj.MaHD = model.MaHD;
                obj.MaSP = it.sp.MaSP;
                obj.GiaMua = it.sp.GiaSP;
                obj.SLMua = it.Quantity;

                context.CTHOADONs.Add(obj);
                context.SaveChanges();
            }
            GioHang.Clear();
            Session["giohang"] = GioHang;
            return View("Cart");
        }
    }
}