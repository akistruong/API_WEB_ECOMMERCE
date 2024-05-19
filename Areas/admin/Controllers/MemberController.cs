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
    [Area("admin")]
    [Authorize(Roles = "CUSTOMERMNG")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public MemberController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMembers([FromQuery(Name = "current")] int? current, [FromQuery(Name = "pageSize")] int? pageSize)
        {
            try
            {
                IQueryable<TaiKhoan> members = Enumerable.Empty<TaiKhoan>().AsQueryable();
                members = _context.TaiKhoans.Include(x=>x.CouponsKhachHangs).Where(x => x.RoleGroup == "USER");
                if(members.Count()>0)
                {
                    var MembersResult = await PaggingService<TaiKhoan>.CreateAsync((IQueryable<TaiKhoan>)members, current ?? 1, pageSize??10);
                    return Ok(MembersResult);
                }
                return NotFound();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberByID(string userName)
        {
            try
            {
                var res = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan == userName && x.RoleGroup == "USER");
                return res is not null ?Ok(res) : NotFound();

            }catch(Exception err)
            {
                return BadRequest();
            }
        }
    }
}
