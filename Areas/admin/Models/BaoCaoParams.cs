using System;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Models
{
    public class BaoCaoParams
    {
        public string? maChiNhanh { get; set; }
        public string Type { get; set; }    
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
