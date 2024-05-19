using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API_DSCS2_WEBBANGIAY.Services
{
    public class DiscountManager : IDiscountManager
    {
        private readonly ShoesEcommereContext _context;

        public DiscountManager(ShoesEcommereContext context)
        {
            _context = context;
        }

      
        public void CheckDiscount()
        {
            var trans = _context.Database.BeginTransaction();
            var now = DateTime.Now;
            try
            {
                var khuyenmais = _context.KhuyenMais.Include(x=>x.ChiTietKhuyenMais)
                    .Where(x=>x.TrangThai==1&& x.NgayKetThuc.Value.Date<=now.Date&&x.NgayKetThuc.Value.Month<=now.Month&&x.NgayKetThuc.Value.Year<=now.Year);
                if(khuyenmais.Count()>0)
                {
                    foreach(var item in khuyenmais)
                    {
                       if(item.TrangThai==1)
                        {
                            item.TrangThai = -1;
                            _context.Entry(item).State = EntityState.Modified;
                            foreach (var sp in item.ChiTietKhuyenMais.ToList())
                            {
                                var product = _context.SanPhams.Include(x => x.SanPhams).FirstOrDefault(x => x.MaSanPham == sp.maSanPham);
                                var dmgg = _context.DanhMucs.FirstOrDefault(x => x.Slug.Trim() == "giam-gia");
                                if(dmgg!=null)
                                {
                                    var dms = _context.DanhMucDetails.Where(x => x.MaSanPham == product.MaSanPham && x.danhMucId == dmgg.Id);
                                    _context.DanhMucDetails.RemoveRange(dms);
                                }


                                foreach (var proc in product.SanPhams.ToList())
                                {
                                    proc.GiaBanLe += proc.TienDaGiam;
                                    proc.TienDaGiam = 0;
                                    proc.isSale = false;
                                _context.Entry(proc).State = EntityState.Modified;
                                }
                                product.isSale = false;
                                product.GiaBanLe += product.TienDaGiam;
                                product.TienDaGiam = 0;
                                _context.Entry(product).State = EntityState.Modified;
                            }
                        }
                        
                    }
                }
                _context.SaveChanges();
                trans.Commit(); 
            }
            catch (Exception err)
            {
                trans.RollbackAsync();
            }
        }
    }
}
