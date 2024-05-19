using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintFKTblPhieuNhapXuats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_TaiKhoanTenTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_TaiKhoanTenTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "TaiKhoanTenTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.AlterColumn<string>(
                name: "idTaiKhoan",
                table: "PhieuNhapXuats",
                type: "char(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaNhanHang",
                table: "PhieuNhapXuats",
                type: "bit",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_idTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_idTaiKhoan",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "DaNhanHang",
                table: "PhieuNhapXuats");

            migrationBuilder.AlterColumn<string>(
                name: "idTaiKhoan",
                table: "PhieuNhapXuats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaiKhoanTenTaiKhoan",
                table: "PhieuNhapXuats",
                type: "char(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_TaiKhoanTenTaiKhoan",
                table: "PhieuNhapXuats",
                column: "TaiKhoanTenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_TaiKhoan_TaiKhoanTenTaiKhoan",
                table: "PhieuNhapXuats",
                column: "TaiKhoanTenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
