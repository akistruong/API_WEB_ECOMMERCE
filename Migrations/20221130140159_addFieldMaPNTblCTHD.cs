using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldMaPNTblCTHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaPhieuNhap",
                table: "ChiTietHoaDon",
                type: "char(10)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_PhieuNhaps_MaPhieuNhap",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_MaPhieuNhap",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "MaPhieuNhap",
                table: "ChiTietHoaDon");
        }
    }
}
