using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class ReviewStar
    {
        public ReviewStar()
        {
            StarReviewDetails = new HashSet<StarReviewDetail>();
        }

        public int Id { get; set; }
        public int? total { get; set; } = 0;
        public int? MotSao { get; set; } = 0;
        public int? HaiSao { get; set; } = 0;
        public int? BaSao { get; set; } = 0;
        public int? BonSao { get; set; } = 0;
        public int? NamSao { get; set; } = 0;
        public double? Avr { get; set; } = 0;

        public virtual ICollection<StarReviewDetail> StarReviewDetails { get; set; }
        public virtual SanPham SanPhamNavigation { get; set; }

    }
}
