using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Utils;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Authorize(Roles ="BSTMNG")]
    public class BoSuuTapController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public BoSuuTapController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/BoSuuTap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoSuuTap>>> GetBoSuuTaps()
        {
            try
            {
                var bsts = await _context.BoSuuTaps.ToListAsync();
                return Ok(bsts); ;
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
      
        // GET: api/BoSuuTap/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBoSuuTap(int id)
        {
            var boSuuTap = await _context.BoSuuTaps.Include(x=>x.ChiTietBSTs).ThenInclude(x=>x.SanPhamNavigation).FirstOrDefaultAsync(x=>x.Id ==id);
            if (boSuuTap == null)
            {
                return NotFound();
            }

            return Ok(boSuuTap); ;
        }

        // PUT: api/BoSuuTap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoSuuTap(int id, BoSuuTap boSuuTap)
        {
            if (id != boSuuTap.Id)
            {
                return BadRequest();
            }

           

            try
            {
                _context.Entry(boSuuTap).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoSuuTapExists(id))
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

        // POST: api/BoSuuTap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoSuuTap>> PostBoSuuTap(BoSuuTap boSuuTap)
        {
            try
            {
                boSuuTap.Slug = CustomSlug.Slugify(boSuuTap.TenBoSuuTap);
                _context.BoSuuTaps.Add(boSuuTap);
                await _context.SaveChangesAsync();

                return Ok(boSuuTap);
            }
            catch(Exception err)
            {
                return BadRequest();
            }
        }

        // DELETE: api/BoSuuTap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoSuuTap(int id)
        {
            try
            {
                var boSuuTap = await _context.BoSuuTaps.FindAsync(id);
                if (boSuuTap == null)
                {
                    return NotFound();
                }
                    _context.BoSuuTaps.Remove(boSuuTap);
                    await _context.SaveChangesAsync();
                if (!handleDeleteImg(boSuuTap.Img, boSuuTap.Id))
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost("UploadImgBST/{Id}")]
        public async Task<IActionResult> UploadImgBST(IFormFile file, int Id)
        {
            if (file != null)
            {

                var folder = "wwwroot//res//BstImgs";
                var path = Path.Combine(
          Directory.GetCurrentDirectory(), folder,
          file.FileName);
                FileInfo File = new FileInfo(path);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(folder);
                }
                if (File.Exists)
                {
                    return BadRequest(new
                    {
                        message = "Đã tồn tại hình ảnh này ."
                    });
                }
                using (var stream = new FileStream(path, FileMode.CreateNew))
                {
                    try
                    {
                        
                        await file.CopyToAsync(stream);
                        var BST = _context.BoSuuTaps.FirstOrDefault(x => x.Id == Id);
                        if (BST != null)
                        {
                                BST.Img = file.FileName;
                                _context.BoSuuTaps.Update(BST);
                                await _context.SaveChangesAsync();
                            return Ok(new
                            {
                                img = file.FileName

                            }); ;
                            
                      
                               
                            
                          
                        }

                    }
                    catch (Exception err)
                    {
                        return BadRequest(err.Message);
                    }

                }
            }

            return BadRequest();
        }
        private bool handleDeleteImg(string FileName,int Id)
        {
            if (FileName != null)
            {
                var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot//res//BstImgs",
                FileName);

                FileInfo file = new FileInfo(path);
                try
                {
                    if (file.Exists)
                    {
                        file.Delete();
                        return true;

                    }
                    return false;
                }
                catch (Exception err)
                {
                    return false;
                }

            }
            return false;
        }
        [HttpDelete("RemoveImgBST/{id}")]
        public async Task<IActionResult> RemoveImgBST(string fileName,int id)
        {
            if (fileName != null)
            {
                var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot//res//BstImgs",
                fileName);

                FileInfo file = new FileInfo(path);
                try
                {
                    if (file.Exists)
                    {
                        file.Delete();
                        var BST = await _context.BoSuuTaps.FirstOrDefaultAsync(x => x.Id == id);
                        if (BST != null)
                        {
                            BST.Img = null;
                            await _context.SaveChangesAsync();
                            return Ok(new
                            {
                                success = true,
                                path = path
                            }); ;
                        }

                    }
                }
                catch (Exception err)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        
        private bool BoSuuTapExists(int id)
        {
            return _context.BoSuuTaps.Any(e => e.Id == id);
        }
    }
}
