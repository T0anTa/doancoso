﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DOANCOSO.ViewModel
{
    public class ChiTietDonHangVM
    {
        [Display(Name = "Mã Đơn Hàng")]
        public int MaDH { get; set; }
        [Display(Name = "Ngày Đặt Hàng")]
        public DateTime NgayDH { get; set; }
        [Display(Name = "Tổng Tiền")]
        public decimal TongTien { get; set; }
        public List<OrderItemVM> DSDH { get; set; }
    }

    public class OrderItemVM
    {
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
    }

}