using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addfieldCTHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "soluong",
                table: "ChiTietHoaDon",
                newName: "Qty");

            migrationBuilder.AddColumn<string>(
                name: "ColorSelected",
                table: "ChiTietHoaDon",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeSelected",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorSelected",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "SizeSelected",
                table: "ChiTietHoaDon");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "ChiTietHoaDon",
                newName: "soluong");
        }
    }
}
