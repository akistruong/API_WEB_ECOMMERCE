using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class  Branchs
    {
        public Branchs()
        {
            KhoHangs = new HashSet<ChiNhanh_SanPham>();
            PhieuNhapXuats = new HashSet<PhieuNhapXuat>();
            Coupons = new HashSet<Coupon>();
        }

        public int ID { get; set; }
        public string MaChiNhanh { get; set; }
        public string TenChiNhanh { get; set; }
        public int? IDAddress { get; set; }
        public bool? isDefault { get; set; } = false;
        public DiaChi DiaChiNavigation { get; set; }
        public Coupon CouponNavigation { get; set; }
        public virtual ICollection<ChiNhanh_SanPham> KhoHangs { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }

    }
}
