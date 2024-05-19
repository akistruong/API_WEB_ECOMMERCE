using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class dropCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Sdt = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    GiamGia = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    gioitinh = table.Column<bool>(type: "bit", nullable: true),
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TienThanhToan = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_KH", x => x.Sdt);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TenTaiKhoan = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatKhau = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    SdtKH = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_TK", x => x.TenTaiKhoan);
                    table.ForeignKey(
                        name: "fk_TaiKhoan_KH",
                        column: x => x.SdtKH,
                        principalTable: "KhachHang",
                        principalColumn: "Sdt",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    giamgia = table.Column<decimal>(type: "money", nullable: true),
                    phiship = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SdtKH = table.Column<string>(type: "char(10)", nullable: true),
                    TenTaiKhoan = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    thanhtien = table.Column<decimal>(type: "money", nullable: false),
                    TienNhan = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    TienThoiLai = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x._id);
                    table.ForeignKey(
                        name: "fk_HD_KH",
                        column: x => x.SdtKH,
                        principalTable: "KhachHang",
                        principalColumn: "Sdt",
                        onDelete: ReferentialAction.Restrict);
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
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    soluong = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_HoaDon_SdtKH",
                table: "HoaDon",
                column: "SdtKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_TenTaiKhoan",
                table: "HoaDon",
                column: "TenTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_SdtKH",
                table: "TaiKhoan",
                column: "SdtKH");
        }
    }
}
