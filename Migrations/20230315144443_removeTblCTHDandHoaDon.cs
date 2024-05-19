using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeTblCTHDandHoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_DiaChis_DiaChiNavigationID",
                table: "PhieuNhapXuats");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_DiaChiNavigationID",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "DiaChiNavigationID",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.AlterColumn<string>(
                name: "idTaiKhoan",
                table: "PhieuNhapXuats",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_IdDiaChi",
                table: "PhieuNhapXuats",
                column: "IdDiaChi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_idTaiKhoan",
                table: "PhieuNhapXuats",
                column: "idTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_DiaChis_IdDiaChi",
                table: "PhieuNhapXuats",
                column: "IdDiaChi",
                principalTable: "DiaChis",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_idTaiKhoan",
                table: "PhieuNhapXuats",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_DiaChis_IdDiaChi",
                table: "PhieuNhapXuats");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_idTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_IdDiaChi",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_idTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.AlterColumn<string>(
                name: "idTaiKhoan",
                table: "PhieuNhapXuats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiaChiNavigationID",
                table: "PhieuNhapXuats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats",
                type: "char(20)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    giamgia = table.Column<decimal>(type: "money", nullable: true),
                    IdDiaChi = table.Column<int>(type: "int", nullable: true),
                    phiship = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thanhtien = table.Column<decimal>(type: "money", nullable: false),
                    TienThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    idKH = table.Column<int>(type: "int", nullable: true),
                    idTaiKhoan = table.Column<string>(type: "char(20)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    totalQty = table.Column<int>(type: "int", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x._id);
                    table.ForeignKey(
                        name: "fk_HD_KH",
                        column: x => x.idKH,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_DiaChis_IdDiaChi",
                        column: x => x.IdDiaChi,
                        principalTable: "DiaChis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                        column: x => x.idTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    _id_HoaDon = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    Color = table.Column<string>(type: "char(20)", nullable: false),
                    IDSanPham = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeId = table.Column<string>(type: "char(10)", nullable: true),
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    giaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_CTHD", x => new { x._id_HoaDon, x.MaSanPham, x.Color });
                    table.ForeignKey(
                        name: "fk_ChiTietHoaDon_HD",
                        column: x => x._id_HoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ChiTietHoaDon_KH",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_MauSac_Color",
                        column: x => x.Color,
                        principalTable: "MauSac",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_DiaChiNavigationID",
                table: "PhieuNhapXuats",
                column: "DiaChiNavigationID");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats",
                column: "TenTaiKhoanNavigationTenTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_Color",
                table: "ChiTietHoaDon",
                column: "Color");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_SizeId",
                table: "ChiTietHoaDon",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_idKH",
                table: "HoaDon",
                column: "idKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_idTaiKhoan",
                table: "HoaDon",
                column: "idTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_DiaChis_DiaChiNavigationID",
                table: "PhieuNhapXuats",
                column: "DiaChiNavigationID",
                principalTable: "DiaChis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_TenTaiKhoanNavigationTenTaiKhoan",
                table: "PhieuNhapXuats",
                column: "TenTaiKhoanNavigationTenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
