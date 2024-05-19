using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class VAT
    {
        public VAT()
        {
            SanPhams = new HashSet<SanPham>();
        }
        public string MaSanPham { get; set; }

        public int ID { get; set; }
        public string Name { get; set; } = "";
        public int giaTriThueDauVao { get; set; } = 0;
        public int giaTriThueDauRa { get; set; } = 0;
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
