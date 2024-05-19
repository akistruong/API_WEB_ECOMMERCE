using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class HinhAnhSanPham_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_hinhanh_sanpham",
                table: "HinhAnh_SanPham");

            migrationBuilder.AddColumn<string>(
                name: "IdMaMau",
                table: "HinhAnh_SanPham",
                type: "char(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MauSacNavigationMaMau",
                table: "HinhAnh_SanPham",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_hinhanh_sanpham",
                table: "HinhAnh_SanPham",
                columns: new[] { "MaSanPham", "_id_HinhAnh", "IdMaMau" });

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPham_MauSacNavigationMaMau",
                table: "HinhAnh_SanPham",
                column: "MauSacNavigationMaMau");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnh_SanPham_MauSac_MauSacNavigationMaMau",
                table: "HinhAnh_SanPham",
                column: "MauSacNavigationMaMau",
                principalTable: "MauSac",
                principalColumn: "MaMau",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnh_SanPham_MauSac_MauSacNavigationMaMau",
                table: "HinhAnh_SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "pk_hinhanh_sanpham",
                table: "HinhAnh_SanPham");

            migrationBuilder.DropIndex(
                name: "IX_HinhAnh_SanPham_MauSacNavigationMaMau",
                table: "HinhAnh_SanPham");

            migrationBuilder.DropColumn(
                name: "IdMaMau",
                table: "HinhAnh_SanPham");

            migrationBuilder.DropColumn(
                name: "MauSacNavigationMaMau",
                table: "HinhAnh_SanPham");

            migrationBuilder.AddPrimaryKey(
                name: "pk_hinhanh_sanpham",
                table: "HinhAnh_SanPham",
                columns: new[] { "MaSanPham", "_id_HinhAnh" });
        }
    }
}
