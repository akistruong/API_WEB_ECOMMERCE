using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class alterFieldCTHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeSelected",
                table: "ChiTietHoaDon",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "ColorSelected",
                table: "ChiTietHoaDon",
                newName: "Color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ChiTietHoaDon",
                newName: "SizeSelected");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "ChiTietHoaDon",
                newName: "ColorSelected");
        }
    }
}
