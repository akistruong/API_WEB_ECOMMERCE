using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    //[Authorize(Roles = "ADMIN")]
    [Authorize(Roles = "ROLEMNG")]

    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public RoleController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = _context.Roles;
                return Ok(roles ?? null);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetRolesGroup")]
        public async Task<IActionResult> GetRolesGroup()
        {
            try
            {
                var roles = _context.RoleGroup.Include(x=>x.RoleDetails);
                return Ok(roles ?? null);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpGet("Staff/{id}")]
        public async Task<IActionResult> GetStaff(string id)
        {
            try
            {
                var user = _context.TaiKhoans.FirstOrDefault(x=>x.TenTaiKhoan==id);
                return Ok(user);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = _context.TaiKhoans.Include(x=>x.RoleGroupNavigation).ThenInclude(x=>x.RoleDetails).Where(x=>x.RoleGroup!="USER");
                return Ok(users ?? null);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(TaiKhoan body)
        {
            try
            {
                _context.TaiKhoans.Add(body);
                _context.SaveChanges();
                return Ok(body ?? null);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost("PostRoleGroup")]
        public async Task<IActionResult> PostRoleGroup(RoleGroup body)
        {
            try
            {
                _context.RoleGroup.Add(body);
                _context.SaveChanges();
                return Ok(body ?? null);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(TaiKhoan body)
        {
            try
            {
                _context.TaiKhoans.Update(body);
                _context.SaveChanges();
                return Ok(body ?? null);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPut("ChangeRoles")]
        public async Task<IActionResult> ChangeRoles(RoleGroup body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var rolesDetails = _context.RoleDetails.Where(x => x.RoleGroup == body.GroupName);
                _context.RoleDetails.RemoveRange(rolesDetails);
                _context.RoleDetails.AddRange(body.RoleDetails);
                _context.SaveChanges();
                trans.Commit();
                return Ok(body ?? null);
            }
            catch (Exception err)
            {
                trans.RollbackAsync();
                return BadRequest();
            }
        }
    }
}
