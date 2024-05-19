using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public HomeController(ShoesEcommereContext context)
        {
            _context = context;
        }
        //[HttpGet("ProductByBrand")]
        //public async Task<IActionResult>  ()
        //{
        //    try
        //    {
        //        var res  = _context.Types.Include(x => x.SanPhams).ThenInclude(x => x.ChiTietHinhAnhs).
        //               ThenInclude(x => x.IdHinhAnhNavigation).Take(8);
        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);  
        //    }
        //}

        
    }
}
