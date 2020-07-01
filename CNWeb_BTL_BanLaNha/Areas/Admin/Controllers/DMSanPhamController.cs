using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb_BTL_BanLaNha.Models;
using PagedList;
using PagedList.Mvc;
namespace CNWeb_BTL_BanLaNha.Areas.Admin.Controllers
{
    public class DMSanPhamController : Controller
    {
        SalePhone db = new SalePhone();
        // GET: Admin/DMSanPham
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            //if (Session["username"] == null) return RedirectToAction("./Account/Login");
            //else
            //{
                var list = db.LOAISANPHAMs.SqlQuery("Select * from LOAISANPHAM").ToList<LOAISANPHAM>();
                var model = list.ToPagedList(page, pageSize);
                return View(model);
            //}
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LOAISANPHAM loai)
        {
            db.LOAISANPHAMs.Add(loai);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int MaLoai)
        {
            //if (Session["username"] == null) return RedirectToAction("../Admin/Login");
            //else
            //{
                var list = db.LOAISANPHAMs.Find(MaLoai);
                return View(list);
            //}
        }

        [HttpPost]
        public ActionResult Edit(LOAISANPHAM loai)
        {
            LOAISANPHAM loaisp = db.LOAISANPHAMs.Find(loai.MaLoai);
            if (loai != null)
            {
                loaisp.TenLoai = loai.TenLoai;
                loaisp.MaLoai = loai.MaLoai;


                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int MaLoai)
        {
            //if (Session["username"] == null) return RedirectToAction("../Admin/Login");
            //else
            //{
                var list = db.LOAISANPHAMs.Find(MaLoai);
                return View(list);
            //}
        }

        [HttpPost]
        public ActionResult Delete(LOAISANPHAM loai)
        {
            LOAISANPHAM loaisp = db.LOAISANPHAMs.Find(loai.MaLoai);
            if (loai != null)
            {
                db.LOAISANPHAMs.Remove(loaisp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}