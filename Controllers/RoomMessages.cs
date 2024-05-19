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
    public class RoomMessages : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public RoomMessages(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet("{maSP}")]
        public async Task<IActionResult> Get(string maSP)
        {
            try
            {
                //var messages = _context.RoomMessages.Where(x => x.MaSP == maSP);
                return Ok();
            }catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
