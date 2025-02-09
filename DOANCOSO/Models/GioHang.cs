﻿using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOANCOSO.Models
{
    public class GioHang
    {
        QuanLyBanSachModel db = new QuanLyBanSachModel();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        
        public int iSoLuong { get; set; }
        

        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo giỏ hàng
        public GioHang(int MaSach) 
        {
            iMaSach = MaSach;
            Sach sach = db.Sach.Single(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}