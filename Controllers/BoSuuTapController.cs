using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoSuuTapController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public BoSuuTapController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBST([FromQuery(Name = "type")] string type)
        {
            try
            {
                IQueryable<BoSuuTap> bst = Enumerable.Empty<BoSuuTap>().AsQueryable();
                 bst = _context.BoSuuTaps;
                if(type is not null && type.Length>0)
                {
                    bst = bst.Where(x=>x.Type == type); 
                }
                return Ok(bst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug, [FromQuery(Name = "type")] string type)
        {
            try
            {
                var bst = _context.BoSuuTaps.FirstOrDefault(x => x.Slug.Trim() == slug);

                return Ok(bst);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet("{slug}/products")]
        public async Task<IActionResult> Gets(string slug, string? sort, [FromQuery(Name = "size")] string size,
            [FromQuery(Name = "color")] string color, int pageSize, int? page, [FromQuery(Name = "category")] string category, [FromQuery(Name = "brand")] string brand, [FromQuery(Name = "s")] string s)
        {
            try
            {
                IQueryable<SanPham> products = Enumerable.Empty<SanPham>().AsQueryable();
                products = _context.SanPhams
                 .Include(x => x.SanPhams).ThenInclude(x => x.ChiTietHinhAnhs).ThenInclude(x => x.IdHinhAnhNavigation)
                 .Include(x => x.BrandNavigation)
                 .Include(x=>x.ChiTietBSTs).ThenInclude(x=>x.BSTNavigation)
                  .Where(x => x.ParentID == null).Where(x=>x.ChiTietBSTs.Any(x=>x.BSTNavigation.Slug.Trim()==slug));
                if (brand is not null && brand.Length > 0)
                {
                    products = products.Where(x => x.BrandNavigation.Slug.Trim().ToLower() == brand);
                }
                if (s is not null && s.Length > 0)
                {
                    products = products.Where(x => x.TenSanPham.Trim().ToLower().Contains(s.Trim().ToLower()));
                }
                if (size is not null && size.Length > 0)
                {
                    products = products.Where(x => x.SanPhams.Any(x => x.IDSize == size));
                }
                if (color is not null && color.Length > 0)
                {
                    products = products.Where(x => x.SanPhams.Any(x => x.IDColor == color));
                }
                switch (sort)
                {
                    case "price-hight-to-low":
                        products = products.OrderByDescending(s => s.GiaBanLe);
                        break;
                    case "date-oldest":
                        products = products.OrderBy(s => s.CreatedAt);
                        break;
                    case "date-newest":
                        products = products.OrderByDescending(s => s.CreatedAt);
                        break;
                    default:
                        products = products.OrderBy(s => s.GiaBanLe);
                        break;
                }
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
    }
}
