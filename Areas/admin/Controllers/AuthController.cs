using API_DSCS2_WEBBANGIAY.Areas.admin.Models;
using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Utils;
using API_DSCS2_WEBBANGIAY.Utils.Mail;
using API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;
        private readonly IHostingEnvironment _HostEnvironment;
        private IConfiguration _config;
        private readonly IOptions<MailSettings> mailSettings;

        public AuthController(ShoesEcommereContext context, IHostingEnvironment hostEnvironment, IConfiguration config, IOptions<MailSettings> mailSettings)
        {
            _context = context;
            _HostEnvironment = hostEnvironment;
            _config = config;
            this.mailSettings = mailSettings;
        }

        //[Authorize(Roles = "ADMIN")]
        //[HttpGet]
        //public async Task<IActionResult> Auth()
        //{
        //    try
        //    {
        //        var currentUser = GetCurrentUser();
        //        //var user = _context.TaiKhoans.Include(x => x.SdtKhNavigation).FirstOrDefault(x => x.TenTaiKhoan == currentUser.TenTaiKhoan);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var currentUser = GetCurrentUser();
                var user = _context.TaiKhoans.Include(r => r.RoleGroupNavigation).ThenInclude(x=>x.RoleDetails).Include(x => x.DiaChis).FirstOrDefault(x => x.TenTaiKhoan == currentUser.TenTaiKhoan);
                if (user is null) return Unauthorized(new
                {
                    status=false,
                });
                return Ok(new
                {
                    user = new
                    {
                        userName = user.TenTaiKhoan,
                        roleGroup=user.RoleGroup,
                        role = user.RoleGroupNavigation.RoleDetails.Select(x => new
                        {
                            RoleCode= x.RoleCode,
                            isActive = x.isActive,
                            IdRoleNavigation = x.IdRoleNavigation
                        }),
                        info = user.DiaChis,
                        hoadons = user.PhieuNhapXuats,
                        addressDefault = user.addressDefault,
                        avatar= user.Avatar,
                        nameDisplay = user.TenHienThi,
                        email= user.Email,
                    }

                });;;
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
           
        }
        [HttpPost("EmailVerify")]
        public async Task<IActionResult> EmailVerify(String token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                if (jwtSecurityToken is not null)
                {
                    var userClaim = jwtSecurityToken.Claims;
                    var TenTaiKhoan = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    if (TenTaiKhoan is null) return Unauthorized();
                    var user = _context.TaiKhoans.FirstOrDefault(x=>x.TenTaiKhoan == TenTaiKhoan);
                    if(user is not null)
                    {
                        user.isActive = true;
                        _context.Entry(user).State = EntityState.Modified;
                        _context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                   
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost("ResetPassword")]
        public  IActionResult ResetPassword( ResetPasswordParams body)
        {
            var verifyToken = JWTHandler.VerifyToken(body.Token);
            if (verifyToken)
            {
                var user = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan.Trim() == body.tenTaiKhoan.Trim());
                if(user is not null)
                {
                    user.MatKhau = body.newPassword;
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound("Không tìm thấy người dùng này");
                }
            }
            else
            {
                return BadRequest("Mã token sai định dạng.");
            }
        }
        [HttpGet("RequestResetPassword/{email}")]
        public async Task<IActionResult> RequestResetPassword(string email)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var userEmail = _context.TaiKhoans.FirstOrDefault(x => x.Email.Trim() == email.Trim());
                if(userEmail is not null)
                {
                    var ClientURL = Startup.Configuration.GetSection("ClientURL").Value;
                    var token = JWTHandler.Generate(DateTime.Now.AddDays(5));
                    if (token is null) return BadRequest("");
                    var link = ClientURL + "/reset_password/" + token+"/"+userEmail.TenTaiKhoan.Trim();
                    var bodyString = await new ResetPassword(_HostEnvironment).RenderBody(link);
                    var mailBody = new MailRequest()
                    {
                        Body = bodyString.ToString(),
                        Subject = "Thay đổi mật khẩu",
                        ToEmail = email,
                    };
                    var mailSend = new MailService(mailSettings);
                    mailSend.SendEmailAsync(mailBody);
                    await trans.CommitAsync();
                    return Ok();
                }
                else
                {
                    return NotFound("Không tìm thấy email này");
                }
            }catch(Exception err)
            {
                trans.Rollback();
                return BadRequest();
            }
        }
        [HttpPost("EmailRegister")]
        public async Task<IActionResult> EmailRegister(TaiKhoan body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var user = await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TenTaiKhoan == body.TenTaiKhoan);
                if (user is  null)
                {
                    body.Email = body.TenTaiKhoan;
                    body.RoleGroup = "USER";
                    body.TypeAccount = "EMAIL";
                    _context.TaiKhoans.Add(body);
                    _context.SaveChanges();
                    var ClientURL = Startup.Configuration.GetSection("ClientURL").Value;
                    var token = Generate(body, DateTime.Now.AddDays(15));
                    if (token is null) return BadRequest("");
                    var link = ClientURL+ "/verify_email/" + token;
                    var bodyString = await new EmailVerify(_HostEnvironment).RenderBody(link);
                    var mailBody = new MailRequest()
                    {
                        Body = bodyString.ToString(),
                        Subject = "XÁC NHẬN EMAIL",
                        ToEmail = body.TenTaiKhoan,
                    };
                    var mailSend = new MailService(mailSettings);
                    mailSend.SendEmailAsync(mailBody);
                    await trans.CommitAsync();
                    return Ok();
                }
                else
                {
                     trans.RollbackAsync();
                    return BadRequest("Email đã có người dùng.");
                }
            }
            catch (Exception err)
            {
                trans.RollbackAsync();
                return NotFound();
            }
        }
        [HttpPost("EmailLogin")]
        public async Task<IActionResult> EmailLogin(TaiKhoan body)
        {
            try
            {
                var user = await _context.TaiKhoans.Include(x=>x.RoleGroupNavigation).ThenInclude(x=>x.RoleDetails).FirstOrDefaultAsync(x => x.TenTaiKhoan.Trim() == body.TenTaiKhoan.Trim() && x.MatKhau.Trim() == body.MatKhau.Trim());
                if (user is not null)
                {

                if ((bool)!user.isActive ) return BadRequest("Chưa kích hoạt tài khoản");
                    var token = Generate(user, DateTime.Now.AddSeconds(15));
                    var refreshToken = Generate(user, DateTime.Now.AddDays(30));
                    user.MatKhau = "";
                    return Ok(new
                    {
                        token,
                        refreshToken,
                        info = user,
                    });
                }
                else
                {
                    return BadRequest("Sai tài khoản hoặc mật khẩu.");
                    
                }
            }
            catch(Exception err)
            {
                return NotFound();
            }
        }
        [HttpPost("AdminLogin")]
        public async Task <IActionResult> AdminLogin(LoginModel body)
        {
            try
            {
                var user = await _context.TaiKhoans
                    .Include(x => x.RoleGroupNavigation).ThenInclude(x => x.RoleDetails)
                    .FirstOrDefaultAsync(x => x.TenTaiKhoan.Trim() == body.UserName.Trim()&&x.MatKhau.Trim()==body.Password.Trim());
                if (user ==null)
                {
                    return NotFound("Sai tài khoản hoặc mật khẩu");
                }
                if (user.RoleGroup.Trim() != "ADMIN") return Unauthorized();
                
                var token = Generate(user, DateTime.Now.AddSeconds(15));
                var refreshToken = Generate(user, DateTime.Now.AddDays(30));
                user.MatKhau = "";
                return Ok(new
                {
                    token,
                    refreshToken,
                    info = user,
                });
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost("ManagerLogin")]
        public async Task<IActionResult> ManagerLogin(LoginModel body)
        {
            try
            {
                var user = await _context.TaiKhoans.Include(x => x.RoleGroupNavigation)
                    .ThenInclude(x => x.RoleDetails).FirstOrDefaultAsync(x => x.TenTaiKhoan == body.UserName );
                if (user is null) return NotFound();
                if (user.RoleGroup.Trim() != "MANAGER") return Unauthorized();
                var token = Generate(user, DateTime.Now.AddSeconds(15));
                var refreshToken = Generate(user, DateTime.Now.AddDays(30));
                user.MatKhau = "";
                return Ok(new
                {
                    token,
                    refreshToken,
                    info = user,
                });
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost("PhoneSignIn")]
        public async Task<IActionResult> PhoneSignIn(LoginModel body)
        {
            var user = await _context.TaiKhoans.Include(x=>x.RoleGroupNavigation).ThenInclude(x=>x.RoleDetails).FirstOrDefaultAsync(x => x.TenTaiKhoan == body.UserName&&x.isActive==true);
            if(user is not null)
            {
                var token = Generate(user, DateTime.Now.AddSeconds(15));
                var refreshToken = Generate(user, DateTime.Now.AddDays(30));
                user.MatKhau = "";
                return Ok(new
                {
                    token,
                    refreshToken,
                    info = user,
                }) ;
            }
            else
            {
                try
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.RoleGroup = "USER";
                    tk.isActive = true;
                    tk.TypeAccount = "PHONE";
                    tk.TenTaiKhoan = body.UserName;
                    _context.TaiKhoans.Add(tk);
                    await _context.SaveChangesAsync();
                    var token = Generate(tk, DateTime.Now.AddSeconds(15));
                    var refreshToken = Generate(tk, DateTime.Now.AddDays(30));
                    return Ok(new
                    {
                        token,
                        refreshToken,
                        info =tk,
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {

            try
            {
                var currentUser = GetCurrentUser();
                var user = _context.TaiKhoans.Include(x => x.DiaChis).FirstOrDefault(x => x.TenTaiKhoan == currentUser.TenTaiKhoan);
                return Ok(new
                {
                    user = new
                    {
                        userName = user.TenTaiKhoan,
                        role = user.Role,
                    }

                }); ;
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        private string Generate(TaiKhoan user,DateTime expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
           {
                new Claim(ClaimTypes.NameIdentifier,user.TenTaiKhoan),
            };
            if (user is not null&&user?.RoleGroupNavigation is not  null && user?.RoleGroupNavigation.RoleDetails is not null && user?.RoleGroupNavigation?.RoleDetails.Count>0)
            {
                foreach (var role in user?.RoleGroupNavigation?.RoleDetails)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleCode.Trim().ToString()));
                }
            }
           
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: expires,
              signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<TaiKhoan> Authenticate(LoginModel body)
        {
            try
            {
                var taikhoan = await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TenTaiKhoan.ToLower().Trim() == body.UserName.ToLower().Trim() && x.MatKhau.Trim() == body.Password.Trim());
                if (taikhoan != null)
                {
                    return taikhoan;

                }
                return null;
            }
            catch (Exception err)
            {
                return null;
            }
        }
        private TaiKhoan GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;
                return new TaiKhoan
                {
                    TenTaiKhoan = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }
            return null;
        }
    }
}

