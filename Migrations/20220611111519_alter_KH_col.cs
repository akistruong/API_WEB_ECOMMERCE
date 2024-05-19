using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class alter_KH_col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiamGia",
                table: "KhachHang",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<decimal>(
                name: "TienThanhToan",
                table: "KhachHang",
                type: "money",
                nullable: true,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "TienThanhToan",
                table: "KhachHang");
        }
    }
}
