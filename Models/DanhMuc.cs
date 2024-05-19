using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            DanhMucDetails = new HashSet<DanhMucDetails>();
        }

        public int Id { get; set; }
        public string Slug { get; set; }
        public string TenDanhMuc { get; set; }
        public int? ParentCategoryID { get; set; }
        public int? ViewCount { get; set; } = 0;
        public virtual ICollection<DanhMucDetails> DanhMucDetails { get; set; }
    }
}
