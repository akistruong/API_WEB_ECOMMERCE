using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addColTongSoLuongTblPhieuNhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoMatHang",
                table: "PhieuNhaps",
                newName: "TongSoLuong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TongSoLuong",
                table: "PhieuNhaps",
                newName: "SoMatHang");
        }
    }
}
