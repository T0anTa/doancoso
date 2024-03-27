using DOANCOSO.Identity;
using DOANCOSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANCOSO.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        // GET: Admin/QuanLyKhachHang
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }
        public ActionResult Xoa(string MaKH)
        {
            //lấy ra đối tượng đơn hàng theo mã
            AspNetUsers kh = db.AspNetUsers.SingleOrDefault(n=>n.Id == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(String MaKH)
        {
            AspNetUsers kh = db.AspNetUsers.SingleOrDefault(n => n.Id == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            string maKhachHang = kh.Id;

            // Xóa tất cả các bản ghi ChiTietDonHang có MaDonHang tương ứng
            var chiTietDonHangList = db.ChiTietDonHang.Where(ct => kh.Id == maKhachHang).ToList();
            db.ChiTietDonHang.RemoveRange(chiTietDonHangList);
            db.SaveChanges();
            db.AspNetUsers.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}