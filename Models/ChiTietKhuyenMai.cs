namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class ChiTietKhuyenMai
    {
        public string maSanPham { get; set; }
        public int IDDotKhuyenMai { get; set; }
        public int? KieuGiaTri { get; set; } = 0;
        public decimal? GiaTri { get; set; } = 0;
        public decimal? ThanhTien { get; set; } = 0;
        public virtual SanPham SanPhamNavigation { get; set; }
        public virtual KhuyenMai KhuyenMaiNavigation { get; set; }
    }
}
