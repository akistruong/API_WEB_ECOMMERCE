using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Size
    {
        public Size()
        {
            SanPhams= new HashSet<SanPham>();   
        }

        public string Id { get; set; }
        public string Size1 { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
        
    }
}
