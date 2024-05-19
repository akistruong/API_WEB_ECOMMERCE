using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    public class VatController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public VatController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vats = _context.Vats;
                return Ok(vats);
            }catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(VAT vat)
        {
            try
            {
                _context.Vats.Add(vat);
                await _context.SaveChangesAsync();
                return Ok(vat);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
