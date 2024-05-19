using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle;
using Microsoft.AspNetCore.Hosting;
using API_DSCS2_WEBBANGIAY.Utils.Mail;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using API_DSCS2_WEBBANGIAY.Utils;
using Microsoft.AspNetCore.Authorization;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Authorize(Roles = "ORDERMNG")]

    public class DonHangController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;
        private readonly IHostingEnvironment _HostEnvironment;
        private readonly IConfiguration _config;
        private readonly IOptions<MailSettings> mailSettings;
        public DonHangController(ShoesEcommereContext context, IHostingEnvironment hostingEnvironment, IOptions<MailSettings> mailSettings, IConfiguration config)
        {
            this._config = config;
            _context = context;
            this._HostEnvironment = hostingEnvironment;
            this.mailSettings = mailSettings;
        }

        // GET: api/DonHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuNhapXuat>>> GetHoaDons([FromQuery(Name = "status")] string status, [FromQuery(Name = "page")] int? page, 
            [FromQuery(Name = "pageSize")] int? pageSize)
        {
            try
            {
                IQueryable<PhieuNhapXuat> phieuxuats = Enumerable.Empty<PhieuNhapXuat>().AsQueryable();
                phieuxuats = _context.PhieuNhapXuats.Include(x => x.CouponNavigation).ThenInclude(x => x.ChiTietCoupons).Include(x => x.ChiTietNhapXuats)
                    .ThenInclude(x => x.SanPhamNavigation).Include(x => x.DiaChiNavigation).OrderByDescending(x=>x.createdAt).Where(x=> x.LoaiPhieu == "PHIEUXUAT");
                switch (status)
                {
                    case "DaHuy":
                        phieuxuats = phieuxuats.Where(x => x.status == -1);
                        break;
                    case "HoanThanh":
                        phieuxuats = phieuxuats.Where(x => x.status == 1);
                        break;
                    default:
                        phieuxuats = phieuxuats;
                        break;

                }
                var result = await PaggingService<PhieuNhapXuat>.CreateAsync((IQueryable<PhieuNhapXuat>)phieuxuats, page ?? 1, pageSize??10);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PhieuNhapXuat>>> GetHoaDons(int id)
        {
            try
            {
                var hoadon = _context.PhieuNhapXuats.Include(x=>x.CouponNavigation).ThenInclude(x=>x.ChiTietCoupons).Include(x => x.ChiTietNhapXuats)
                    .ThenInclude(x => x.SanPhamNavigation).Include(x => x.DiaChiNavigation).FirstOrDefault(x => x.Id == id&&x.LoaiPhieu=="PHIEUXUAT");
                return Ok(hoadon);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("XuatKho")]
        public async Task<IActionResult> XuatKho(PhieuNhapXuat body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                List<SanPham> parents = new List<SanPham>();
                if(body.ChiTietNhapXuats.Count()<=0)
                {
                    return BadRequest();
                }
                foreach (var x in body.ChiTietNhapXuats)
                {
                    var product = x.SanPhamNavigation;
                    var khohang = await _context.KhoHangs.Include(x => x.SanPhamNavigation).FirstOrDefaultAsync(k => k.MaSanPham.Trim() == x.MaSanPham.Trim() && k.MaChiNhanh.Trim() == body.MaChiNhanh.Trim());
                    x.TenPhieu = "Xuất hàng khỏi kho";
                    if (product != null&&khohang !=null)
                    {
                        //KhoHang update
                        if(khohang.SoLuongCoTheban>=x.SoLuong&&khohang.SoLuongTon>=x.SoLuong)
                        {
                            
                            khohang.SoLuongTon -=x.SoLuong;
                            khohang.SoLuongCoTheban-=x.SoLuong;
                        }
                        else
                        {
                            return BadRequest("Số lượng hàng trong kho không cho phép");
                        }
                        //SanPham Update
                        if(product.SoLuongTon>=x.SoLuong&&product.SoLuongCoTheban>=x.SoLuong)
                        {
                            product.SoLuongDaBan+=x.SoLuong;
                            product.SoLuongTon-= x.SoLuong;
                            product.SoLuongCoTheban-= x.SoLuong;
                        }
                        else
                        {
                            return BadRequest("Số lượng hàng trong kho không cho phép");
                        }
                        //Parent Update
                        if(product is not null && product.SoLuongTon >= 0 && product.SoLuongCoTheban >= 0)
                        {
                            var parent = _context.SanPhams.FirstOrDefault(temp => temp.MaSanPham == x.SanPhamNavigation.ParentID);
                            if (parent is not null && parents.Any(x => x.MaSanPham == parent.MaSanPham))
                            {
                                var pro = parents.FirstOrDefault(x => x.MaSanPham == parent.MaSanPham);
                                if (pro != null)
                                {
                                    var index = parents.IndexOf(pro);
                                    if (index >= 0)
                                    {
                                        parents[index].SoLuongCoTheban -= x.SoLuong;
                                        parents[index].SoLuongTon -= x.SoLuong;
                                        parents[index].SoLuongDaBan += x.SoLuong; ;
                                    }
                                }
                            }
                            else
                            {
                                if (parent is not null)
                                {
                                    parent.SoLuongCoTheban -= x.SoLuong;
                                    parent.SoLuongTon -= x.SoLuong;
                                    parent.SoLuongDaBan += x.SoLuong; ;
                                    parents.Add(parent);
                                }
                            }

                        }
                        else
                        {
                            return BadRequest();
                        }
                        _context.Entry(product).State = EntityState.Modified;
                        _context.Entry(khohang).State = EntityState.Modified;
                        _context.Entry(x).State = EntityState.Modified;
                    }
             
                    else
                    {
                        break;
                    }
                   
                }
                body.DaXuatKho = true;
                body.steps = 4;
                _context.Entry(body).State = EntityState.Modified;
                _context.SanPhams.UpdateRange(parents);
                await _context.SaveChangesAsync();
                trans.Commit(); 
                return Ok(body);
            }
            catch (Exception ex)
            {
                trans.RollbackAsync();
                return BadRequest();
                
            }
        }
        private async Task<bool> DaGiaoHang(PhieuNhapXuat body)
        {
            try
            {
                body.steps = 4;
                body.DaNhanHang = true;
                body.status = 1;
                _context.Entry(body).State = EntityState.Modified;
                var clientURL = _config.GetSection("ClientURL").Value;
                var token = JWTHandler.Generate(DateTime.Now.AddDays(30));
                var link = $"{clientURL}/rating/{body.Id}/{token}";
                var bodyString = await new RatingStar(_HostEnvironment, body).RenderBody(link);
                var mailBody = new MailRequest()
                {
                    Body = bodyString.ToString(),
                    Subject = "ĐÁNH GIÁ",
                    ToEmail = body.DiaChiNavigation?.Email,

                };
                if(body.idTaiKhoan is not null)
                {
                    var user = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan.Trim() == body.idTaiKhoan.Trim());
                    if(user is not null)
                    {
                        user.SoLanMuaHang++;
                        user.TienThanhToan += body.ThanhTien;
                        _context.Entry(user).State = EntityState.Modified;
                    }
                }
                if(body.CouponCode is not null)
                {
                    var coupon = _context.Coupons.FirstOrDefault(x => x.MaCoupon == body.CouponCode);
                    if(coupon is not null)
                    {
                        coupon.SoLuong--;
                        _context.Entry(coupon.SoLuong).State = EntityState.Modified;

                    }
                }
                var mailSend = new MailService(mailSettings);
                mailSend.SendEmailAsync(mailBody);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpPut("ThanhToan")]
        public async Task<IActionResult>ThanhToan(PhieuNhapXuat body)
        {
            try
            {
                body.DaThanhToan = true;
                body.TienDaThanhToan = body.ThanhTien;
                body.status = 1;
                PhieuNhapXuat phieuThu = new PhieuNhapXuat();
                phieuThu.TienDaThanhToan = body.ThanhTien;
                phieuThu.LoaiPhieu = "PHIEUTHU";
                phieuThu.PhuongThucThanhToan = body.PhuongThucThanhToan;
                phieuThu.MaChiNhanh = body.MaChiNhanh;
                if(body.idTaiKhoan is not null)
                {
                    var taikhoan = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan == body.idTaiKhoan);
                    if(taikhoan is not null)
                    {
                        taikhoan.TienThanhToan += body.ThanhTien;
                        taikhoan.SoLanMuaHang++;
                        _context.Entry(taikhoan).State = EntityState.Modified;
                    }
                }
                await DaGiaoHang(body);
                _context.Entry(body).State = EntityState.Modified;
                _context.PhieuNhapXuats.Add(phieuThu);
                await _context.SaveChangesAsync();
                return Ok(body);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("HoanTien")]
        public async Task<IActionResult> HoanTien(PhieuNhapXuat body)
        {
            try
            {
                if ((bool)!body.DaThanhToan)
                {
                    return BadRequest("Không thể hoàn tiền khi chưa thanh toán");
                }
                body.TienDaThanhToan -= body.ThanhTien;
                body.DaHoanTien = true;
                if (body.idTaiKhoan is not null)
                {
                    var taikhoan = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan == body.idTaiKhoan);
                    if (taikhoan is not null)
                    {
                        taikhoan.TienThanhToan -= body.ThanhTien;
                        taikhoan.SoLanMuaHang--;
                        _context.Entry(taikhoan).State = EntityState.Modified;
                    }
                }
                PhieuNhapXuat phieuChi = new PhieuNhapXuat();
                phieuChi.TienDaThanhToan = body.TienDaThanhToan;
                phieuChi.LoaiPhieu = "PHIEUCHI";
                phieuChi.PhuongThucThanhToan = body.PhuongThucThanhToan;
                phieuChi.MaChiNhanh = body.MaChiNhanh;
                _context.Entry(body).State = EntityState.Modified;
                _context.PhieuNhapXuats.Add(phieuChi);
                await _context.SaveChangesAsync();
                return Ok(body);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutHoaDon(PhieuNhapXuat body)
        {
            try
            {
                _context.Entry(body).State = EntityState.Modified;
                _context.Entry(body.DiaChiNavigation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(body);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("HuyDon")]
        public async Task<IActionResult> HuyDon(PhieuNhapXuat body )
        {
            try
            {
                body.status = -1;
                _context.Entry(body).State = EntityState.Modified;
                if (body.CouponCode is not null)
                {
                    var coupon = _context.Coupons.FirstOrDefault(x => x.MaCoupon == body.CouponCode);
                    if (coupon is not null)
                    {
                        coupon.SoLuong--;
                        _context.Entry(coupon.SoLuong).State = EntityState.Modified;

                    }
                }
                _context.SaveChanges();
                return Ok(body); 
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("TraHang")]
        public async Task<IActionResult>  TraHang(PhieuNhapXuat body)
        {
                var trans = _context.Database.BeginTransaction();
            try
            {

                if (body.ChiTietNhapXuats.Count() <= 0||body.ChiTietNhapXuats.All(x=>x.deletedAT!=null))
                {
                    return BadRequest("Giá trị không hợp lệ");
                }
                
                List<SanPham> parents = new List<SanPham>();
                var phieuNhapXuat = _context.PhieuNhapXuats.FirstOrDefault(x => x.Id == body.Id);
                foreach (var item in body.ChiTietNhapXuats)
                {
                    if (item.deletedAT is null)
                    {
                        var khohang = _context.KhoHangs.FirstOrDefault(x => x.MaSanPham == item.MaSanPham && x.MaChiNhanh == body.MaChiNhanh);
                        var chitietnhapxuat = _context.ChiTietNhapXuats.FirstOrDefault(x => x.MaSanPham == item.MaSanPham && x.IDPN == item.IDPN);

                        if (khohang is not null)
                        {

                            var sanpham = item.SanPhamNavigation;
                            khohang.SoLuongTon += item.SoLuong;
                            khohang.SoLuongCoTheban += item.SoLuong;
                            if (sanpham is not null && sanpham.SoLuongTon >= 0 && sanpham.SoLuongCoTheban >= 0)
                            {
                                sanpham.SoLuongTon += item.SoLuong;
                                sanpham.SoLuongCoTheban += item.SoLuong;
                                sanpham.SoLuongDaBan -= item.SoLuong;
                                //
                                var parent = _context.SanPhams.FirstOrDefault(x => x.MaSanPham == item.SanPhamNavigation.ParentID);
                                if (parent is not null && parents.Any(x => x.MaSanPham == parent.MaSanPham))
                                {
                                    var pro = parents.FirstOrDefault(x => x.MaSanPham == parent.MaSanPham);
                                    if (pro != null)
                                    {
                                        var index = parents.IndexOf(pro);
                                        if (index >= 0)
                                        {
                                            parents[index].SoLuongCoTheban += item.SoLuong;
                                            parents[index].SoLuongTon += item.SoLuong;
                                            parents[index].SoLuongDaBan -= item.SoLuong; ;
                                        }
                                    }
                                }
                                else
                                {
                                    if (parent is not null)
                                    {
                                        parent.SoLuongCoTheban += item.SoLuong;
                                        parent.SoLuongTon += item.SoLuong;
                                        parent.SoLuongDaBan -= item.SoLuong; ;
                                        parents.Add(parent);
                                    }
                                }

                                _context.Entry(sanpham).State = EntityState.Modified;
                                _context.Entry(khohang).State = EntityState.Modified;
                            }
                            else
                            {
                                return BadRequest();
                            }
                            phieuNhapXuat.TongSoLuong -= item.SoLuong;
                            phieuNhapXuat.ThanhTien -= item.ThanhTien;

                            if (chitietnhapxuat.SoLuong == item.SoLuong)
                            {
                                chitietnhapxuat.deletedAT = DateTime.Now;
                                _context.Entry(chitietnhapxuat).State = EntityState.Modified;
                            }
                            else
                            {
                                chitietnhapxuat.SoLuong -= item.SoLuong;
                                chitietnhapxuat.ThanhTien -= item.ThanhTien;
                                _context.Entry(chitietnhapxuat).State = EntityState.Modified;
                            }

                        }
                    }
                 
                    
                }
                if (phieuNhapXuat.CouponCode is not null)
                {
                    var coupon = _context.Coupons.FirstOrDefault(x => x.MaCoupon == body.CouponCode);
                    if (coupon is not null)
                    {
                        coupon.SoLuong--;
                        _context.Entry(coupon.SoLuong).State = EntityState.Modified;

                    }
                }
                _context.SanPhams.UpdateRange(parents);
                _context.Entry(phieuNhapXuat).State = EntityState.Modified;
                phieuNhapXuat.status = -1;
                phieuNhapXuat.steps=-1;
                phieuNhapXuat.DaTraHang =true;
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return Ok(phieuNhapXuat);
            }
            catch (Exception err)
                {
                trans.RollbackAsync();  
                return BadRequest();
            }
        }
    }
}
