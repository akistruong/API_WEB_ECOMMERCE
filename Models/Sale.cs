using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Sale
    {
        public Sale()
        {
            //ChiTietSales = new HashSet<ChiTietSale>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Dsc { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? NgayBatDat { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int Giamgia { get; set; }

        //public virtual ICollection<ChiTietSale> ChiTietSales { get; set; }
    }
}
