using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietNhapXuats_Branchs_MaChiNhanh",
                table: "ChiTietNhapXuats");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietNhapXuats",
                table: "ChiTietNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietNhapXuats_MaChiNhanh",
                table: "ChiTietNhapXuats");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "ChiTietNhapXuats");

            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "PhieuNhapXuats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CouponNavigationMaCoupon",
                table: "PhieuNhapXuats",
                type: "char(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "PhieuNhapXuats",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietNhapXuats",
                table: "ChiTietNhapXuats",
                columns: new[] { "MaSanPham", "IDPN" });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    MaCoupon = table.Column<string>(type: "char(15)", nullable: false),
                    TenCoupon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLanDung = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.MaCoupon);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCoupons",
                columns: table => new
                {
                    MaCoupon = table.Column<string>(type: "char(15)", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCoupons", x => new { x.MaSanPham, x.MaCoupon });
                    table.ForeignKey(
                        name: "FK_ChiTietCoupons_Coupons_MaCoupon",
                        column: x => x.MaCoupon,
                        principalTable: "Coupons",
                        principalColumn: "MaCoupon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietCoupons_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_CouponNavigationMaCoupon",
                table: "PhieuNhapXuats",
                column: "CouponNavigationMaCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_MaChiNhanh",
                table: "PhieuNhapXuats",
                column: "MaChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCoupons_MaCoupon",
                table: "ChiTietCoupons",
                column: "MaCoupon");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_Branchs_MaChiNhanh",
                table: "PhieuNhapXuats",
                column: "MaChiNhanh",
                principalTable: "Branchs",
                principalColumn: "MaChiNhanh");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_Coupons_CouponNavigationMaCoupon",
                table: "PhieuNhapXuats",
                column: "CouponNavigationMaCoupon",
                principalTable: "Coupons",
                principalColumn: "MaCoupon",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_Branchs_MaChiNhanh",
                table: "PhieuNhapXuats");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_Coupons_CouponNavigationMaCoupon",
                table: "PhieuNhapXuats");

            migrationBuilder.DropTable(
                name: "ChiTietCoupons");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_CouponNavigationMaCoupon",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_MaChiNhanh",
                table: "PhieuNhapXuats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietNhapXuats",
                table: "ChiTietNhapXuats");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "CouponNavigationMaCoupon",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "PhieuNhapXuats");

            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "ChiTietNhapXuats",
                type: "char(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietNhapXuats",
                table: "ChiTietNhapXuats",
                columns: new[] { "MaSanPham", "IDPN", "MaChiNhanh" });

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DaNhapHang = table.Column<bool>(type: "bit", nullable: false),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    Dvt = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IDNCC = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienDaThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TongSoLuong = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    steps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhaps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NhaCungCap_IDNCC",
                        column: x => x.IDNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhaps",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    IDPN = table.Column<int>(type: "int", nullable: false),
                    MaChiNhanh = table.Column<string>(type: "char(20)", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    logText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhaps", x => new { x.MaSanPham, x.IDPN, x.MaChiNhanh });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_Branchs_MaChiNhanh",
                        column: x => x.MaChiNhanh,
                        principalTable: "Branchs",
                        principalColumn: "MaChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_PhieuNhaps_IDPN",
                        column: x => x.IDPN,
                        principalTable: "PhieuNhaps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapXuats_MaChiNhanh",
                table: "ChiTietNhapXuats",
                column: "MaChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps",
                column: "IDPN");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_MaChiNhanh",
                table: "ChiTietPhieuNhaps",
                column: "MaChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_IDNCC",
                table: "PhieuNhaps",
                column: "IDNCC");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietNhapXuats_Branchs_MaChiNhanh",
                table: "ChiTietNhapXuats",
                column: "MaChiNhanh",
                principalTable: "Branchs",
                principalColumn: "MaChiNhanh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
