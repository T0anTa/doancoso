using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOANCOSO.Models
{
    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang
        {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã Đơn Hàng")]
            public int MaDonHang { get; set; }
            [Display(Name = "Ngày Đặt")]
            public DateTime? NgayDat { get; set; }
             

            [Required]
            [StringLength(128)]
            [Display(Name = "Mã Khách Hàng")]
            public string UserId { get; set; }
            [StringLength(20)]
            [Display(Name = "Phương Thức Thanh Toán")]
            public string PhuongThucThanhToan { get; set; }
            

        }
        
    }
}