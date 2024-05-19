using System;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Brand
    {
        public Brand()
        {
            SanPhams = new HashSet<SanPham>();
        }
        public string MaSanPham { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }    
        public string Slug { get; set; }    
        public string LogoLink { get; set; }    
        public DateTime createdAT { get; set; } = DateTime.Now; 
        public DateTime updatedAT { get; set; } = DateTime.Now;
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
