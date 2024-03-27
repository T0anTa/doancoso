using DOANCOSO.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANCOSO.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tạo list giỏ hàng (sesstionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
            }
            //Lấy ra Sesstion giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sách này đã tồn tại trong sesstioin(giohang) chưa
            GioHang sp = lstGioHang.Find(n => n.iMaSach == iMaSach);
            if (sp == null)
            {
                sp = new GioHang(iMaSach);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏi hàng
        public ActionResult CapNhatGioHang(int iMaSP, int newAmount)
        {
            // tìm carditem muon sua
            List<GioHang> ShoppingCart = Session["GioHang"] as List<GioHang>;
            GioHang EditSoLuong = ShoppingCart.FirstOrDefault(m => m.iMaSach == iMaSP);
            if (EditSoLuong != null)
            {
                EditSoLuong.iSoLuong = newAmount;
            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {
            //Kiemtr masp
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sach == null)
            {
                Response.StatusCode = 404;
            }
            //Lấy giỏ hàng ra từ sesstion
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong sesstion["GioHang"]
            GioHang sp = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            //Nếu mà tồn tại thì ta cho sửa số lượng
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSach == sp.iMaSach);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");

        }
        //Xây fựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tinh tổng sô lượng

        private int TongSoluong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền

        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);

            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoluong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoluong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        //Xây dụng 1 view cho người dùng edit giỏ hàng
        public ActionResult SuaGioHang()
        {

            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng nhập
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Kiểm tra giỏ hàng

            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn đặt hàng
            DonHang ddh = new DonHang();
            string userId = User.Identity.GetUserId();            
            
            ddh.UserId = userId;
            ddh.NgayDat = DateTime.Now;
            ddh.PhuongThucThanhToan = "COD";
            db.DonHang.Add(ddh);
            db.SaveChanges();

            // Lấy giỏ hàng từ session
            List<GioHang> gioHang = (List<GioHang>)Session["GioHang"];

            //Thêm chi tiết đơn hàng
            foreach (var item in gioHang)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaSach = item.iMaSach;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = item.dDonGia.ToString();
                db.ChiTietDonHang.Add(ctDH);

            }
            db.SaveChanges();
            Session["GioHang"] = null;
            // Hiển thị thông tin đơn hàng
            ViewBag.MaDH = ddh.MaDonHang;
            ViewBag.NgayDH = ddh.NgayDat;
            ViewBag.PhuongThucThanhToan = ddh.PhuongThucThanhToan;
            ViewBag.TongTien = gioHang.Sum(item => item.iSoLuong * item.dDonGia);
            ViewBag.SachItems = gioHang;
            
            return View("ThongTinDonHang");
           
        }
       
    }
}