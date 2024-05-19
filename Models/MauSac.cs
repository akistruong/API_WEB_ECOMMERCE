using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class MauSac
    {
        public MauSac()
        {
            ChiTietHinhAnhs = new HashSet<ChiTietHinhAnh>();
            SanPhams = new HashSet<SanPham>();
        }

        public string MaMau { get; set; }
        public string TenMau { get; set; }
        public virtual ICollection<ChiTietHinhAnh> ChiTietHinhAnhs { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
