using System;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            ChiTietKhuyenMais = new HashSet<ChiTietKhuyenMai>();    
        }
        public int ID { get; set; }
        public string? TenKhuyenMai { get; set; }
        public string ?MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; } 
        public DateTime? NgayKetThuc { get; set; } 
        public decimal? GiaTriGiamGia { get;set; }
        public int? KieuGiaTri { get; set; } = 0;
        public int? TrangThai { get; set; } = 0;
        public virtual ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }

    }
}
