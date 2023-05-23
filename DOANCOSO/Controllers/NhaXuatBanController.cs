using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;
namespace DOANCOSO.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBanPartial
        QuanLyBanSachModel db =new QuanLyBanSachModel();
        public ActionResult NhaXuatBanPartial()
        {
            return PartialView(db.NhaXuatBan.Take(5).OrderBy(n=>n.TenNXB).ToList());
        }
        
        public ViewResult SachTheoNXB(int MaNXB)
        {
            NhaXuatBan nxb = db.NhaXuatBan.SingleOrDefault(n=>n.MaNXB== MaNXB);
            if(nxb ==null) 
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> lstSach = db.Sach.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if(lstSach.Count == 0 ) 
            {
                ViewBag.Sach = "Không có quyển sách nào của NXB này";    
            }
            return View(lstSach);
        }
        
        public ViewResult DanhMucNXB()
        {
            return View(db.NhaXuatBan.ToList());
        }
    }
}
