using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Authorize(Roles = "ACCTMNG")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class TaiKhoanControllers : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public TaiKhoanControllers(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet("GetMembers")]
        public async Task<IActionResult> GetMembers([FromQuery(Name = "soLanMuaHang")] int soLanMuaHang, [FromQuery(Name = "tongTienThanhToan")] int tongTienThanhToan)
        {
            try
            {
                IQueryable<TaiKhoan> accounts = Enumerable.Empty<TaiKhoan>().AsQueryable();
                accounts = _context.TaiKhoans.Where(x => x.RoleGroup == "MEMBER");
                if(tongTienThanhToan>0)
                {
                    accounts = accounts.Where(x => x.TienThanhToan >= tongTienThanhToan);
                }
                if(soLanMuaHang>0)
                {

                    accounts = accounts.Where(x => x.SoLanMuaHang >= soLanMuaHang);
                }
                return Ok(accounts);
            }
            catch(Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}
