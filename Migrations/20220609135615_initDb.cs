using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoSuuTap",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoSuuTap = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Mota = table.Column<string>(type: "ntext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    slug = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoSuuTap", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slug = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    Sdt = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    gioitinh = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mamau = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dsc = table.Column<string>(type: "ntext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NgayBatDat = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    img = table.Column<string>(type: "text", nullable: true),
                    slug = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    _id_DM = table.Column<int>(type: "int", nullable: true),
                    _id_BST = table.Column<int>(type: "int", nullable: true),
                    Mota = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sanpham", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "fk_sanpham_BST",
                        column: x => x._id_BST,
                        principalTable: "BoSuuTap",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sanpham_danhmuc",
                        column: x => x._id_DM,
                        principalTable: "DanhMuc",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TenTaiKhoan = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatKhau = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    _id_KH = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_TK", x => x.TenTaiKhoan);
                    table.ForeignKey(
                        name: "fk_TaiKhoan_KH",
                        column: x => x._id_KH,
                        principalTable: "KhachHang",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSale",
                columns: table => new
                {
                    _id_sale = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    giamgia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cts", x => new { x._id_sale, x.MaSanPham });
                    table.ForeignKey(
                        name: "fk_cts_Sale",
                        column: x => x._id_sale,
                        principalTable: "Sale",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cts_SP",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MauSac_Detail",
                columns: table => new
                {
                    _id_mausac = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_MauSac_Detail", x => new { x.MaSanPham, x._id_mausac });
                    table.ForeignKey(
                        name: "fk_detail_mausac_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_detail_mausac_sizes",
                        column: x => x._id_mausac,
                        principalTable: "MauSac",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviewStar",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    mot_sao = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    hai_sao = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    ba_sao = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    bon_sao = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    nam_sao = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    avr = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewStar", x => x._id);
                    table.ForeignKey(
                        name: "fk_reviewStar_sanpham",
                        column: x => x.MasanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size_Detail",
                columns: table => new
                {
                    _id_sizes = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_size_detail", x => new { x.MaSanPham, x._id_sizes });
                    table.ForeignKey(
                        name: "fk_detail_sanpham_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_detail_sanpham_sizes",
                        column: x => x._id_sizes,
                        principalTable: "Sizes",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    thanhtien = table.Column<decimal>(type: "money", nullable: false),
                    giamgia = table.Column<decimal>(type: "money", nullable: true),
                    phiship = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    _id_KH = table.Column<int>(type: "int", nullable: true),
                    TenTaiKhoan = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    TienNhan = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    TienThoiLai = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x._id);
                    table.ForeignKey(
                        name: "fk_HD_TK",
                        column: x => x.TenTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    _id_HoaDon = table.Column<int>(type: "int", nullable: false),
                    MasanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_CTHD", x => new { x._id_HoaDon, x.MasanPham });
                    table.ForeignKey(
                        name: "fk_ChiTietHoaDon_HD",
                        column: x => x._id_HoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ChiTietHoaDon_KH",
                        column: x => x.MasanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon",
                column: "MasanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSale_MaSanPham",
                table: "ChiTietSale",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_TenTaiKhoan",
                table: "HoaDon",
                column: "TenTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_MauSac_Detail__id_mausac",
                table: "MauSac_Detail",
                column: "_id_mausac");

            migrationBuilder.CreateIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar",
                column: "MasanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham__id_BST",
                table: "SanPham",
                column: "_id_BST");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham__id_DM",
                table: "SanPham",
                column: "_id_DM");

            migrationBuilder.CreateIndex(
                name: "IX_Size_Detail__id_sizes",
                table: "Size_Detail",
                column: "_id_sizes");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan__id_KH",
                table: "TaiKhoan",
                column: "_id_KH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "ChiTietSale");

            migrationBuilder.DropTable(
                name: "MauSac_Detail");

            migrationBuilder.DropTable(
                name: "reviewStar");

            migrationBuilder.DropTable(
                name: "Size_Detail");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "BoSuuTap");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
