using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static DOANCOSO.Models.DonHang;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOANCOSO.Models
{
    [MetadataTypeAttribute(typeof(ChiTietDonHangMetadata))]
    public partial class ChiTietDonHang
    {
        internal sealed class ChiTietDonHangMetadata
        {
            [Key]
            [Column(Order = 0)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Display(Name = "Mã Đơn Hàng")]
            public int MaDonHang { get; set; }

            [Key]
            [Column(Order = 1)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Display(Name = "Mã Sách")]
            public int MaSach { get; set; }
            [Display(Name = "Số Lượng")]
            public int? SoLuong { get; set; }

            [StringLength(10)]
            [Display(Name = "Đơn Giá")]
            public int? DonGia { get; set; }
            
        }
    }
}