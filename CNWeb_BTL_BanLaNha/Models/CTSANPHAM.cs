using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNWeb_BTL_BanLaNha.Models
{
    public class CTSANPHAM
    {
        public int MaSP { get; set; }

        public string TenSP { get; set; }

        public string url { get; set; }

        public int GiaSP { get; set; }

        public int MaLoai { get; set; }

        public string TenLoai { get; set; }
        public string MauSac { get; set; }
        public string BoNho { get; set; }
        public string MoTa { get; set; }
    }
}