using API_DSCS2_WEBBANGIAY.Models;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Models
{
    public class CartItem
    {
        public SanPham items { get; set; }
        public int qty { get; set; }
        public decimal total { get; set; }

        public CartItem(SanPham items, int qty)
        {
            this.items = items;
            this.qty = qty;
            total = items != null ? (decimal)(qty * items.GiaBanLe) : 0;
        }
        public decimal TotalPrice()
        {
            return (qty * total);
        }
    }
}
