using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class NCCController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public NCCController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "s")] string s )
        {
            try
            {
                IQueryable<NCC> nccs = Enumerable.Empty<NCC>().AsQueryable();
                if (s is not null)
                {
                    nccs = _context.NhaCungCap.Include(x=>x.DiaChiNavigation).Where(x => x.Name.Trim().Contains(s.Trim()));
                }
                return Ok(nccs);
            }catch(Exception err)
            {
                return BadRequest(err.Message); 
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(NCC body)
        {
            try
            {
                _context.NhaCungCap.Add(body);
                await _context.SaveChangesAsync();
                return Ok(body);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
