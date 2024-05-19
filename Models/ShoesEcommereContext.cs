using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class ShoesEcommereContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public ShoesEcommereContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ShoesEcommereContext(DbContextOptions<ShoesEcommereContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
        public virtual DbSet<BoSuuTap> BoSuuTaps { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; }
        public virtual DbSet<ChiTietHinhAnh> ChiTietHinhAnhs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<ReviewStar> ReviewStars { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<RoomMessage> RoomMessages { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<VAT> Vats { get; set; }
        public virtual DbSet<Branchs> Branchs { get; set; }
        public virtual DbSet<GenKey> Keys { get; set; }
        public virtual DbSet<ChiNhanh_SanPham> KhoHangs{ get; set; }
        public virtual DbSet<NCC> NhaCungCap{ get; set; }
        public virtual DbSet<PhieuNhapXuat> PhieuNhapXuats { get; set; }
        public virtual DbSet<ChiTietNhapXuat> ChiTietNhapXuats { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<ChiTietCoupon> ChiTietCoupons { get; set; }
        public virtual DbSet<ChiTietBST> ChiTietBSTs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public virtual DbSet<StarReviewDetail> StarReviewDetails { get; set; }
        public virtual DbSet<RoleDetails> RoleDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleGroup> RoleGroup { get; set; }
        public virtual DbSet<Coupons_KhachHang> Coupons_KhachHangs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectString = Configuration.GetConnectionString("ShoesEcommere");
                optionsBuilder.UseSqlServer(connectString);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        private List<Size> SizeGenerate()
        {
            List<Size> sizes = new List<Size>();    
            for(int i =25;i<=47;i++)
            {
                sizes.Add(new Size {Id= i.ToString(), Size1 = i.ToString() });
            }
                sizes.Add(new Size {Id= "S", Size1 = "S" });
                sizes.Add(new Size {Id= "M", Size1 = "M" });
                sizes.Add(new Size {Id= "L", Size1 = "L" });
                sizes.Add(new Size {Id= "XL", Size1 = "XL" });
                sizes.Add(new Size {Id= "2XL", Size1 = "2XL" });
                sizes.Add(new Size {Id= "3XL", Size1 = "3XL" });
                sizes.Add(new Size {Id= "4XL", Size1 = "4XL" });
            return sizes;
        }
        private List<Role>RoleGenerate()
        {
            List<Role> roles = new List<Role>();

            roles.Add(new Role { RoleCode = "CATEMNG", RoleDsc = "Thêm, sửa, xóa, danh mục", RoleName = "Quản lý danh mục" });
            roles.Add(new Role { RoleCode = "MEMANAGER", RoleDsc = "Quản lý tài khoản hội viên", RoleName = "Quản lý thành viên" });
            roles.Add(new Role { RoleCode = "HOMEADMIN", RoleDsc = "Xem tổng quan về cửa hàng, doanh thu, sản phẩm nổi bật,...", RoleName = "Trang chủ admin" });
            roles.Add(new Role { RoleCode = "HOMEMANAGER", RoleDsc = "Xem tổng quan về đơn hàng, kho hàng dành cho người quản lý", RoleName = "Trang chủ manager" });
            roles.Add(new Role { RoleCode = "BSTMNG", RoleName = "Quản lý bộ sưu tập" });
            roles.Add(new Role { RoleCode = "ROLEMNG", RoleName = "Quản lý phân quyền" });
            roles.Add(new Role { RoleCode = "PNMANAGER", RoleName = "Quản lý phiếu nhập" });
            roles.Add(new Role { RoleCode = "ORDERMNG", RoleName = "Quản lý đơn hàng" });
            roles.Add(new Role { RoleCode = "INVENTORYMNG", RoleName = "Quản lý kho hàng" });
            roles.Add(new Role { RoleCode = "COUPONMNG", RoleName = "Quản lý Coupon" });
            roles.Add(new Role { RoleCode = "SALEMNG", RoleName = "Quản lý Khuyến mãi" });
            roles.Add(new Role { RoleCode = "PRODMNG", RoleName = "Quản lý Sản phẩm" });
            roles.Add(new Role { RoleCode = "TKDTMNG", RoleName = "Thống kê doanh thu" });
            roles.Add(new Role { RoleCode = "CUSTOMERMNG", RoleName = "Quản lý khách hàng" });
            return roles;
        }
        private List<LoaiPhieu> GenerateLoaiPhieu()
        {
            List<LoaiPhieu> lps = new List<LoaiPhieu>();
            lps.Add(new LoaiPhieu { MaPhieu = "PHIEUNHAP" });
            lps.Add(new LoaiPhieu { MaPhieu = "PHIEUXUAT" });
            lps.Add(new LoaiPhieu { MaPhieu = "PHIEUTHU" });
            lps.Add(new LoaiPhieu { MaPhieu = "PHIEUCHI" });
            return lps;
        }
        private List<RoleDetails>RoleDetailGenerate()
        {
            List<RoleDetails> roleDetails = new List<RoleDetails>();
            foreach(var role in RoleGenerate())
            {
                roleDetails.Add(new Models.RoleDetails { RoleCode = role.RoleCode, RoleGroup = "ADMIN" });
                if(role.RoleCode== "MEMANAGER")
                {
                roleDetails.Add(new Models.RoleDetails { RoleCode = role.RoleCode, RoleGroup = "USER" });
                }
            }
            return roleDetails;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
          
          modelBuilder.Entity<Coupons_KhachHang>(entity =>
            {

                entity.HasKey(e => new { e.MaCoupon, e.TenTaiKhoan });
                
                entity.HasOne(e => e.CouponNavigation).WithMany(x => x.CouponsKhachHang).HasForeignKey(x => x.MaCoupon).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(e => e.TaiKhoanNavigation).WithMany(x => x.CouponsKhachHangs).HasForeignKey(x => x.TenTaiKhoan).OnDelete(DeleteBehavior.Cascade); ;

            });
            modelBuilder.Entity<RoleGroup>(entity =>
            {

                entity.HasKey(e => e.GroupName);
                entity.Property(e => e.GroupName).HasColumnType("char(20)");
                entity.Property(e => e.GroupDsc).HasColumnType("nvarchar(100)");

            });
            modelBuilder.Entity<RoleDetails>(entity =>
            {

                entity.HasKey(e => new { e.RoleCode, e.RoleGroup });
                entity.HasOne(e => e.IdRoleNavigation).WithMany(x => x.RoleDetails).HasForeignKey(x => x.RoleCode).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(e => e.RoleGroupNavigation).WithMany(x => x.RoleDetails).HasForeignKey(x => x.RoleGroup).OnDelete(DeleteBehavior.Cascade); ;

            });
            modelBuilder.Entity<Role>(entity =>
            {

                entity.HasKey(e => e.RoleCode);
                entity.Property(e => e.RoleCode).HasColumnType("char(15)");


            });
            modelBuilder.Entity<StarReviewDetail>(entity =>
            {

                entity.HasKey(e => new { e.StarReviewID ,e.IDDonHang,e.ID});
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne(e => e.ReviewStarNavigation).WithMany(x => x.StarReviewDetails).HasForeignKey(x => x.StarReviewID).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(e => e.HoaDonNavigation).WithMany(x => x.StarReviewDetails).HasForeignKey(x => x.IDDonHang).OnDelete(DeleteBehavior.Cascade); ;

            });
            modelBuilder.Entity<ChiTietKhuyenMai>(entity =>
            {

                entity.HasKey(e => new { e.maSanPham, e.IDDotKhuyenMai });
                entity.HasOne(e => e.SanPhamNavigation).WithMany(x => x.ChiTietKhuyenMais).HasForeignKey(x => x.maSanPham).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.KhuyenMaiNavigation).WithMany(x => x.ChiTietKhuyenMais).HasForeignKey(x => x.IDDotKhuyenMai).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<KhuyenMai>(entity =>
            {

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.MoTa).HasColumnType("ntext");


            });
            modelBuilder.Entity<ChiTietBST>(entity =>
            {

                entity.HasKey(e => new{ e.IDBST,e.MaSanPham});
                entity.HasOne(e => e.SanPhamNavigation).WithMany(x => x.ChiTietBSTs).HasForeignKey(x => x.MaSanPham).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.BSTNavigation).WithMany(x => x.ChiTietBSTs).HasForeignKey(x => x.IDBST).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Coupon>(entity =>
            {

                entity.HasKey(e => e.MaCoupon);

                entity.Property(x => x.MaCoupon).HasColumnType("char(15)");
                entity.HasOne(e => e.ChiNhanhNavigation).WithMany(x => x.Coupons).HasForeignKey(x=>x.MaChiNhanh).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ChiTietCoupon>(entity =>
            {
                entity.HasKey(e => new {e.MaSanPhamX,e.MaSanPhamY,e.MaCoupon});
                entity.Property(e => e.LoaiSanPham).HasColumnType("char(5)");
                entity.Property(x => x.MaCoupon).HasColumnType("char(15)");
                entity.HasOne(e => e.SanPhamXNavigation).WithMany(x => x.ChiTietCouponsX).HasForeignKey(x => x.MaSanPhamX).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.SanPhamYNavigation).WithMany(x => x.ChiTietCouponsY).HasForeignKey(x => x.MaSanPhamY).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.CouponNavigation).WithMany(x => x.ChiTietCoupons).HasForeignKey(x => x.MaCoupon);

            });
            modelBuilder.Entity<LoaiPhieu>(entity =>
            {

                entity.HasKey(e => e.MaPhieu);
                entity.Property(x => x.MaPhieu).HasColumnType("char(10)");

            });
            modelBuilder.Entity<ChiTietNhapXuat>(entity =>
            {
                entity.HasKey(e => new { e.MaSanPham, e.IDPN});
                entity.Property(e => e.DVT).HasColumnType("char(10)");
                entity.Property(e => e.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                entity.HasOne(e => e.SanPhamNavigation).WithMany(x => x.ChiTietNhapXuats).HasForeignKey(x => x.MaSanPham).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.PhieuNhapXuatNavigation).WithMany(x => x.ChiTietNhapXuats).HasForeignKey(x => x.IDPN).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PhieuNhapXuat>(entity =>
            {

                entity.HasKey(e => e.Id);
                entity.Property(x => x.createdAt).HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.HasOne(e => e.NhaCungCapNavigation).WithMany(x => x.PhieuNhapXuats).HasForeignKey(x => x.IDNCC).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.LoaiPhieuNavigation).WithMany(x => x.PhieuNhapXuats).HasForeignKey(x => x.LoaiPhieu).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.TenTaiKhoanNavigation).WithMany(x => x.PhieuNhapXuats).HasForeignKey(x => x.idTaiKhoan).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.DiaChiNavigation).WithMany(x => x.PhieuNhapXuats).HasForeignKey(x => x.IdDiaChi).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.KhoHangNavigation).WithMany(x => x.PhieuNhapXuats).HasForeignKey(x => x.MaChiNhanh).OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<NCC>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");
                entity.Property(e => e.Phone).HasColumnType("char(10)");
                entity.Property(e => e.Email).HasColumnType("char(50)");
                entity.HasOne(e => e.DiaChiNavigation).WithMany(e => e.NhaCungCaps).HasForeignKey(x => x.IDDiaChi).OnDelete(DeleteBehavior.Cascade); ;
            });
            modelBuilder.Entity<ChiNhanh_SanPham>(entity =>
            {
                entity.HasKey(e => new { e.MaChiNhanh ,e.MaSanPham});
                entity.Property(e => e.ID).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore); ; ;
                entity.HasOne(e => e.SanPhamNavigation).WithMany(e => e.KhoHangs).HasForeignKey(x => x.MaSanPham).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(e => e.BranchNavigation).WithMany(e => e.KhoHangs).HasForeignKey(x => x.MaChiNhanh).OnDelete(DeleteBehavior.Cascade); ;
            });
            modelBuilder.Entity<GenKey>(entity =>
            {
                entity.Property(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Id).HasColumnType("char(10)");
                entity.Property(e => e.Size1).HasColumnName("size");
            });
            modelBuilder.Entity<Branchs>(entity =>
            {
                entity.HasKey(e => e.MaChiNhanh);
                entity.Property(e => e.MaChiNhanh).HasColumnType("char(20)");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.TenChiNhanh).HasColumnType("nvarchar(50)");
                
            });
            modelBuilder.Entity<VAT>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");
            });
            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e =>e.ID);
                entity.Property(e=>e.ID).ValueGeneratedOnAdd();
                entity.Property(e=>e.Name).HasColumnType("nvarchar(50)");
                entity.Property(e=>e.Slug).HasColumnType("char(50)");
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");

            });
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd() ;
                entity.HasOne(e => e.MessageNavigation).WithMany(x => x.Messages).HasForeignKey(x => x.ParentMessageID);
                entity.HasOne(e => e.userNavigation).WithMany(x => x.Messages).HasForeignKey(x => x.creatorID);
            });
            modelBuilder.Entity<RoomMessage>(entity =>
            {
                entity.HasKey(e => new { e.MessageID, e.MaSanPham, e.UserID });
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne(e => e.SanPhamNavigation).WithMany(x => x.RoomMessages).HasForeignKey(x => x.MaSanPham).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.TaiKhoanNavigation).WithMany(x => x.RoomMessages).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.MessageNavigation).WithMany(x => x.RoomMessages).HasForeignKey(x => x.MessageID);
            });

            modelBuilder.Entity<DiaChi>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Phone).HasColumnType("char(10)");
                entity.Property(e => e.Email).HasColumnType("char(254)");
                entity.Property(e => e.Name).HasColumnType("nvarchar(30)");
                entity.HasOne(e => e.KhachHangNavigation).WithMany(e => e.DiaChis).HasForeignKey(x => x.IDKH);
                entity.HasOne(e => e.TaiKhoanNavigation).WithMany(e => e.DiaChis).HasForeignKey(x => x.TenTaiKhoan);
            });
            modelBuilder.Entity<DanhMucDetails>(entity =>
            {
                entity.HasKey(e => new { e.danhMucId, e.MaSanPham });
                entity.HasOne(e => e.IdDanhMucNavigation).WithMany(e => e.DanhMucDetails).HasForeignKey(x => x.danhMucId).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(e => e.IdSanPhamNavigation).WithMany(e => e.DanhMucDetails).HasForeignKey(x => x.MaSanPham).OnDelete(DeleteBehavior.Cascade); ;

            });
            modelBuilder.Entity<BoSuuTap>(entity =>
            {
                entity.ToTable("BoSuuTap");

                entity.Property(e => e.Id).HasColumnName("_id");
                entity.Property(e => e.Img).HasColumnType("text");             
               

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Slug)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("slug")
                    .IsFixedLength(true);

                entity.Property(e => e.TenBoSuuTap).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.ToTable("DanhMuc");

               

                entity.Property(e => e.Id).HasColumnName("_id");


                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("slug")
                    .IsFixedLength(true);

                entity.Property(e => e.TenDanhMuc)
                    .IsRequired()
                    .HasMaxLength(30);
            });



            modelBuilder.Entity<HinhAnh>(entity =>
            {
                entity.ToTable("HinhAnh");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.FileName)
                    .HasColumnType("char(255)")
                    .HasColumnName("file_name");
            });

            modelBuilder.Entity<ChiTietHinhAnh>(entity =>
            {
                entity.HasKey(e => new { e.MaSanPham, e.IdHinhAnh,e.IdMaMau })
                    .HasName("pk_hinhanh_sanpham");

                entity.ToTable("HinhAnh_SanPham");

                entity.HasIndex(e => e.IdHinhAnh, "IX_HinhAnh_SanPham__id_HinhAnh");

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IdHinhAnh).HasColumnName("_id_HinhAnh");
                entity.Property(e => e.IdMaMau).HasColumnType("char").HasMaxLength(20);
                entity.HasOne(d => d.IdHinhAnhNavigation)
                    .WithMany(p => p.ChiTietHinhAnhs)
                    .HasForeignKey(d => d.IdHinhAnh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_cthd_hinhanh");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHinhAnhs)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_cthd_sanpham");

            });
            modelBuilder.Entity<ChiTietHinhAnh>(entity =>
            {
                entity.HasKey(e => new { e.MaSanPham, e.IdHinhAnh, e.IdMaMau })
                    .HasName("pk_CTHA");

                entity.ToTable("ChiTietHinhAnh");

                entity.HasIndex(e => e.IdHinhAnh, "IX_ChiTietHinhAnh__id_HinhAnh");

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IdHinhAnh).HasColumnName("_id_HinhAnh");
                entity.Property(e => e.IdMaMau).HasColumnType("char").HasMaxLength(20);
                entity.HasOne(d => d.IdHinhAnhNavigation)
                    .WithMany(p => p.ChiTietHinhAnhs)
                    .HasForeignKey(d => d.IdHinhAnh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_ctha_hinhanh");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHinhAnhs)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_ctha_sanpham");

                entity.HasOne(d => d.MauSacNavigation)
                    .WithMany(p => p.ChiTietHinhAnhs)
                    .HasForeignKey(d => d.IdMaMau)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_ctha_mausac");
            });
           
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_KH");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("KhachHang");
                entity.Property(e => e.GiamGia).HasColumnType("int").HasDefaultValueSql("((0))");
               
                entity.Property(e => e.TienThanhToan).HasColumnType("money").HasDefaultValueSql("((0))");
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

             

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");
                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.TenKhachHang)
                    .HasMaxLength(30).HasColumnType("nvarchar");
            });

            modelBuilder.Entity<MauSac>(entity =>
            {
                entity.HasKey(e => e.MaMau)
                    .HasName("pk_mausac");

                entity.ToTable("MauSac");

                entity.Property(e => e.MaMau)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TenMau)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");
            });
            modelBuilder.Entity<ReviewStar>(entity =>
            {
                entity.ToTable("reviewStar");

             

                entity.Property(e => e.Id).HasColumnName("_id").ValueGeneratedOnAdd();

                entity.Property(e => e.Avr)
                    .HasColumnName("avr")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BaSao)
                    .HasColumnName("ba_sao")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BonSao)
                    .HasColumnName("bon_sao")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HaiSao)
                    .HasColumnName("hai_sao")
                    .HasDefaultValueSql("((0))");

              

                entity.Property(e => e.MotSao)
                    .HasColumnName("mot_sao")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NamSao)
                    .HasColumnName("nam_sao")
                    .HasDefaultValueSql("((0))");

           
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dsc).HasColumnType("ntext");

                entity.Property(e => e.NgayBatDat).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => new {e.MaSanPham})
                    .HasName("pk_sanpham");
                entity.Property(e => e.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(e => e.MaSanPham).HasColumnType("char(10)");
                entity.ToTable("SanPham");
                entity.Property(e => e.Mota).HasColumnType("ntext");
                entity.Property(e => e.Slug)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("slug")
                    .IsFixedLength(true);


                entity.Property(e => e.TenSanPham).HasColumnType("nvarchar(500)")
                    .IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("getdate()");
            
                entity.HasOne(x => x.TypeNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.IDType).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(x => x.BrandNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.IDBrand).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(x => x.VatNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.IDVat).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(x => x.SanPhamNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.ParentID);
                entity.HasOne(x => x.SizeNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.IDSize).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(x => x.HinhAnhNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.IDAnh);
                entity.HasOne(x => x.MauSacNavigation).WithMany(e => e.SanPhams).HasForeignKey(x => x.IDColor) ;
                entity.HasOne(x => x.StarReviewNavigation).WithOne(e => e.SanPhamNavigation).HasForeignKey<SanPham>(e=>e.ReviewID) ;
            });

   


            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenTaiKhoan);

                entity.ToTable("TaiKhoan");
                entity.Property(e => e.Avatar).HasColumnType("text");
                entity.Property(e => e.TenHienThi).HasColumnType("nvarchar(50)");
                entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);
                entity.Property(e => e.addressDefault).HasDefaultValueSql("-1");
                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);
                entity.Property(e => e.MatKhau)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);
                entity.Property(e => e.Role).HasDefaultValue(0);


                entity.Property(e => e.idKH)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
                    
                entity.HasOne(d => d.SdtKhNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.idKH)
                    .HasConstraintName("fk_TaiKhoan_KH").OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.RoleGroupNavigation)
                  .WithMany(p => p.TaiKhoans)
                  .HasForeignKey(d => d.RoleGroup)
                  .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Role>().HasData(RoleGenerate());
            modelBuilder.Entity<Size>().HasData(SizeGenerate());
            modelBuilder.Entity<RoleDetails>().HasData(RoleDetailGenerate());
            modelBuilder.Entity<LoaiPhieu>().HasData(GenerateLoaiPhieu());

            modelBuilder.Entity<RoleGroup>().HasData(
                new RoleGroup { GroupName="ADMIN"},
                new RoleGroup { GroupName="MANAGER"},
                new RoleGroup { GroupName="USER"}
                );
            modelBuilder.Entity<MauSac>().HasData(
                new MauSac { MaMau = "red" },
                new MauSac { MaMau = "black" },
                new MauSac { MaMau = "white" },
                new MauSac { MaMau = "blue" },
                new MauSac { MaMau = "green" },
                new MauSac { MaMau = "browb" },
                new MauSac { MaMau = "fuchsia" },
                new MauSac { MaMau = "aqua" },
                new MauSac { MaMau = "yellow" },
                new MauSac { MaMau = "maroon" },
                new MauSac { MaMau = "silver" },
                new MauSac { MaMau = "purple" },
                new MauSac { MaMau = "olive" },
                new MauSac { MaMau = "gray" },
                new MauSac { MaMau = "teal" }
                );
            modelBuilder.Entity<Branchs>().HasData(
                new Branchs { MaChiNhanh="CN01",TenChiNhanh="Chi nhánh Đồng tháp"}
                );

            modelBuilder.Entity<TaiKhoan>().HasData(
                new TaiKhoan { TenTaiKhoan="admin",MatKhau="admin",RoleGroup="ADMIN",Email="truongkiet.hn290@gmail.com"}
                );
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<API_DSCS2_WEBBANGIAY.Models.DanhMucDetails> DanhMucDetails { get; set; }


    }
}
