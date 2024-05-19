using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Utils;
using System.Collections;
using API_DSCS2_WEBBANGIAY.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    //[Authorize(Roles = "CATEGORYMANAGER,ADMIN")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
   

    public class DanhMucController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public DanhMucController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/DanhMuc
        [HttpGet]

        public async Task<IActionResult> GetDanhMucUI()
        {
            try
            {

                var danhmucs = _context.DanhMucs;
                return Ok(danhmucs);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
            
           
          
        }
        [HttpGet("GetAllDanhMuc")]
        public async Task<IActionResult> GetAllDanhMuc([FromQuery(Name = "order")] string order)
        {
            try
            {
                IQueryable<DanhMuc> danhmucs = Enumerable.Empty<DanhMuc>().AsQueryable();
                 danhmucs =  _context.DanhMucs;
                if(danhmucs is not null && danhmucs.Count() > 0)
                {
                    switch (order)
                    {
                        case "most-view":
                            danhmucs =danhmucs.OrderByDescending(x => x.ViewCount).Take(8);
                            break;
                        default:
                            break;
                    }
                    return Ok(danhmucs);

                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        // GET: api/DanhMuc/5
        [HttpGet("GetDanhMucByParentId/{id}")]
        public async Task<ActionResult> GetDanhMucByParentId(int id)
        {
            
            var danhMuc =  _context.DanhMucs.Where(x=>x.ParentCategoryID == id);
            if (danhMuc == null)
            {
                return NotFound();
            }
          
            return Ok(danhMuc);
        }

        // PUT: api/DanhMuc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMuc(int id, DanhMuc danhMuc)
        {
            //if (id != danhMuc.Id)
            //{
            //    return BadRequest();
            //}


            try
            {
                var parentDM = await _context.DanhMucs.FirstOrDefaultAsync(x => x.Id == danhMuc.ParentCategoryID);
                if (parentDM != null)
                {
                    danhMuc.Slug = CustomSlug.Slugify(parentDM.Slug + " " + danhMuc.TenDanhMuc);
                }
                else
                {
                    danhMuc.Slug = CustomSlug.Slugify(danhMuc.TenDanhMuc);
                }
                _context.Entry(danhMuc).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucExists(id))
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

        // POST: api/DanhMuc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "CATEMNG")]
        public async Task<ActionResult<DanhMuc>> PostDanhMuc(DanhMuc danhMuc)
        {
            if (String.IsNullOrEmpty(danhMuc.TenDanhMuc))  return BadRequest();
            
           
            try
            {
                var parentDM = await _context.DanhMucs.FirstOrDefaultAsync(x => x.Id == danhMuc.ParentCategoryID);
                if (parentDM != null)
                {
                    danhMuc.Slug = CustomSlug.Slugify(parentDM.Slug+" "+danhMuc.TenDanhMuc);
                }
                else
                {
                    danhMuc.Slug = CustomSlug.Slugify(danhMuc.TenDanhMuc);
                }
                _context.DanhMucs.Add(danhMuc);
                await _context.SaveChangesAsync();
                return Ok(danhMuc);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return BadRequest(err.Message);
            }
            return BadRequest();
           
        }

        // DELETE: api/DanhMuc/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "CATEMNG")]
        public async Task<IActionResult> DeleteDanhMuc(int id)
        {
            var danhMuc = await _context.DanhMucs.FindAsync(id);
            if (danhMuc == null)
            {
                return NotFound();
            }
            var danhMucs  = _context.DanhMucs.Where(x=>x.ParentCategoryID==id ).ToList();
            if(danhMuc is not null)
            {
                foreach(var dm in danhMucs)
                {
                    var danhmucChildrens = _context.DanhMucs.Where(x=>x.ParentCategoryID == dm.Id).ToList();
                    foreach(var danhmucChild in danhmucChildrens)
                    {
                        _context.DanhMucs.Remove(danhmucChild);
                    }
                    _context.DanhMucs.Remove(dm);
                }
                _context.DanhMucs.Remove(danhMuc);
            }
            await _context.SaveChangesAsync();
            return Ok(danhMuc);
        }

        private bool DanhMucExists(int id)
        {
            return _context.DanhMucs.Any(e => e.Id == id);
        }
    }
}
