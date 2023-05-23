using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCOSO.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DOANCOSO.Identity;
using DOANCOSO.ViewModel;

namespace DOANCOSO.Controllers
{
    public class NguoiDungController : Controller
    {
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        // GET: NguoiDung
       
       
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public ActionResult DangKy(DangKyVM DKvm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(DKvm.MatKhau);

                var user = new AppUser()
                {
                    Email = DKvm.Email,
                    UserName = DKvm.HoTen,
                    PasswordHash = passwdHash,
                    Address = DKvm.DiaChi,
                    Birthday = DKvm.NgaySinh,
                    PhoneNumber = DKvm.DienThoai
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");



            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }


            //[HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(LoginVM lVM)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lVM.HoTen, lVM.MatKhau);

            if(user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                ModelState.AddModelError("myError", "Tên người dùng và mật khẩu không hợp lệ");
                return View();
            }
        }
        
        //Dang Xuat
        public ActionResult DangXuat()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }

       
    }
    }
