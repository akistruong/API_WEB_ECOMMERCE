using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class init_db_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan__id_KH",
                table: "TaiKhoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "_id_KH",
                table: "TaiKhoan");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "TaiKhoan",
                newName: "SdtKH");

            migrationBuilder.AlterColumn<string>(
                name: "Sdt",
                table: "KhachHang",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_KH",
                table: "KhachHang",
                column: "Sdt");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_SdtKH",
                table: "TaiKhoan",
                column: "SdtKH");

            migrationBuilder.AddForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan",
                column: "SdtKH",
                principalTable: "KhachHang",
                principalColumn: "Sdt",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan_SdtKH",
                table: "TaiKhoan");

            migrationBuilder.DropPrimaryKey(
                name: "pk_KH",
                table: "KhachHang");

            migrationBuilder.RenameColumn(
                name: "SdtKH",
                table: "TaiKhoan",
                newName: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "_id_KH",
                table: "TaiKhoan",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sdt",
                table: "KhachHang",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang",
                column: "_id");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan__id_KH",
                table: "TaiKhoan",
                column: "_id_KH");

            migrationBuilder.AddForeignKey(
                name: "fk_TaiKhoan_KH",
                table: "TaiKhoan",
                column: "_id_KH",
                principalTable: "KhachHang",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
