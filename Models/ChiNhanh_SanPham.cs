namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class ChiNhanh_SanPham
    {
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public string MaChiNhanh { get; set; }
        public int? TonKho { get; set; } = 0;
        public decimal? GiaVon { set; get; } = 0;
        public int? SoLuongTon { set; get; } = 0;
        public int? SoLuongCoTheban { set; get; } = 0;
        public int? SoLuongHangDangVe { set; get; } = 0;
        public int? SoLuongHangDangGiao { set; get; } = 0;
        public virtual SanPham SanPhamNavigation { get; set; }
        public virtual Branchs BranchNavigation        { get; set; }
    }
}
