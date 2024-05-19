namespace API_DSCS2_WEBBANGIAY.Models
{
    public class StarReviewDetail
    {
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public int IDDonHang { get; set; }
        public int StarReviewID { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
        public bool isDisplay { get; set; } = true;
        public virtual SanPham MasanPhamNavigation { get; set; }
        public virtual ReviewStar ReviewStarNavigation { get; set; }
        public virtual PhieuNhapXuat HoaDonNavigation { get; set; }
    }
}
