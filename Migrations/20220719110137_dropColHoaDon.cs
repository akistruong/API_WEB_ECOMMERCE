using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class dropColHoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TienNhan",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TienThoiLai",
                table: "HoaDon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TienNhan",
                table: "HoaDon",
                type: "money",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<decimal>(
                name: "TienThoiLai",
                table: "HoaDon",
                type: "money",
                nullable: true,
                defaultValueSql: "((0))");
        }
    }
}
