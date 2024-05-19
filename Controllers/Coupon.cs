using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Coupon : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public Coupon(ShoesEcommereContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            try
            {
                var coupons = _context.Coupons;
                return Ok(coupons);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{maCoupon}")]
        public async Task<IActionResult> Gets(string maCoupon)
        {
            try
            {
                var coupon = _context.Coupons.FirstOrDefault(x => x.MaCoupon == maCoupon);
                return Ok(coupon);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
