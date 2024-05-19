using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    //[Authorize(Roles = "HOMEADMIN")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]

    [ApiController]
    public class HomeAdminController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public HomeAdminController(ShoesEcommereContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tongthu = _context.PhieuNhapXuats.Where(x => x.LoaiPhieu.Trim() == "PHIEUTHU"&&x.createdAt.Date==DateTime.Now.Date).Sum(x=>x.TienDaThanhToan);
            var thongchi = _context.PhieuNhapXuats.Where(x => x.LoaiPhieu.Trim() == "PHIEUCHI" && x.createdAt.Date == DateTime.Now.Date).Sum(x => x.TienDaThanhToan);
            var donhang = _context.PhieuNhapXuats.Where(x => x.LoaiPhieu.Trim() == "PHIEUXUAT" && x.steps<=2&&x.status!=-1&&x.createdAt.Date == DateTime.Now.Date).Count();
            var donhangthanhcong = _context.PhieuNhapXuats.Where(x => x.LoaiPhieu.Trim() == "PHIEUTHU" && x.steps>2&&x.createdAt.Date == DateTime.Now.Date).Count();
            var donhanghuy = _context.PhieuNhapXuats.Where(x => x.LoaiPhieu.Trim() == "PHIEUTHU" && x.status==-1&&x.createdAt.Date == DateTime.Now.Date).Count();
            return Ok(new
            {
                tongthu,
                thongchi,
                donhang,
                donhangthanhcong,
                donhanghuy,
            });

        }
        [HttpGet("HotProducts")]
        public IActionResult HotProducts()
        {
            try
            {
                var hotProducts = _context.SanPhams.Where(x=>x.ParentID==null&& x.SoLuongDaBan>0).OrderBy(x => x.SoLuongDaBan).Take(5); 
                return Ok(hotProducts);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }
        [HttpGet("MostViewsProducts")]
        public IActionResult MostViewsProducts()
        {
            try
            {
                var hotProducts = _context.SanPhams.Where(x => x.ParentID == null&&x.ViewCount>0).OrderBy(x => x.ViewCount).Take(5);
                return Ok(hotProducts);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
    }
    
}
