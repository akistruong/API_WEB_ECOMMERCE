using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintFKTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_HD_TK",
                table: "HoaDon");

            migrationBuilder.AddColumn<string>(
                name: "idTaiKhoan",
                table: "HoaDon",
                type: "char(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_idTaiKhoan",
                table: "HoaDon",
                column: "idTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "fk_HD_TK",
                table: "HoaDon",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_HD_TK",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_idTaiKhoan",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "idTaiKhoan",
                table: "HoaDon");

            migrationBuilder.AddForeignKey(
                name: "fk_HD_TK",
                table: "HoaDon",
                column: "TenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
