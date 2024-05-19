using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFiledDaHoanTienDaTraHangTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DaHoanTien",
                table: "PhieuNhapXuats",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaTraHang",
                table: "PhieuNhapXuats",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaHoanTien",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "DaTraHang",
                table: "PhieuNhapXuats");
        }
    }
}
