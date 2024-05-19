using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeColTenTaiKhoanTableTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_HD_TK",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_TenTaiKhoan",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TenTaiKhoan",
                table: "HoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                table: "HoaDon",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                table: "HoaDon");

            migrationBuilder.AddColumn<string>(
                name: "TenTaiKhoan",
                table: "HoaDon",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_TenTaiKhoan",
                table: "HoaDon",
                column: "TenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "fk_HD_TK",
                table: "HoaDon",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
