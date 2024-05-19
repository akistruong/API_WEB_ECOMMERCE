using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            //ChiTietSales = new HashSet<ChiTietSale>();
            ReviewStars = new HashSet<ReviewStar>();
            DanhMucDetails = new HashSet<DanhMucDetails>();
            ChiTietHinhAnhs = new HashSet<ChiTietHinhAnh>();
            RoomMessages = new HashSet<RoomMessage>();
            SanPhams = new HashSet<SanPham>();
            KhoHangs = new HashSet<ChiNhanh_SanPham>();
            ChiTietNhapXuats= new HashSet<ChiTietNhapXuat>();
            ChiTietCouponsX = new HashSet<ChiTietCoupon>();
            ChiTietCouponsY = new HashSet<ChiTietCoupon>();
            ChiTietBSTs = new HashSet<ChiTietBST>();
            ChiTietKhuyenMais = new HashSet<ChiTietKhuyenMai>();
        }

        //public string MaSanPham { get; set; }
        public int Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string? ParentID { get; set; }
        public string Slug { get; set; } = "";
        public int? GiamGia { get; set; }=0;    
        public decimal? TienDaGiam { get; set; }=0;    
        public bool? isSale { get; set; }=false;    
        public decimal? GiaNhap { set; get; } = 0;
        public decimal? GiaBanLe { set; get; } = 0;
        public decimal? GiaBanSi { set; get; } = 0;
        public int? SoLuongTon { set; get; } = 0;
        public int? SoLuongCoTheban { set; get; } = 0;
        public int? SoLuongDaBan { set; get; } = 0;
        public decimal? GiaVon { set; get; } = 0;
        public string? Mota { get; set; } = "";
        public int? ViewCount { get; set; } = 0;
        public string? MotaChiTiet { get; set; }
        public int? IDType { get; set; } = null;
        public int? IDBrand { get; set; } = null;
        public int? IDVat { get; set; } = null;
        public string? IDSize { get; set; } = null;
        public string? IDColor { get; set; } = null;
        public int? ReviewID { get; set; } = null;
        public int? IDAnh { get; set; } = null;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Type TypeNavigation { get; set; }
        public virtual Brand BrandNavigation { get; set; }
        public virtual VAT VatNavigation { get; set; }
        public virtual Size SizeNavigation { get; set; }
        public virtual MauSac MauSacNavigation { get; set; }
        public virtual HinhAnh HinhAnhNavigation { get; set; }
        public virtual SanPham SanPhamNavigation { get; set; }
        public virtual ReviewStar StarReviewNavigation { get; set; }
        //public virtual ICollection<ChiTietSale> ChiTietSales { get; set; }
        public virtual ICollection<ReviewStar> ReviewStars { get; set; }
        public virtual ICollection<DanhMucDetails> DanhMucDetails { get; set; }
        public virtual ICollection<ChiTietHinhAnh> ChiTietHinhAnhs { get; set; }
        public virtual ICollection<ChiTietNhapXuat> ChiTietNhapXuats { get; set; }
        public virtual ICollection<SanPham>SanPhams { get; set; }
        public virtual ICollection<RoomMessage> RoomMessages { get; set; }
        public virtual ICollection<ChiNhanh_SanPham> KhoHangs { get; set; }
        public virtual ICollection<ChiTietCoupon> ChiTietCouponsX{ get; set; }
        public virtual ICollection<ChiTietCoupon> ChiTietCouponsY{ get; set; }
        public virtual ICollection<ChiTietBST> ChiTietBSTs { get; set; }
        public virtual ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        
        public string VND(decimal money)
        {
            var format = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            return String.Format(format, "{0:c0}", money);
        }
    }
}
