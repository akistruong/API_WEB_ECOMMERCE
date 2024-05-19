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
    [Route("api/[controller]")]
    [Authorize(Roles = "CATEMNG")]
    [ApiController]
    public class DanhMucDetailsController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public DanhMucDetailsController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/DanhMucDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMucDetails>>> GetDanhMucDetails()
        {
            return await _context.DanhMucDetails.ToListAsync();
        }
        [HttpGet("GetCategoryDetailByProduct/{maSP}")]
        public  IActionResult GetCategoryDetailByProduct(string maSP)
        {
            try
            {
                var res = _context.DanhMucDetails.Include(x=>x.IdDanhMucNavigation).Where(x => x.MaSanPham.Trim() == maSP.Trim());
                return Ok(res);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }
        // GET: api/DanhMucDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMucDetails>> GetDanhMucDetails(int id)
        {
            var danhMucDetails = await _context.DanhMucDetails.FindAsync(id);

            if (danhMucDetails == null)
            {
                return NotFound();
            }

            return danhMucDetails;
        }

        // PUT: api/DanhMucDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMucDetails(int id, DanhMucDetails danhMucDetails)
        {
            if (id != danhMucDetails.danhMucId)
            {
                return BadRequest();
            }

            _context.Entry(danhMucDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucDetailsExists(id))
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

        // POST: api/DanhMucDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DanhMucDetails>> PostDanhMucDetails(List<DanhMucDetails> body)
        {
            try
            {
                   foreach(var item in body)
                {
                    var dm = _context.DanhMucDetails.FirstOrDefault(x => x.danhMucId == item.danhMucId && x.MaSanPham == item.MaSanPham);
                    if(dm is  null)
                    {
                 _context.DanhMucDetails.Add(item);
                    }
                }
                _context.SaveChanges();
                    return Ok(body);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

        }

        // DELETE: api/DanhMucDetails/5
        [HttpPost("DeleteDanhMucDetails")]
        public async Task<IActionResult> DeleteDanhMucDetails(List<DanhMucDetails> body)
        {
            try
            {
                _context.DanhMucDetails.RemoveRange(body);
                _context.SaveChanges();
                return Ok(body);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }

        private bool DanhMucDetailsExists(int id)
        {
            return _context.DanhMucDetails.Any(e => e.danhMucId == id);
        }
        private int TestFnc(ref DanhMuc dm,string maSP)
        {
            if(dm == null)
            {
                return 0;
            }
            else
            {
                var parentID = dm.ParentCategoryID;
                var ID = dm.Id;
                if (parentID<=-1)
                {
                    _context.DanhMucDetails.Add(new DanhMucDetails() { IDSanPham = ID, danhMucId = ID });
                    _context.SaveChanges();
                    return 0;
                }
                var parent = _context.DanhMucs.FirstOrDefault(x => x.Id == parentID);
                _context.DanhMucDetails.Add(new DanhMucDetails() { IDSanPham = ID, danhMucId = ID });
                 _context.SaveChanges();
                return TestFnc( ref parent, maSP);
            }
        }
        //[HttpGet("Test")]
        //public async Task<IActionResult> Test()
        //{
        //    DanhMuc dm = new DanhMuc() { Id=11,ParentCategoryID=9};
        //    if(dm!= null)
        //    {
        //        TestFnc(ref dm);
        //    }
            
        //    return Ok();
        //}
    }
}
