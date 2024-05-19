using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class ChiTietBST
    {
        public ChiTietBST()
        {
          
        }

        public int IDBST { get; set; }
        public string MaSanPham { get; set; } = "";
        public string img { get; set; } = "";
        public virtual SanPham SanPhamNavigation { get; set; }
        public virtual BoSuuTap BSTNavigation { get; set; }
    }
}
