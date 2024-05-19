using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addQTYCTLTBLSANPHAM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GiaVon",
                table: "SanPham",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongCoTheban",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongTon",
                table: "SanPham",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaVon",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SoLuongCoTheban",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SoLuongTon",
                table: "SanPham");
        }
    }
}
