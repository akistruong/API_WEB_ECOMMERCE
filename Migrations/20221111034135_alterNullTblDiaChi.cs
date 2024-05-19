using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class alterNullTblDiaChi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaChis_KhachHang_IDKH",
                table: "DiaChis");

            migrationBuilder.AlterColumn<int>(
                name: "IDKH",
                table: "DiaChis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_KhachHang_IDKH",
                table: "DiaChis",
                column: "IDKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaChis_KhachHang_IDKH",
                table: "DiaChis");

            migrationBuilder.AlterColumn<int>(
                name: "IDKH",
                table: "DiaChis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_KhachHang_IDKH",
                table: "DiaChis",
                column: "IDKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
