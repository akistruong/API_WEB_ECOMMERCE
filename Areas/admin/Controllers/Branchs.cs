using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class Branchs : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public Branchs(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var branchs = _context.Branchs.ToList();
                return Ok(branchs);
            }
            catch(Exception err)
            {
                return NotFound(err.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(API_DSCS2_WEBBANGIAY.Models.Branchs body)
        {
            try
            {
                _context.Branchs.Add(body);
                _context.SaveChanges();
                return Ok(body);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(API_DSCS2_WEBBANGIAY.Models.Branchs body)
        {
            try
            {
                _context.Branchs.Update(body);
                _context.SaveChanges();

                return Ok(body);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(API_DSCS2_WEBBANGIAY.Models.Branchs body)
        {
            try
            {
                _context.Branchs.Remove(body);
                _context.SaveChanges();

                return Ok(body);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }
        [HttpPost("SyncProducts")]
        public async Task<IActionResult> SyncProducts(API_DSCS2_WEBBANGIAY.Models.Branchs body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var products = _context.SanPhams.AsNoTracking().ToList();
                foreach(var product in products)
                {

                    var khohangCheck = _context.KhoHangs.AsNoTracking()
                        .FirstOrDefault(x => x.MaSanPham.Trim() == product.MaSanPham.Trim() && x.MaChiNhanh.Trim() == body.MaChiNhanh.Trim());
                    if (khohangCheck is not null)
                    {

                    }
                    else
                    {
                        ChiNhanh_SanPham kho = new ChiNhanh_SanPham();
                        kho.MaChiNhanh = body.MaChiNhanh;
                        kho.MaSanPham = product.MaSanPham;
                        _context.Entry(kho).State = EntityState.Added;
                        body.KhoHangs.Add(kho);
                    }
                   
                }
                _context.SaveChanges();
                await trans.CommitAsync();
                return Ok(body);
            }
            catch (Exception err)
            {
                 trans.RollbackAsync();
                return BadRequest();
            }
        }
    }
}
