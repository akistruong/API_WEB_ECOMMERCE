using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeFKTaiKhoanTblPhieuNhapXuat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_idTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_idTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.AlterColumn<string>(
                name: "idTaiKhoan",
                table: "PhieuNhapXuats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "idTaiKhoan",
                table: "PhieuNhapXuats",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_idTaiKhoan",
                table: "PhieuNhapXuats",
                column: "idTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_idTaiKhoan",
                table: "PhieuNhapXuats",
                column: "idTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
