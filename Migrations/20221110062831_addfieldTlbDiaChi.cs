using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addfieldTlbDiaChi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sdt",
                table: "KhachHang");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DiaChis",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "DiaChis",
                type: "char(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "DiaChis");

            migrationBuilder.AddColumn<string>(
                name: "Sdt",
                table: "KhachHang",
                type: "char(10)",
                nullable: true);
        }
    }
}
