using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class caseCadeTblTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan",
                column: "idKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan",
                column: "idKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
