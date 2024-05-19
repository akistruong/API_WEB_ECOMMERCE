using System;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            PhieuNhapXuats = new HashSet<PhieuNhapXuat>();
            ChiTietCoupons = new HashSet<ChiTietCoupon>();
            CouponsKhachHang = new HashSet<Coupons_KhachHang>();
        }

        public string MaCoupon { get; set; }
        public string TenCoupon { get; set; } = "";
        public string? MaChiNhanh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLanDung { get; set; } = 0;
        public decimal GiaTri { get; set; } = 0;
        public bool trangThai { get; set; } = false;
        public int SoLuongSPToiThieu { get; set; } = 0;
        public int SoLuong { get; set; } = 0;
        public decimal GiaTriDonHangToiThieu { get; set; } = 0;
        public int LoaiKhuyenMai { get; set; } 
        public int NhomDoiTuong { get; set; }
        public string MoTa { get; set; } = "";
        public virtual Branchs ChiNhanhNavigation { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }
        public virtual ICollection<ChiTietCoupon> ChiTietCoupons { get; set; }
        public virtual ICollection<Coupons_KhachHang> CouponsKhachHang { get; set; }

    }
}
