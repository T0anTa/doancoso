using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;
namespace DOANCOSO.Controllers
{
    public class TimKiemController : Controller
    {
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f)           
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<Sach> lstKQTK = db.Sach.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            if(lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK);
        }
    }
}