using API_DSCS2_WEBBANGIAY.Models;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public CartController(ShoesEcommereContext context)
        {
            _context = context;
        }
        private void testFunc()
        {
            var ha = new HinhAnh() { FileName = "TEST" };
            _context.HinhAnhs.Add(ha);
            _context.SaveChanges();
        }
        [HttpPost]
        public async Task<IActionResult> CheckCart(PhieuNhapXuat body)
        {
            try
            {
                foreach (var item in body.ChiTietNhapXuats)
                {
                    var product = _context.SanPhams.FirstOrDefault(x => x.MaSanPham.Trim() == item.MaSanPham.Trim());
                    if (product is null)
                    {
                        body.ChiTietNhapXuats.Remove(item);
                    }
                    else
                    {
                        if (item.DonGia != product.GiaBanLe)
                        {
                            item.DonGia = (decimal)product.GiaBanLe;
                            item.SanPhamNavigation = product;
                            item.ThanhTien = item.DonGia * item.SoLuong;
                        }
                    }
                  
                }
                body.TienDaGiam = 0;
                body.CouponCode = ""; ;
                body.CouponNavigation = null;
                body.ThanhTien =body.ChiTietNhapXuats.Sum(x=>x?.ThanhTien??0);
                body.TongSoLuong = body.ChiTietNhapXuats.Sum(x => x?.SoLuong ?? 0);
                return Ok(body);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
    }
}
