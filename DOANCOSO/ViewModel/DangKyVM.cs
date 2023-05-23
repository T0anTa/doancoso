using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DOANCOSO.ViewModel
{
    public class DangKyVM
    {
        [Display(Name = "Mã Khách Hàng")]
        public int MaKH { get; set; }
        [Display(Name = "Tên Người Dùng")]
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public String HoTen { get; set; }
        [Display(Name = "Ngày Sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
     
        [Required(ErrorMessage ="Mật khẩu không được để trống.")]
        [Display(Name ="Mật Khẩu")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage ="Nhập lại mật khẩu không được để trống.")]
        [Compare("MatKhau", ErrorMessage ="Mật Khẩu và Nhập Lại Mật Khẩu không khớp")]
        [Display(Name ="Nhập Lại Mật Khẩu")]
        public string NhapLaiMatKhau { get; set; } 
        public string Email { get; set; }
        public string DiaChi { get; set; }
        [Display(Name = "Điện Thoại")]
        public string DienThoai { get; set; }
        [Display(Name = "Giới Tính")]
        public string GioiTinh { get; set; }



    }
}