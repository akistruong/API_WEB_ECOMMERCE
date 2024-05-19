using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class DonhangModel
    {
        public KhachHang? KhachHang { get; set; } //bỏ   
        public DiaChi? DiaChi { get; set; }
        public string? BankCode { get; set; }
    }
}
