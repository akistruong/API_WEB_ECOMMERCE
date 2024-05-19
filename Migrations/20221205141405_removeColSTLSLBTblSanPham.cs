using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeColSTLSLBTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongBan",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SoLuongNhap",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SoLuongTon",
                table: "SanPham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongBan",
                table: "SanPham",
                type: "int",
                nullable: true,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "SoLuongNhap",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongTon",
                table: "SanPham",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");
        }
    }
}
