using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintsTblKhoHangs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhoHangs_LichSuNhapHangs_LichSuNhapXuatHangNavigationID",
                table: "KhoHangs");

            migrationBuilder.DropIndex(
                name: "IX_KhoHangs_LichSuNhapXuatHangNavigationID",
                table: "KhoHangs");

            migrationBuilder.DropColumn(
                name: "LichSuNhapXuatHangNavigationID",
                table: "KhoHangs");

            migrationBuilder.CreateIndex(
                name: "IX_KhoHangs_IDLichSu",
                table: "KhoHangs",
                column: "IDLichSu");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoHangs_LichSuNhapHangs_IDLichSu",
                table: "KhoHangs",
                column: "IDLichSu",
                principalTable: "LichSuNhapHangs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhoHangs_LichSuNhapHangs_IDLichSu",
                table: "KhoHangs");

            migrationBuilder.DropIndex(
                name: "IX_KhoHangs_IDLichSu",
                table: "KhoHangs");

            migrationBuilder.AddColumn<int>(
                name: "LichSuNhapXuatHangNavigationID",
                table: "KhoHangs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhoHangs_LichSuNhapXuatHangNavigationID",
                table: "KhoHangs",
                column: "LichSuNhapXuatHangNavigationID");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoHangs_LichSuNhapHangs_LichSuNhapXuatHangNavigationID",
                table: "KhoHangs",
                column: "LichSuNhapXuatHangNavigationID",
                principalTable: "LichSuNhapHangs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
