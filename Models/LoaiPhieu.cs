using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class LoaiPhieu
    {
        public LoaiPhieu()
        {
            PhieuNhapXuats =new HashSet<PhieuNhapXuat>();
        }

        public string MaPhieu { get; set; }
        public string TenPhieu { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }

    }
}
