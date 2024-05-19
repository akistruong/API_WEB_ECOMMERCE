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
    [Authorize(Roles = "PNMANAGER")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class ChiTietNhapHang : ControllerBase
    {
        private readonly ShoesEcommereContext _context;
        public ChiTietNhapHang(ShoesEcommereContext context)
        {
            this._context = context;
        }
        
        [HttpGet("search/{s}")]
        public async Task<IActionResult> searchProducts(string s)
        {
            try
            {
                var items = _context.SanPhams
                    .Include(x => x.ChiTietHinhAnhs)
                    .ThenInclude(x => x.IdHinhAnhNavigation);
                return Ok(items);
            }catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
       
    }
}
