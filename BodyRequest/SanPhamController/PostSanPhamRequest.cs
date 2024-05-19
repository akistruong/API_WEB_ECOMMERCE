using API_DSCS2_WEBBANGIAY.Models;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.BodyRequest.SanPhamController
{
    public class PostSanPhamRequest
    {
        public bool? isVAT { get; set; } = false;
        public SanPham? product { get; set; }
        public string? maSP { get; set; }   
        public List<SanPham>? productVersions { set; get; }
    }
}
