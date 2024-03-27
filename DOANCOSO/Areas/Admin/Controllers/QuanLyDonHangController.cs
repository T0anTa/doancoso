using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;

namespace DOANCOSO.Areas.Admin.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: Admin/QuanLyDonHang
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        public ActionResult Index()
        {
            return View(db.DonHang.ToList());
        }
        public ActionResult ChiTietDonHang(int maDH)
        {
            var ctdh = db.DonHang.Find(maDH);
            if (ctdh==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            return View(ctdh);
        }
            
        public ActionResult Xoa(int MaDH)
        {
            //lấy ra đối tượng đơn hàng theo mã
            DonHang dh = db.DonHang.SingleOrDefault(n => n.MaDonHang == MaDH);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDH)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.MaDonHang == MaDH);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int maDonHang = dh.MaDonHang;

            // Xóa tất cả các bản ghi ChiTietDonHang có MaDonHang tương ứng
            var chiTietDonHangList = db.ChiTietDonHang.Where(ct => ct.MaDonHang == maDonHang).ToList();
            db.ChiTietDonHang.RemoveRange(chiTietDonHangList);
            db.SaveChanges();
            db.DonHang.Remove(dh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}