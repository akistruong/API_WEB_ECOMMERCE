using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblPhieuNhapXuatandTblChiTietNhapXuat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuNhapXuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNCC = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaNhapHang = table.Column<bool>(type: "bit", nullable: false),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    TienDaThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienDaGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChietKhau = table.Column<int>(type: "int", nullable: true),
                    Phiship = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    idTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idKH = table.Column<int>(type: "int", nullable: true),
                    IdDiaChi = table.Column<int>(type: "int", nullable: true),
                    totalQty = table.Column<int>(type: "int", nullable: true),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    steps = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenTaiKhoanNavigationTenTaiKhoan = table.Column<string>(type: "char(20)", nullable: true),
                    DiaChiNavigationID = table.Column<int>(type: "int", nullable: true),
                    KhachHangNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapXuats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuNhapXuats_DiaChis_DiaChiNavigationID",
                        column: x => x.DiaChiNavigationID,
                        principalTable: "DiaChis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuNhapXuats_KhachHang_KhachHangNavigationId",
                        column: x => x.KhachHangNavigationId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuNhapXuats_NhaCungCap_IDNCC",
                        column: x => x.IDNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuNhapXuats_TaiKhoan_TenTaiKhoanNavigationTenTaiKhoan",
                        column: x => x.TenTaiKhoanNavigationTenTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhapXuats",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    IDPN = table.Column<int>(type: "int", nullable: false),
                    MaChiNhanh = table.Column<string>(type: "char(20)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DVT = table.Column<string>(type: "char(10)", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhapXuats", x => new { x.MaSanPham, x.IDPN, x.MaChiNhanh });
                    table.ForeignKey(
                        name: "FK_ChiTietNhapXuats_Branchs_MaChiNhanh",
                        column: x => x.MaChiNhanh,
                        principalTable: "Branchs",
                        principalColumn: "MaChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapXuats_PhieuNhapXuats_IDPN",
                        column: x => x.IDPN,
                        principalTable: "PhieuNhapXuats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapXuats_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapXuats_IDPN",
                table: "ChiTietNhapXuats",
                column: "IDPN");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapXuats_MaChiNhanh",
                table: "ChiTietNhapXuats",
                column: "MaChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_DiaChiNavigationID",
                table: "PhieuNhapXuats",
                column: "DiaChiNavigationID");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_IDNCC",
                table: "PhieuNhapXuats",
                column: "IDNCC");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_KhachHangNavigationId",
                table: "PhieuNhapXuats",
                column: "KhachHangNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats",
                column: "TenTaiKhoanNavigationTenTaiKhoan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietNhapXuats");

            migrationBuilder.DropTable(
                name: "PhieuNhapXuats");
        }
    }
}
