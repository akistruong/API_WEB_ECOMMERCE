using System;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Type
    {
        public Type()
        {
            SanPhams = new HashSet<SanPham>();
        }
        public string MaSanPham { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }    
        public string Slug { get; set; }    
        public DateTime createdAT { get; set; } = DateTime.Now; 
        public DateTime updatedAT { get; set; } = DateTime.Now;
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
