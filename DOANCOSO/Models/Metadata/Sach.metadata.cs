using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DOANCOSO.Models
{
    [MetadataTypeAttribute(typeof(SachMetadata))]
    public partial class Sach
    {
        internal sealed class SachMetadata
        {
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            [Display(Name = "Mã Sách")]
            public int MaSach { get; set; }
            [Display(Name = "Tên Sách")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenSach { get; set; }
            [Display(Name = "Giá Bán")]

            public Nullable<decimal> GiaBan { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            [Display(Name = "Mô Tả")]
            public string MoTa { get; set; }
            [Display(Name = "Ảnh Bìa")]
            
            public string AnhBia { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Ngày Cập Nhật")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            [Display(Name = "Số Lượng Tồn")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<int> SoLuongTon { get; set; }
            [Display(Name = "Nhà xuất bản")]
            
            public Nullable<int> MaNXB { get; set; }
            [Display(Name = "Chủ đề")]
            
            public Nullable<int> MaChuDe { get; set; }
            [Display(Name = "Mới")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<int> Moi { get; set; }
        }

    }
}