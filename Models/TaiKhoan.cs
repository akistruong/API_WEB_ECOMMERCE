using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            PhieuNhapXuats = new HashSet<PhieuNhapXuat>();
            DiaChis = new HashSet<DiaChi>();
            Messages = new HashSet<Message>();
            RoomMessages = new HashSet<RoomMessage>();
            CouponsKhachHangs = new HashSet<Coupons_KhachHang>();
        }
        public string? Avatar { get; set; } = "";
        public string? TenHienThi { get; set; } = "";
        public string? RoleGroup { get; set; } = "";
        public string TenTaiKhoan { get; set; }
        public string TypeAccount { get; set; }
        public string MatKhau { get; set; }
        public bool isBlocked { get; set; } = false;
        public string Email { get; set; }
        public int? Role { get; set; }
        public int? idKH { get; set; }
        public int? SoLanMuaHang { get; set; } = 0;
        public decimal? TienThanhToan { get; set; } = 0;
        public bool? Gioitinh { get; set; }
        public bool? isActive { get; set; } = false;
        public int? addressDefault { get; set; } 
        public virtual KhachHang SdtKhNavigation { get; set; }
        public virtual RoleGroup RoleGroupNavigation { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }
        public virtual ICollection<DiaChi> DiaChis { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<RoomMessage> RoomMessages { get; set; }
        public virtual ICollection<Coupons_KhachHang> CouponsKhachHangs { get; set; }
    }
}
