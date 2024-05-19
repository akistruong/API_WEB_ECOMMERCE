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
    public class MauSacController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public MauSacController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/MauSac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauSac>>> GetMauSacs()
        {
            try
            {
                
                return await _context.MauSacs.ToListAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/MauSac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MauSac>> GetMauSac(string id)
        {
            var mauSac = await _context.MauSacs.FindAsync(id);

            if (mauSac == null)
            {
                return NotFound();
            }

            return mauSac;
        }

        // PUT: api/MauSac/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMauSac(string id, MauSac mauSac)
        {
            if (id != mauSac.MaMau)
            {
                return BadRequest();
            }

            _context.Entry(mauSac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauSacExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MauSac
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MauSac>> PostMauSac(MauSac mauSac)
        {
            try
            {
                _context.MauSacs.Add(mauSac);
                await _context.SaveChangesAsync();
                return Ok(mauSac);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }

        // DELETE: api/MauSac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMauSac(string id)
        {
            var mauSac = await _context.MauSacs.FindAsync(id);
            if (mauSac == null)
            {
                return NotFound();
            }

            _context.MauSacs.Remove(mauSac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MauSacExists(string id)
        {
            return _context.MauSacs.Any(e => e.MaMau == id);
        }
    }
}
