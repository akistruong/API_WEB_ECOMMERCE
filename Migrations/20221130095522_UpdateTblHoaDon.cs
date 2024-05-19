using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class UpdateTblHoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                table: "HoaDon",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi",
                unique: true,
                filter: "[IdDiaChi] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_TaiKhoan_idTaiKhoan",
                table: "HoaDon",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
