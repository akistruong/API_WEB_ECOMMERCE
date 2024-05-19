using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class HinhAnh
    {
        public HinhAnh()
        {            ChiTietHinhAnhs = new HashSet<ChiTietHinhAnh>();
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<ChiTietHinhAnh> ChiTietHinhAnhs { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
