using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;
namespace DOANCOSO.Controllers
{
    public class SachController : Controller
    {
        // GET: /SachmoiPartial
        QuanLyBanSachModel db =new QuanLyBanSachModel();
        public PartialViewResult SachMoiPartial()
        {
            var lstSachMoi = db.Sach.Where(n => n.Moi == 0).Take(3).ToList();
            return PartialView(lstSachMoi);
        }
        
        public ViewResult XemChiTiet(int MaSach=0)
        {
            Sach sach=db.Sach.SingleOrDefault(n=>n.MaSach == MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
    }
}