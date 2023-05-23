using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;

namespace DOANCOSO.Areas.Admin.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: Admin/QuanLySanPham
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        public ActionResult Index()
        {
            return View(db.Sach.ToList());
        }

        //Thêm Mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vòa dropdownlist
            ViewBag.MaChuDe = new SelectList(db.ChuDe.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(Sach sach, HttpPostedFileBase fileUpload)
        {

            //Đưa dữ liệu vòa dropdownlist
            ViewBag.MaChuDe = new SelectList(db.ChuDe.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            //Kiểm tra đường dẫn ảnh bìa
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }



            //Thêm dữ liệu vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/imagesProducts"), fileName);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                db.Sach.Add(sach);
                db.SaveChanges();
            }
            return View();
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            //Lấy ra đối tượng sách theo mã
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đưa dữ liệu vòa dropdownlist
            ViewBag.MaChuDe = new SelectList(db.ChuDe.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View(sach);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(Sach sach)
        {




            //Thêm dữ liệu vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Đưa dữ liệu vòa dropdownlist
            ViewBag.MaChuDe = new SelectList(db.ChuDe.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");

            return View();
        }

        public ActionResult HienThi(int MaSach)
        {

            //Lấy ra đối tượng sách theo mã
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaSach)
        {
            //lấy ra đói tượng sách theo mã
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSach)
        {
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Sach.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}