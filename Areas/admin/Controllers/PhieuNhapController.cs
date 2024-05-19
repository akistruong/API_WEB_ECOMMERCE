using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Authorize(Roles = "PNMANAGER")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class PhieuNhapsController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public PhieuNhapsController(ShoesEcommereContext context)
        {
            _context = context;
        }

        // GET: api/PhieuNhaps
        [HttpGet]
        public async Task<IActionResult> GetPhieuNhaps([FromQuery(Name = "status")] string status)
        {
            try
            {
                IQueryable<PhieuNhapXuat> phieunhaps = Enumerable.Empty<PhieuNhapXuat>().AsQueryable();
                phieunhaps = _context.PhieuNhapXuats.OrderByDescending(x=>x.createdAt).Where(x => x.LoaiPhieu == "PHIEUNHAP");
                switch (status)
                {
                    case "DaHuy":
                        phieunhaps = phieunhaps.Where(x => x.status == -1);
                        break;
                    case "HoanThanh":
                        phieunhaps = phieunhaps.Where(x => x.status == 1);
                        break;
                    default:
                        
                        break;

                }
                return Ok(phieunhaps);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // GET: api/PhieuNhaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuNhapXuat>> GetPhieuNhap(int id)
        {
            var phieuNhap = await _context.PhieuNhapXuats.Include(x=>x.ChiTietNhapXuats).ThenInclude(x=>x.SanPhamNavigation).Include(x=>x.NhaCungCapNavigation).ThenInclude(x=>x.DiaChiNavigation).FirstOrDefaultAsync(x=>x.Id ==id);
            if (phieuNhap == null)
            {
                return NotFound();
            }
            return phieuNhap;
        }



        [HttpPut("HoanTien")]
        public  async Task<IActionResult> HoanTien(PhieuNhapXuat body)
        {
            try
            {
                if ((bool)!body.DaThanhToan)
                {
                    return BadRequest();
                }
                body.TienDaThanhToan -= body.ThanhTien;
                body.DaHoanTien = true;
                PhieuNhapXuat phieuThu = new PhieuNhapXuat();
                phieuThu.TienDaThanhToan = body.ThanhTien;
                phieuThu.LoaiPhieu = "PHIEUTHU";
                phieuThu.PhuongThucThanhToan = body.PhuongThucThanhToan;
                phieuThu.MaChiNhanh = body.MaChiNhanh;
                _context.PhieuNhapXuats.Add(phieuThu);
                _context.Entry(body).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(body);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("TraHang")]
        public async Task<IActionResult> TraHang(PhieuNhapXuat body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {

                if ((bool)!body?.DaNhapHang)
                {
                    return BadRequest();
                }
                if (body.ChiTietNhapXuats.Count() <= 0 || body.ChiTietNhapXuats.All(x => x.deletedAT != null))
                {
                    return BadRequest("Đơn này đã hoàn trả toàn phần");
                }
                List<SanPham> parents = new List<SanPham>();
                var phieuNhapXuat = _context.PhieuNhapXuats.FirstOrDefault(x => x.Id == body.Id);

                foreach (var item in body.ChiTietNhapXuats)
                {
                  if(item.deletedAT is  null)
                    {
                        var khohang = _context.KhoHangs.FirstOrDefault(x => x.MaSanPham == item.MaSanPham && x.MaChiNhanh == body.MaChiNhanh);
                        var chitietnhapxuat = _context.ChiTietNhapXuats.FirstOrDefault(x => x.MaSanPham == item.MaSanPham && x.IDPN == item.IDPN);
                        if (khohang is not null && khohang.SoLuongTon - item.SoLuong == 0 && khohang.SoLuongCoTheban - item.SoLuong == 0)
                        {
                            var sanpham = item.SanPhamNavigation;
                            khohang.SoLuongTon -= item.SoLuong;
                            khohang.SoLuongCoTheban -= item.SoLuong;
                            if (sanpham is not null && sanpham.SoLuongTon >= 0 && sanpham.SoLuongCoTheban >= 0)
                            {
                                sanpham.SoLuongTon -= item.SoLuong;
                                sanpham.SoLuongCoTheban -= item.SoLuong;
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
                                            parents[index].SoLuongCoTheban -= item.SoLuong;
                                            parents[index].SoLuongTon -= item.SoLuong;
                                        }
                                    }
                                }
                                else
                                {
                                    if (parent is not null)
                                    {
                                        parent.SoLuongCoTheban -= item.SoLuong;
                                        parent.SoLuongTon -= item.SoLuong;
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
                            //_context.ChiTietNhapXuats.Remove(item);
                            //_context.Entry(item).State = EntityState.Modified;
                            //phieuNhapXuat.ChiTietNhapXuats.Remove(item);
                        }
                        else if (khohang is not null && khohang.SoLuongTon - item.SoLuong > 0 && khohang.SoLuongCoTheban - item.SoLuong > 0)
                        {
                            var sanpham = item.SanPhamNavigation;
                            khohang.SoLuongTon -= item.SoLuong;
                            khohang.SoLuongCoTheban -= item.SoLuong;
                            if (sanpham is not null && sanpham.SoLuongTon >= 0 && sanpham.SoLuongCoTheban >= 0)
                            {
                                sanpham.SoLuongTon -= item.SoLuong;
                                sanpham.SoLuongCoTheban -= item.SoLuong;
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
                                            parents[index].SoLuongCoTheban -= item.SoLuong;
                                            parents[index].SoLuongTon -= item.SoLuong;
                                        }
                                    }
                                }
                                else
                                {
                                    if (parent is not null)
                                    {
                                        parent.SoLuongCoTheban -= item.SoLuong;
                                        parent.SoLuongTon -= item.SoLuong;
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
                        }
                        else
                        {
                            return BadRequest();

                        }
                        phieuNhapXuat.TongSoLuong -= item.SoLuong;
                        if(phieuNhapXuat.ChietKhau>0)
                        {
                            float ChietKhauValue =(float)phieuNhapXuat.ChietKhau / 100;
                            phieuNhapXuat.ThanhTien =(phieuNhapXuat.ThanhTien /(decimal)ChietKhauValue);
                            phieuNhapXuat.ThanhTien -= item.ThanhTien;
                            phieuNhapXuat.ThanhTien = (decimal)(phieuNhapXuat.ThanhTien * (decimal)ChietKhauValue);
                        }
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

                _context.SanPhams.UpdateRange(parents);
                phieuNhapXuat.status = -1;
                phieuNhapXuat.DaTraHang = true;
                _context.Entry(phieuNhapXuat).State = EntityState.Modified;
                await trans.CommitAsync();
                await _context.SaveChangesAsync();
                return Ok(body);
            }
            catch (Exception err)
            {
                trans.RollbackAsync();
                return BadRequest();
            }
        }
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieuNhap(string id)
        {
            var phieuNhap = await _context.PhieuNhapXuats.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            _context.PhieuNhapXuats.Remove(phieuNhap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("ThanhToan")]
        public async Task<IActionResult> ThanhToan(PhieuNhapXuat body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
             
                if ((bool)body.DaNhapHang)
                {
                    body.steps = 4;
                    body.status = 1;
                }
                body.DaThanhToan = true;
                body.TienDaThanhToan = body.ThanhTien;
                _context.Entry(body).State = EntityState.Modified;
                PhieuNhapXuat phieuChi = new PhieuNhapXuat();
                phieuChi.TienDaThanhToan = body.ThanhTien;
                phieuChi.LoaiPhieu = "PHIEUCHI";
                phieuChi.PhuongThucThanhToan = body.PhuongThucThanhToan;
                phieuChi.MaChiNhanh = body.MaChiNhanh;
                _context.PhieuNhapXuats.Add(phieuChi);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return Ok(body);
            }
            catch (Exception err)
            {
                return BadRequest();
                 trans.RollbackAsync();
            }
        }
        [HttpPost]
        public async Task<ActionResult<PhieuNhapXuat>> PostPhieuNhap(PhieuNhapXuat body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                if (body.steps <= 2)
                {
                    foreach (var item in body.ChiTietNhapXuats)
                    {
                        var khohang = _context.KhoHangs.FirstOrDefault(x => x.MaSanPham == item.MaSanPham && x.MaChiNhanh == body.MaChiNhanh);
                        item.TenPhieu = "Nhập hàng vào kho";
                        if (khohang is not null)
                        {
                            khohang.SoLuongHangDangVe += item.SoLuong;
                            _context.KhoHangs.Update(khohang);
                        }

                    }
                }

                body.status = 0;
                body.NhaCungCapNavigation = null;
                _context.PhieuNhapXuats.Add(body);

                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return Ok(body);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
                await trans.RollbackAsync();
            }

        }
        [HttpPut("NhapKho")]
        public async Task<IActionResult> NhapKho(PhieuNhapXuat body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                List<SanPham> parents = new List<SanPham>();
                foreach(var item in body.ChiTietNhapXuats)
                {
                    var khohang = _context.KhoHangs.FirstOrDefault(x => x.MaSanPham == item.MaSanPham&&x.MaChiNhanh==body.MaChiNhanh);
                    
                    if(khohang is not null&&khohang.SoLuongTon>=0&&khohang.SoLuongCoTheban>=0)
                    {
                        var sanpham = item.SanPhamNavigation;
                        khohang.SoLuongTon += item.SoLuong;
                        khohang.SoLuongCoTheban += item.SoLuong;
                        khohang.SoLuongHangDangVe -= item.SoLuong;
                        if(sanpham is not null&&sanpham.SoLuongTon>=0&&sanpham.SoLuongCoTheban>=0)
                        {
                            sanpham.SoLuongTon += item.SoLuong;
                            sanpham.SoLuongCoTheban += item.SoLuong;
                            //
                            var parent = _context.SanPhams.FirstOrDefault(x=>x.MaSanPham==item.SanPhamNavigation.ParentID);
                            if (parent is not null && parents.Any(x => x.MaSanPham == parent.MaSanPham))
                            {
                                var pro = parents.FirstOrDefault(x => x.MaSanPham == parent.MaSanPham);
                                if(pro !=null)
                                {
                                    var index = parents.IndexOf(pro);
                                    if(index >= 0)
                                    {
                                        parents[index].SoLuongCoTheban += item.SoLuong;
                                        parents[index].SoLuongTon +=item.SoLuong;
                                    }
                                }
                            }
                            else
                            {
                                if (parent is not null)
                                {
                                    parent.SoLuongCoTheban += item.SoLuong;
                                    parent.SoLuongTon += item.SoLuong;
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
                    }
                }
                body.DaNhapHang = true;
                body.steps = 3;
                if((bool)body.DaThanhToan)
                {
                    body.steps = 4;
                    body.status = 1;
                }
                _context.SanPhams.UpdateRange(parents);
                _context.Entry(body).State = EntityState.Modified;
                _context.SaveChanges();
                await trans.CommitAsync();
                return Ok(body);
            }
            catch(Exception err)
            {
                return BadRequest();
                 trans.RollbackAsync();
            }
        }
        

    }
}
