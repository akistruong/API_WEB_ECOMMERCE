using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeMaPNConstraintTBLSoluongDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_PhieuNhaps_MaPhieuNhap",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_SoLuongDetails_PhieuNhaps_maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_SoLuongDetails_maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_MaPhieuNhap",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "MaPhieuNhap",
                table: "ChiTietHoaDon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.AddColumn<string>(
                name: "maPhieuNhap",
                table: "SoLuongDetails",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaPhieuNhap",
                table: "ChiTietHoaDon",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize", "maPhieuNhap" });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maPhieuNhap",
                table: "SoLuongDetails",
                column: "maPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaPhieuNhap",
                table: "ChiTietHoaDon",
                column: "MaPhieuNhap");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_PhieuNhaps_MaPhieuNhap",
                table: "ChiTietHoaDon",
                column: "MaPhieuNhap",
                principalTable: "PhieuNhaps",
                principalColumn: "maPhieuNhap",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoLuongDetails_PhieuNhaps_maPhieuNhap",
                table: "SoLuongDetails",
                column: "maPhieuNhap",
                principalTable: "PhieuNhaps",
                principalColumn: "maPhieuNhap",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
