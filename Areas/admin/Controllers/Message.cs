using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Message : ControllerBase
    {
        private readonly ShoesEcommereContext _context;
        public Message(ShoesEcommereContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var messages = _context.Messages/*.Include(x=>x.userNavigation)*/;
            return Ok(messages);
        }
    }
}
