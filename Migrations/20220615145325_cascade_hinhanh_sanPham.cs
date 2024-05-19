using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class cascade_hinhanh_sanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cthd_hinhanh",
                table: "HinhAnh_SanPham");

            migrationBuilder.DropForeignKey(
                name: "fk_cthd_sanpham",
                table: "HinhAnh_SanPham");

            migrationBuilder.AddForeignKey(
                name: "fk_cthd_hinhanh",
                table: "HinhAnh_SanPham",
                column: "_id_HinhAnh",
                principalTable: "HinhAnh",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_cthd_sanpham",
                table: "HinhAnh_SanPham",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cthd_hinhanh",
                table: "HinhAnh_SanPham");

            migrationBuilder.DropForeignKey(
                name: "fk_cthd_sanpham",
                table: "HinhAnh_SanPham");

            migrationBuilder.AddForeignKey(
                name: "fk_cthd_hinhanh",
                table: "HinhAnh_SanPham",
                column: "_id_HinhAnh",
                principalTable: "HinhAnh",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_cthd_sanpham",
                table: "HinhAnh_SanPham",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
