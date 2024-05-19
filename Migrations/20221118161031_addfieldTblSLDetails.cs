using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addfieldTblSLDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoluongBan",
                table: "SoLuongDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoluongTon",
                table: "SoLuongDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoluongBan",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "SoluongTon",
                table: "SoLuongDetails");
        }
    }
}
