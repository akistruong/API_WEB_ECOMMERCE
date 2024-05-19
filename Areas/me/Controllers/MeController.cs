using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace API_DSCS2_WEBBANGIAY.Areas.me.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "MEMANAGER")]
    [ApiController]
    public class MeController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public MeController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/Me
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoans()
        {
            return await _context.TaiKhoans.ToListAsync();
        }
        [HttpGet("GetOrders/{tenTaiKhoan}")]
        public async Task<IActionResult> GetOrdersByUser(string tenTaiKhoan)
        {
            try
            {
                var hds = _context.PhieuNhapXuats.Where(x=>x.idTaiKhoan==tenTaiKhoan).Include(x=>x.DiaChiNavigation).Include(x => x.ChiTietNhapXuats).ThenInclude(x=>x.SanPhamNavigation);
                  
                return Ok(hds);
            }catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        // GET: api/Me/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(string id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);

            if (taiKhoan == null)
            {
                return NotFound();
            }

            return taiKhoan;
        }

        // PUT: api/Me/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("AddAddress" )]
        public async Task<IActionResult>    AddAddress( DiaChi dc)
        {
            try
            {
                var tk =  await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TenTaiKhoan == dc.TenTaiKhoan);
               
                _context.DiaChis.Update(dc);
                await _context.SaveChangesAsync();
                tk.addressDefault = (int)dc.ID;
                _context.TaiKhoans.Update(tk);
                await _context.SaveChangesAsync();
                return Ok(dc);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                var dc = await _context.DiaChis.FindAsync(id);
                if (dc is not null)
                {

                    var taikhoan = _context.TaiKhoans.FirstOrDefault(x => x.addressDefault == id);
                    if(taikhoan is not null)
                    {
                        taikhoan.addressDefault = null;

                    _context.Entry(taikhoan).State = EntityState.Modified;
                    }
                    dc.deletedAT = DateTime.Now;
                    _context.Entry(dc).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }

            }catch(Exception err)
            {
                return BadRequest();
            }
        }
        // DELETE: api/Me/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(string id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("ChangeDefaultAddress")]
        public async Task<IActionResult> ChangeDefaultAddress(TaiKhoan tk )
        {
            try
            {
                var myAcc = _context.TaiKhoans.FirstOrDefault(x=>x.TenTaiKhoan == tk.TenTaiKhoan);
                myAcc.addressDefault = tk.addressDefault;
                _context.TaiKhoans.Update(myAcc);
                await _context.SaveChangesAsync();
                return Ok();
            }catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost("SetAvatar/{userName}")]
        public async Task<IActionResult> SetAvatar(IFormFile file,string userName)
        {
            if (file != null)
            {
                var folder = "wwwroot//res//users//" + userName+"//avatars//";
                var path = Path.Combine(
            Directory.GetCurrentDirectory(), folder,
            file.FileName);
                if (!Directory.Exists(folder))
                {
                    
                    Directory.CreateDirectory(folder);
                }
                else
                {
                    try
                    {

                    Directory.Delete(folder, true);
                        Directory.CreateDirectory(folder);

                    }
                    catch(Exception err)
                    {
                        return BadRequest();
                    }
                }
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(stream);
                        var user =await _context.TaiKhoans.FindAsync(userName);
                        user.Avatar = file.FileName;
                        _context.TaiKhoans.Update(user);
                        await _context.SaveChangesAsync();
                        return Ok(new
                        {
                            fileName= file.FileName
                        });
                    }
                    catch (Exception err)
                    {
                        return BadRequest(new
                        {
                            success = false
                        });
                    }
                }
            }
            else
            {
                return BadRequest();
            }
          
        }
        [HttpPut("UpdateInfo")]
        public async Task<IActionResult> UpdateInfo(TaiKhoan taikhoan)
        {
            try
            {
                _context.TaiKhoans.Update(taikhoan);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        private bool KhachHangExists(int id)
        {
            return _context.KhachHangs.Any(e => e.Id == id);
        }
    }
}
