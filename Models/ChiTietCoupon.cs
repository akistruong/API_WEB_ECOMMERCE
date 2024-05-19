namespace API_DSCS2_WEBBANGIAY.Models
{
    public class ChiTietCoupon
    {
        public string MaCoupon { get; set; }

        public string? MaSanPhamX { get; set; }
        public string? MaSanPhamY { get; set; }
        public string imgX { get; set; } = "";
        public string imgY { get; set; } = "";

        public string LoaiSanPham { get; set; } //VD : SanPhamA || SanPhamB
        public virtual SanPham SanPhamXNavigation { get; set; }
        public virtual SanPham SanPhamYNavigation { get; set; }
        public virtual Coupon CouponNavigation { get; set; }    

    }
}
