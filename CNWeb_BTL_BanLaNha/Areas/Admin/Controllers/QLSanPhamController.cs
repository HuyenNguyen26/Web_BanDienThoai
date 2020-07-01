using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb_BTL_BanLaNha.Models;
using PagedList;
using System.IO;
namespace CNWeb_BTL_BanLaNha.Areas.Admin.Controllers
{
    public class QLSanPhamController : Controller
    {
        SalePhone db = new SalePhone();
        // GET: Admin/QLSanPham
        public ActionResult Index(int page = 1,int pageSize=10 )
        {
            //if (Session["username"] == null) return RedirectToAction("../HomeAdmin/Login");
            //else
            //{
                List<LOAISANPHAM> cateLoai = db.LOAISANPHAMs.ToList();
                ViewBag.maloai = cateLoai;

               
                var lst = db.SANPHAMs.SqlQuery("select" + "*from SANPHAM").ToList<SANPHAM>();

                var model = lst.ToPagedList(page, pageSize);
                return View(model);
            //}
        }

        public ActionResult Create()
        {
            //if (Session["username"] == null) return RedirectToAction("../Admin/Login");
            //else
            //{
                List<LOAISANPHAM> listloaisp = db.LOAISANPHAMs.ToList();
                SelectList catelistloaisp = new SelectList(listloaisp, "maloai", "tenloai");
                ViewBag.maloai = catelistloaisp;


                return View();
            //}
        }

        [HttpPost]
        public ActionResult Create(SANPHAM sp, HttpPostedFileBase hinhanh)
        {
            if (hinhanh != null && hinhanh.ContentLength > 0)
            {
                var tenanh = Path.GetFileName(hinhanh.FileName);
                var link = Path.Combine(Server.MapPath("~/Content/images/product/Phone/"), tenanh);

                sp.url = tenanh;
                hinhanh.SaveAs(link);
            }
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(sp);

        }

        public ActionResult Edit(int MaSP)
        {
            //if (Session["username"] == null) return RedirectToAction("../Admin/Login");
            //else
            //{
                var list = db.SANPHAMs.Find(MaSP);

                List<LOAISANPHAM> listloaisp = db.LOAISANPHAMs.ToList();
                SelectList catelistloai = new SelectList(listloaisp, "maloai", "tenloai");
                ViewBag.maloai = catelistloai;

                return View(list);
            //}
        }

        [HttpPost]
        public ActionResult Edit(SANPHAM sp, HttpPostedFileBase hinhanh)
        {

            SANPHAM sps = db.SANPHAMs.Find(sp.MaSP);
            if (sps != null)
            {
                if (hinhanh != null && hinhanh.ContentLength > 0)
                {
                    var tenanh = Path.GetFileName(hinhanh.FileName);
                    var link = Path.Combine(Server.MapPath("~Content/images/product/Phone/"), tenanh);

                    sp.url = tenanh;
                    hinhanh.SaveAs(link);
                }
                if (ModelState.IsValid)
                {
                    sps.TenSP = sp.TenSP;
                    sps.MauSac = sp.MauSac;
                    sps.MaLoai = sp.MaLoai;
                    sps.BoNho = sp.BoNho;
                    sps.GiaSP = sp.GiaSP;
                    sps.url = sp.url;
                    sps.MoTa = sp.MoTa;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else return View(sps);
        }

        public ActionResult Delete(int MaSP)
        {
            //if (Session["username"] == null) return RedirectToAction("../Admin/Login");
            //else
            //{
                var list = db.SANPHAMs.Find(MaSP);
                return View(list);
            //}
        }

        [HttpPost]
        public ActionResult Delete(SANPHAM sp)
        {
            SANPHAM spx = db.SANPHAMs.Find(sp.MaSP);
            if (sp != null)
            {
                db.SANPHAMs.Remove(spx);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Search(FormCollection f, int page = 1, int pageSize = 10)
        {
            //if (Session["username"] == null) return RedirectToAction("../Admin/Login");
            //else
            //{
                string tensp = f["txtTenSP"].ToString();
                ViewBag.tensp = tensp;

                List<LOAISANPHAM> cateLoaisp = db.LOAISANPHAMs.ToList();
                ViewBag.maloai = cateLoaisp;

                string tenloai = f["maloai"].ToString();
                ViewBag.tenloai = tenloai;

                string tugia = f["txtTuGia"].ToString();
                ViewBag.TuGia = tugia;

                string dengia = f["txtDenGia"].ToString();
                ViewBag.DenGia = dengia;

                if (tugia == "")
                {
                    tugia = "0";
                }
                if (dengia == "")
                {
                    dengia = "100000000000";
                }

                string query = "select MaSP, TenSP, url, MauSac, BoNho, GiaSP, SANPHAM.MaLoai, LOAISANPHAM.TenLoai from SANPHAM, LOAISANPHAM" +
                    " where SANPHAM.MaLoai=LOAISANPHAM.MaLoai and TenSP like N'%" + tensp + "%' and TenLoai like N'%" + tenloai + "%' and GiaSP > " + tugia + " and GiaSP <" + dengia;

                var lst = db.Database.SqlQuery<CTSANPHAM>(query).ToList().ToPagedList(page, pageSize);

                return View(lst);
            //}
        }
    }
}