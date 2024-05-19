using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldAvatarFieldTenHienThiTblTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "TaiKhoan",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenHienThi",
                table: "TaiKhoan",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "TenHienThi",
                table: "TaiKhoan");
        }
    }
}
