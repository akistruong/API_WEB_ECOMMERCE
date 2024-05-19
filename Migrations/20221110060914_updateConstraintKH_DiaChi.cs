using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateConstraintKH_DiaChi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_DiaChis_IdDiaChi",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_IdDiaChi",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "IdDiaChi",
                table: "KhachHang");

            migrationBuilder.AddColumn<int>(
                name: "IDKH",
                table: "DiaChis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DiaChis_IDKH",
                table: "DiaChis",
                column: "IDKH");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_KhachHang_IDKH",
                table: "DiaChis",
                column: "IDKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaChis_KhachHang_IDKH",
                table: "DiaChis");

            migrationBuilder.DropIndex(
                name: "IX_DiaChis_IDKH",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "IDKH",
                table: "DiaChis");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDiaChi",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_IdDiaChi",
                table: "KhachHang",
                column: "IdDiaChi");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_DiaChis_IdDiaChi",
                table: "KhachHang",
                column: "IdDiaChi",
                principalTable: "DiaChis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
