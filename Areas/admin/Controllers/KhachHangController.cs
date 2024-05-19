using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{

    [Authorize(Roles = "CUSTOMERMNG")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public KhachHangController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/KhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChi>>> GetKhachHang()
        {
            return await _context.DiaChis.ToListAsync();
        }

        // GET: api/KhachHang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChi>> GetDiaChi(int id)
        {
            var diaChi = await _context.DiaChis.FindAsync(id);

            if (diaChi == null)
            {
                return NotFound();
            }

            return diaChi;
        }

        // PUT: api/KhachHang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaChi(int id, DiaChi diaChi)
        {
            if (id != diaChi.ID)
            {
                return BadRequest();
            }

            _context.Entry(diaChi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaChiExists(id))
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

        // POST: api/KhachHang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaChi>> PostDiaChi(DiaChi diaChi)
        {
            _context.DiaChis.Add(diaChi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaChi", new { id = diaChi.ID }, diaChi);
        }

        // DELETE: api/KhachHang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaChi(int id)
        {
            var diaChi = await _context.DiaChis.FindAsync(id);
            if (diaChi == null)
            {
                return NotFound();
            }

            _context.DiaChis.Remove(diaChi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaChiExists(int id)
        {
            return _context.DiaChis.Any(e => e.ID == id);
        }
    }
}
