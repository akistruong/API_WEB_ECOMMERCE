using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;
        private  IConfiguration _configuration { get;  set; }

        public SanPhamController(ShoesEcommereContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet("GetAll/{maChiNhanh}")]
        public async Task<ActionResult> GetSanPhams(string? maChiNhanh,string? sort, [FromQuery(Name = "size")] string size, [FromQuery(Name = "type")] string type,
            [FromQuery(Name = "color")] string color, 
            int pageSize, int? page,
            [FromQuery(Name = "category")] string category, 
            [FromQuery(Name = "brand")] string brand, [FromQuery(Name = "s")] string s)
        {
            try
            {
                var baseURL = _configuration.GetSection("BaseURL").Value;
                pageSize = pageSize == 0 ? 10 : pageSize;
                IQueryable<ChiNhanh_SanPham> products = Enumerable.Empty<ChiNhanh_SanPham>().AsQueryable();
                var getID = await _context.DanhMucs.FirstOrDefaultAsync(x => x.Slug == category);
                products = _context.KhoHangs.Include(x=>x.SanPhamNavigation).ThenInclude(x=>x.StarReviewNavigation).Include(x => x.SanPhamNavigation)
                   .ThenInclude(x => x.SanPhams).ThenInclude(x => x.ChiTietHinhAnhs).ThenInclude(x => x.IdHinhAnhNavigation)
                 .Where(x => x.MaChiNhanh == maChiNhanh)
                    .Where(x => x.SanPhamNavigation.ParentID == null);
                if(brand is not null && brand.Length>0)
                {
                    products = products.Where(x => x.SanPhamNavigation. BrandNavigation.Slug.Trim().ToLower() == brand);
                }
                if(category is not null && category.Length>0)
                {
                    products = products
                  .Where(x => x.SanPhamNavigation.DanhMucDetails.Any(x => x.danhMucId == getID.Id)).Where(x => x.SanPhamNavigation.ParentID == null);
                    getID.ViewCount++;
                    _context.Entry(getID).State = EntityState.Modified;
                     _context.SaveChanges();
                }
                if(type is not null && type.Length>0)
                {
                    products = products.Where(x => x.SanPhamNavigation.TypeNavigation.Slug == type);
                }
                if (s is not null && s.Length > 0)
                {
                    products = products.Where(x => x.SanPhamNavigation.Slug.Trim().ToLower().Contains(s.Trim().ToLower()));
                }
                if (size is not null && size.Length > 0)
                {
                    products = products.Where(x => x.SanPhamNavigation.SanPhams.Any(x => x.IDSize == size));
                }
                if (color is not null && color.Length > 0)
                {
                    products = products.Where(x => x.SanPhamNavigation.SanPhams.Any(x => x.IDColor == color));
                }
                switch (sort)
                {
                    case "price-hight-to-low":
                        products = products.OrderByDescending(s => s.SanPhamNavigation.GiaBanLe);
                        break;
                    case "date-oldest":
                        products = products.OrderBy(s => s.SanPhamNavigation.CreatedAt);
                        break;
                    case "date-newest":
                        products = products.OrderByDescending(s => s.SanPhamNavigation.CreatedAt);
                        break;
                    case "popular":
                        products = products.OrderByDescending(h => h.SanPhamNavigation.SoLuongDaBan);
                        break;
                    case "most-view":
                            products = products.OrderByDescending(h => h.SanPhamNavigation.ViewCount);
                        break;
                    case "sale":
                        products = products.Where(x => x.SanPhamNavigation.isSale==true);
                        break;
                    default:
                        products = products.OrderBy(s => s.SanPhamNavigation.GiaBanLe);
                        break;
                }
                var result = await PaggingService<ChiNhanh_SanPham>.CreateAsync((IQueryable<ChiNhanh_SanPham>)products, page ?? 1, pageSize);
                return Ok(new
                {
                    products= result,
                    totalRow = result.TotalPages,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("Get/{slug}/{maChiNhanh}")]
        public async Task<ActionResult<SanPham>> GetSanPham(string slug,string maChiNhanh)
        {
            try
            {
                var baseURL = _configuration.GetSection("BaseURL").Value;
                var sanPham = await _context.KhoHangs
                    .Include(x => x.SanPhamNavigation).ThenInclude(x => x.StarReviewNavigation).ThenInclude(x => x.StarReviewDetails)
                    .Include(x => x.SanPhamNavigation)
                                
                          .ThenInclude(x => x.SanPhams).ThenInclude(x => x.ChiTietHinhAnhs).ThenInclude(x => x.IdHinhAnhNavigation)
                          .Include(x => x.SanPhamNavigation).ThenInclude(x => x.SanPhams).ThenInclude(x => x.KhoHangs.Where(x => x.MaChiNhanh == maChiNhanh))
                           .FirstOrDefaultAsync(x => x.SanPhamNavigation.Slug.Trim() == slug.Trim() && x.SanPhamNavigation.ParentID == null);
                var related = _context.SanPhams.Include(x => x.SanPhams).ThenInclude(x => x.ChiTietHinhAnhs).ThenInclude(x => x.IdHinhAnhNavigation).Where(x => x.ParentID == null && x.MaSanPham != sanPham.MaSanPham).Where(x => x.IDBrand == sanPham.SanPhamNavigation.IDBrand);
                if (sanPham == null)
                {
                    return NotFound();
                }
                sanPham.SanPhamNavigation.ViewCount++;
                _context.Entry(sanPham.SanPhamNavigation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    sanPham,
                    related,
                }); ; ;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetQTY/{MaSanPham}/{MaChiNhanh}")]
        public async Task<IActionResult> GetQTY(string MaSanPham,string MaChiNhanh)
        {
            try
            {
                var obj = _context.KhoHangs.FirstOrDefault(x => x.MaSanPham == MaSanPham && x.MaChiNhanh == MaChiNhanh);
                return obj!=null?Ok(obj) :NotFound(); ; 
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

