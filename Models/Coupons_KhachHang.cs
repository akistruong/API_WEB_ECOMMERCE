namespace API_DSCS2_WEBBANGIAY.Models
{
    public class Coupons_KhachHang
    {
        public string MaCoupon { get; set; }
        public decimal SoLanDaMua { get; set; } = 0;
        public decimal TongTienThanhToan { get; set; } = 0;
        public string TenTaiKhoan { get; set; }
        public virtual TaiKhoan TaiKhoanNavigation { get; set; }
        public virtual Coupon CouponNavigation { get; set; }
    }
}
