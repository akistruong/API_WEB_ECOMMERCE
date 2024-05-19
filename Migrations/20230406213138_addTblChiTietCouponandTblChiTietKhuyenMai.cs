using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblChiTietCouponandTblChiTietKhuyenMai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KieuGiaTri",
                table: "Coupons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    MaDotKhuyenMai = table.Column<string>(type: "char(10)", nullable: false),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GiaTriGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KieuGiaTri = table.Column<int>(type: "int", nullable: true),
                    SoLuongGiamGia = table.Column<int>(type: "int", nullable: true),
                    SoLuongConlai = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.MaDotKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhuyenMais",
                columns: table => new
                {
                    maSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    maDotKhuyenMai = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKhuyenMais", x => new { x.maSanPham, x.maDotKhuyenMai });
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMais_KhuyenMais_maDotKhuyenMai",
                        column: x => x.maDotKhuyenMai,
                        principalTable: "KhuyenMais",
                        principalColumn: "MaDotKhuyenMai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMais_SanPham_maSanPham",
                        column: x => x.maSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMais_maDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                column: "maDotKhuyenMai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietKhuyenMais");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropColumn(
                name: "KieuGiaTri",
                table: "Coupons");
        }
    }
}
