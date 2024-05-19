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
    [Authorize(Roles = "SALEMNG")]
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public KhuyenMaiController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpGet("SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromQuery(Name = "s")] string s)
        {
            try
            {
                if (s is null || s.Length <= 0) return NotFound();
                var products= _context.SanPhams.Where(x=>x.Slug.Contains(s.Trim().ToLower())&&x.isSale==false&&x.ParentID==null);
                return Ok(products);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            try
            {
                var kms = _context.KhuyenMais;
                return Ok(kms);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> Gets(int ID)
        {
            try
            {
                var km = _context.KhuyenMais.Include(x=>x.ChiTietKhuyenMais).ThenInclude(x=>x.SanPhamNavigation).FirstOrDefault(x => x.ID == ID);
                return Ok(km);
            }
            catch (Exception err)
            {
                return BadRequest();
            }


        }
        [HttpPost]
        public async Task<IActionResult> Post(KhuyenMai body)
        {
            try
            {
                foreach(var item in body.ChiTietKhuyenMais)
                {
                    item.SanPhamNavigation = null;
                }
                _context.KhuyenMais.Add(body);
                _context.SaveChanges();
                return Ok(body);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        private decimal discountSum(decimal thanhTien,ChiTietKhuyenMai body)
        {
            try
            {
                if (body.KieuGiaTri==1)
                {
                    //gia tri
                    return(decimal) body.GiaTri;
                }
                else
                {
                    //%
                    if (body.GiaTri < 100 && body.GiaTri > 0)
                    {
                        var temp = thanhTien * (body.GiaTri / 100);
                        return (decimal)temp;
                    }
                    return 0;
                }
            }
            catch (Exception err)
            {
                return 0;
            }
        }
        [HttpPut("Apply")]
        public async Task<IActionResult> Apply(KhuyenMai body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                DateTime now = DateTime.Now;
                if (body.NgayKetThuc <= now)
                {
                    return BadRequest();
                }
                foreach (var item in body.ChiTietKhuyenMais)
                {
                    var product = _context.SanPhams.Include(x=>x.SanPhams).FirstOrDefault(x => x.MaSanPham == item.maSanPham);
                    if (product != null)
                    {
                        foreach(var proc in product.SanPhams)
                        {
                            proc.isSale = true;
                            proc.TienDaGiam = item.ThanhTien;
                            proc.GiaBanLe-=item.ThanhTien;
                            _context.Entry(proc).State = EntityState.Modified;
                        }
                        product.isSale = true;
                        product.TienDaGiam += item.ThanhTien;
                        product.GiaBanLe -= product.TienDaGiam;
                        _context.Entry(product).State = EntityState.Modified;
                    }
                }
                body.TrangThai = 1;
                _context.Entry(body).State = EntityState.Modified;
                _context.SaveChanges();
         
                trans.Commit();
                return Ok(body);
            }
            catch (Exception err)
            {
                trans.RollbackAsync();
                return BadRequest();
            }
        }
        [HttpPut("Cancel")]
        public  async Task<bool> Cancel (KhuyenMai body)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {

                foreach (var item in body.ChiTietKhuyenMais)
                {
                    var product = _context.SanPhams.Include(x => x.SanPhams).FirstOrDefault(x => x.MaSanPham == item.maSanPham);
                    if (product != null)
                    {
                        var dmgg = _context.DanhMucs.FirstOrDefault(x => x.Slug.Trim() == "giam-gia");
                        if (dmgg != null)
                        {
                            var dms = _context.DanhMucDetails.Where(x => x.MaSanPham == product.MaSanPham && x.danhMucId == dmgg.Id);
                            _context.DanhMucDetails.RemoveRange(dms);
                        }
                        foreach (var proc in product.SanPhams)
                        {
                            proc.isSale = false;
                            proc.GiaBanLe += proc.TienDaGiam;
                            proc.TienDaGiam = 0;
                            _context.Entry(proc).State = EntityState.Modified;
                        }
                        product.isSale = false;
                        product.GiaBanLe += product.TienDaGiam;
                        product.TienDaGiam = 0;
                        _context.Entry(product).State = EntityState.Modified;
                    }
                }
                body.TrangThai = -1;
                _context.Entry(body).State = EntityState.Modified;
                _context.SaveChanges();
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.RollbackAsync();
                return false;
            }
        }
    }
        //[HttpPut("Cancel")]
        //public async Task<IActionResult> Cancel(KhuyenMai body)
        //{
        //    var trans = _context.Database.BeginTransaction();
        //    try
        //    {
               
        //        foreach (var item in body.ChiTietKhuyenMais)
        //        {
        //            var product = _context.SanPhams.Include(x=>x.SanPhams).FirstOrDefault(x => x.MaSanPham == item.maSanPham);
        //            if (product != null)
        //            {
        //                foreach (var proc in product.SanPhams)
        //                {
        //                    proc.isSale = false;
        //                    proc.GiaBanLe += proc.TienDaGiam;
        //                    proc.TienDaGiam = 0;
        //                    _context.Entry(proc).State = EntityState.Modified;
        //                }
        //                product.isSale = false;
        //                product.GiaBanLe += product.TienDaGiam;
        //                product.TienDaGiam =0;
        //                _context.Entry(product).State = EntityState.Modified;
        //            }
        //        }
        //        body.TrangThai = -1;
        //        _context.Entry(body).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        trans.Commit();
        //        return Ok(body);
        //    }
        //    catch (Exception err)
        //    {
        //        trans.RollbackAsync();
        //        return BadRequest();
        //    }
        //}
    //}
}
