using System;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class RoomMessage
    {
        public string MaSanPham { get; set; }

        public int ID { get; set; }
        public DateTime createdAT { get; set; }
        public int IDSanPham { get; set; }
        public string UserID { get; set; }
        public int MessageID { get; set; }
        public virtual TaiKhoan TaiKhoanNavigation { get; set; }
        public virtual SanPham SanPhamNavigation { get; set; }
        public virtual Message MessageNavigation { get; set; }
    }
}
