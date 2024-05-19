using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public SizesController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/Sizes
        [HttpGet]
        public async Task<ActionResult> GetSizes()
        {
            var sizes = await _context.Sizes.ToListAsync();
            var select = sizes.Select(x => new
            {
                label = x.Size1,
                value = x.Id,
            });
            return Ok(select);
        }
        [HttpPost]
        public async Task<IActionResult>Post(Size body)
        {
            try
            {
                 _context.Sizes.Add(body);
                _context.SaveChanges();
                return Ok(body);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(Size body)
        {
            try
            {
                _context.Entry(body).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var size = _context.Sizes.FirstOrDefault(x =>x.Id==id);
                _context.Sizes.Remove(size);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
    }
}
