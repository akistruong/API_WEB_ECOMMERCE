using System;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class PhieuNhapXuat
    {
        public PhieuNhapXuat()
        {
            ChiTietNhapXuats = new HashSet<ChiTietNhapXuat>();
            StarReviewDetails = new HashSet<StarReviewDetail>();
        }

        public int Id { get; set; }
        public int? IDNCC { get; set; }
        public decimal? ThanhTien { get; set; } = 0;
        public string? CouponCode { get; set; } = "";
        public string? LoaiPhieu { get; set; }
        public bool? DaNhapHang { get; set; } = false;
        public bool? DaReview { get; set; } = false;
        public bool? DaThanhToan { get; set; } = false;
        public bool? DaXuatKho { get; set; } = false;
        public bool? DaNhanHang { get; set; } = false;
        public bool? DaVeKho { get; set; } = false;
        public bool? DaTraHang { get; set; } = false;
        public bool? DaHoanTien { get; set; } = false;
        public decimal? TienDaThanhToan { get; set; }
        public decimal? TienDaGiam { get; set; }    
        public string? PhuongThucThanhToan { get; set; }
        public int? ChietKhau { get; set; } = 0;
        public decimal? Phiship { get; set; } = 0;
        public string? idTaiKhoan { get; set; }
        public int? idKH { get; set; }
        public string MaChiNhanh { get; set; }
        public int? IdDiaChi { get; set; }
        public int? TongSoLuong { get; set; } = 0;
        public int? DeliveryStatus { get; set; }
        public int? status { get; set; } = 0;
        public int? steps { get; set; } = 0;
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime? deletedAT { get; set; } = null;

        public virtual TaiKhoan TenTaiKhoanNavigation { get; set; }
        public virtual Coupon CouponNavigation { get; set; }
        public virtual DiaChi DiaChiNavigation { get; set; }
        public virtual KhachHang KhachHangNavigation { get; set; }
        public virtual NCC NhaCungCapNavigation { get; set; }
        public virtual LoaiPhieu LoaiPhieuNavigation { get; set; }
        public virtual ICollection<ChiTietNhapXuat> ChiTietNhapXuats { get; set; }
        public virtual ICollection<StarReviewDetail> StarReviewDetails { get; set; }
        public virtual Branchs KhoHangNavigation { get; set; }
    }
}
