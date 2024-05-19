using API_DSCS2_WEBBANGIAY.Areas.admin.Models;
using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public BaoCaoController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult>DoanhThuTheoThoiGian(BaoCaoParams body)
        {
            List<PhieuNhapXuat> pnxs = new List<PhieuNhapXuat>();
            try
            {
                if(body.Type=="date")
                {
                    var start = body.start.Day;
                    var end = body.end.Day;
                    if(start > end)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        for(int i = start; i <= end; i++)
                        {
                            
                            var pnx = _context.PhieuNhapXuats.Where(x => x.createdAt.Day == i&&x.LoaiPhieu.Trim()=="PHIEUXUAT"&&x.status>-1);
                            if(body.maChiNhanh is not null && body.maChiNhanh.Length>0)
                            {
                                pnx = pnx.Where(x => x.MaChiNhanh == body.maChiNhanh);
                            }
                           if(pnx !=null&&pnx.Count()>0)
                            {
                                var soluong = pnx.Sum(x => x.TongSoLuong);
                                var ship = pnx.Sum(x => x.Phiship);
                                var tienHang = pnx.Sum(x => x.TienDaThanhToan);
                                var chietKhau = pnx.Sum(x => x.TienDaGiam);
                                var date = pnx.ToList()[0].createdAt;
                                var baocao = new PhieuNhapXuat { Phiship = ship, ThanhTien = tienHang, TongSoLuong = soluong, TienDaGiam = chietKhau,createdAt= date };
                                pnxs.Add(baocao);
                            }
                        }
                    }
                }else if(body.Type=="month")
                {
                    var start = body.start.Month;
                    var end = body.end.Month;
                    if (start > end)
                    {
                        return BadRequest();
                    }
                    for (int i = start; i <= end; i++)
                    {

                        var pnx = _context.PhieuNhapXuats.Where(x => x.createdAt.Month == i && x.LoaiPhieu == "PHIEUXUAT");
                        if (body.maChiNhanh is not null && body.maChiNhanh.Length > 0)
                        {
                            pnx = pnx.Where(x => x.MaChiNhanh == body.maChiNhanh);
                        }
                        if (pnx != null && pnx.Count() > 0)
                        {
                            var soluong = pnx.Sum(x => x.TongSoLuong);
                            var ship = pnx.Sum(x => x.Phiship);
                            var tienHang = pnx.Sum(x => x.ThanhTien);
                            var chietKhau = pnx.Sum(x => x.TienDaGiam);
                            var date = pnx.ToList()[0].createdAt;
                            var baocao = new PhieuNhapXuat { Phiship = ship, ThanhTien = tienHang, TongSoLuong = soluong, TienDaGiam = chietKhau, createdAt = date };
                            pnxs.Add(baocao);
                        }
                    }
                }
                else
                {
                    var start = body.start.Year;
                    var end = body.end.Year;
                    if (start > end)
                    {
                        return BadRequest();
                    }
                    for (int i = start; i <= end; i++)
                    {

                        var pnx = _context.PhieuNhapXuats.Where(x => x.createdAt.Year == i && x.LoaiPhieu == "PHIEUXUAT");
                        if (body.maChiNhanh is not null && body.maChiNhanh.Length > 0)
                        {
                            pnx = pnx.Where(x => x.MaChiNhanh == body.maChiNhanh);
                        }
                        if (pnx != null && pnx.Count() > 0)
                        {
                            var soluong = pnx.Sum(x => x.TongSoLuong);
                            var ship = pnx.Sum(x => x.Phiship);
                            var tienHang = pnx.Sum(x => x.ThanhTien);
                            var chietKhau = pnx.Sum(x => x.TienDaGiam);
                            var date = pnx.ToList()[0].createdAt;
                            var baocao = new PhieuNhapXuat { Phiship = ship, ThanhTien = tienHang, TongSoLuong = soluong, TienDaGiam = chietKhau, createdAt = date };
                            pnxs.Add(baocao);
                        }
                    }
                }
                    return Ok(pnxs);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }
    }
}
