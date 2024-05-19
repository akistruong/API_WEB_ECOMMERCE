using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class tableTaiKhoanchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan");

            migrationBuilder.RenameColumn(
                name: "SdtKH",
                table: "TaiKhoan",
                newName: "idKH");

            migrationBuilder.RenameIndex(
                name: "IX_TaiKhoan_SdtKH",
                table: "TaiKhoan",
                newName: "IX_TaiKhoan_idKH");

            migrationBuilder.AlterColumn<int>(
                name: "idKH",
                table: "TaiKhoan",
                type: "int",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan",
                column: "idKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan");

            migrationBuilder.RenameColumn(
                name: "idKH",
                table: "TaiKhoan",
                newName: "SdtKH");

            migrationBuilder.RenameIndex(
                name: "IX_TaiKhoan_idKH",
                table: "TaiKhoan",
                newName: "IX_TaiKhoan_SdtKH");

            migrationBuilder.AlterColumn<int>(
                name: "SdtKH",
                table: "TaiKhoan",
                type: "int",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan",
                column: "SdtKH",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
