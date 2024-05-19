using System;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class ChiTietNhapXuat
    {
        public ChiTietNhapXuat()
        {
        }
        public string MaSanPham { get; set; }
        public int Id { get; set; }
        public int IDPN { get; set; }
        public int SoLuong { get; set; } = 0;
        public decimal ThanhTien { get; set; } = 0;
        public decimal DonGia { get; set; } = 0;
        public string DVT { get; set; } = "";
        public string? img { get; set; } = "";
        public string TenPhieu { get; set; } = "";
        public DateTime createdAT { get; set; } = DateTime.Now;
        public DateTime updatedAT { get; set; } = DateTime.Now;
        public DateTime? deletedAT { get; set; } = null;
        public virtual SanPham SanPhamNavigation { get; set; }
        public virtual PhieuNhapXuat PhieuNhapXuatNavigation { get; set; }
    }
}
