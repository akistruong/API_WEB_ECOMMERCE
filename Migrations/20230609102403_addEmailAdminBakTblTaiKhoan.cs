using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addEmailAdminBakTblTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "admin",
                column: "Email",
                value: "truongkiet.hn290@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "admin",
                column: "Email",
                value: null);
        }
    }
}
