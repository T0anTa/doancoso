using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;

namespace DOANCOSO.Controllers
{
    public class HomeController : Controller
    {
        //
        //GET: /Home/
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        public ActionResult Index()
        {
            return View(db.Sach.Where(n=>n.Moi == 0).ToList());
        }
       


    }
}