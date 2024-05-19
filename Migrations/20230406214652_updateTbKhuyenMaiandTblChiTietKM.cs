using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateTbKhuyenMaiandTblChiTietKM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongConlai",
                table: "KhuyenMais");

            migrationBuilder.DropColumn(
                name: "SoLuongGiamGia",
                table: "KhuyenMais");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaTri",
                table: "ChiTietKhuyenMais",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KieuGiaTri",
                table: "ChiTietKhuyenMais",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaTri",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropColumn(
                name: "KieuGiaTri",
                table: "ChiTietKhuyenMais");

            migrationBuilder.AddColumn<int>(
                name: "SoLuongConlai",
                table: "KhuyenMais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongGiamGia",
                table: "KhuyenMais",
                type: "int",
                nullable: true);
        }
    }
}
