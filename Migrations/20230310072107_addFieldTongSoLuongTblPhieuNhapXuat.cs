using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldTongSoLuongTblPhieuNhapXuat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalQty",
                table: "PhieuNhapXuats",
                newName: "TongSoLuong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TongSoLuong",
                table: "PhieuNhapXuats",
                newName: "totalQty");
        }
    }
}
