using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Authorize(Roles = "COUPONMNG")]

    public class CouponController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public CouponController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            try
            {
                var coupons = _context.Coupons.OrderByDescending(x=>x.NgayBatDau);
                return Ok(coupons);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{maCoupon}")]
        public async Task<IActionResult> Get(string maCoupon)
        {
            try
            {
                var coupon = _context.Coupons.Include(x=>x.ChiTietCoupons).Include(x=>x.CouponsKhachHang).FirstOrDefault(x => x.MaCoupon == maCoupon);
                return Ok(coupon);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostCoupon(Coupon coupon)
        {
            try
            {
                if(coupon.MaChiNhanh is null || coupon.MaChiNhanh.Length<=0)
                {
                    coupon.MaChiNhanh = null;
                }
                _context.Coupons.Add(coupon);
                _context.SaveChanges();
                return Ok(coupon);
            } catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutCoupon(Coupon coupon)
        {
            try
            {
                _context.Entry(coupon).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(coupon);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{maCoupon}")]
        public async Task<IActionResult> DeleteCoupon(string maCoupon)
        {
            try
            {

                var coupon = _context.Coupons.FirstOrDefault(x=>x.MaCoupon == maCoupon);
                if (coupon is not null)
                {
                    _context.Coupons.Remove(coupon);
                    _context.SaveChanges();
                    return Ok(coupon);
                }
                return NotFound();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPatch("StartApply/{maCoupon}")]
        public async Task<IActionResult> StartCoupon(string maCoupon)
        {
            try
            {
                var coupon = _context.Coupons.FirstOrDefault(x => x.MaCoupon == maCoupon);
                if (coupon is null) return NotFound();
                coupon.trangThai = true;
                _context.Entry(coupon).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPatch("PauseApply/{maCoupon}")]
        public async Task<IActionResult> PauseCoupon(string maCoupon)
        {
            try
            {
                var coupon = _context.Coupons.FirstOrDefault(x => x.MaCoupon == maCoupon);
                if (coupon is null) return NotFound();
                coupon.trangThai = false;
                _context.Entry(coupon).State = EntityState.Modified;
                _context.SaveChanges(); 
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
