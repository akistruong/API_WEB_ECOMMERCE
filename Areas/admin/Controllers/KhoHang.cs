using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Authorize(Roles = "INVENTORYMNG")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class KhoHang : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public KhoHang(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "pageSize")] int? pageSize)
        {
            try
            {
                var khohangs = _context.KhoHangs.Include(x=>x.BranchNavigation).ThenInclude(x=>x.PhieuNhapXuats).Where(x => x.MaSanPham == id);
                var result = await PaggingService<ChiNhanh_SanPham>.CreateAsync((IQueryable<ChiNhanh_SanPham>)khohangs, page ?? 1, pageSize ?? 10);
                return Ok(result);
            }
            catch(Exception err)
            {
                return BadRequest(err);
            }
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts( [FromQuery(Name = "s")] string s, [FromQuery(Name = "OnlyVersion")] bool OnlyVersion,[FromQuery(Name = "maChiNhanh")] string maChiNhanh)
        {
            try
            {
               
                IQueryable<ChiNhanh_SanPham> products = Enumerable.Empty<ChiNhanh_SanPham>().AsQueryable();
                if (maChiNhanh is not null && maChiNhanh.Length>0)
                {
                 products = _context.KhoHangs.Include(x => x.SanPhamNavigation).Include(x => x.SanPhamNavigation).ThenInclude(x => x.ChiTietHinhAnhs).ThenInclude(x => x.IdHinhAnhNavigation).Where(x=>x.MaChiNhanh.Trim()==maChiNhanh);
                    
                }
                else
                {

                    products = _context.KhoHangs.Include(x => x.SanPhamNavigation).Include(x => x.SanPhamNavigation).ThenInclude(x => x.ChiTietHinhAnhs).ThenInclude(x => x.IdHinhAnhNavigation);
                }
                if (OnlyVersion)
                {
                products = products.Where(x=> x.SanPhamNavigation.ParentID != null);
                }
                else
                {
                    products = products.Where(x=> x.SanPhamNavigation.ParentID == null);
                }
                if (s is not null && s.Length > 0)
                {
                    products = products.Where(x => x.SanPhamNavigation.Slug.Trim().Contains(s.Trim()));
                }
                return Ok(products.Take(10));
            }catch(Exception err)
            {
                return BadRequest(err.Message); 
            }
        }
    }
}
