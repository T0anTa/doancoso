using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOANCOSO.ViewModel
{
    public class LoginVM
    {
        [Display(Name = "Tên Người Dùng")]
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public String HoTen { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
    }
}