using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addColumnSdtTableKH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "nvarchar(30)",
                unicode: false,
                fixedLength: true,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(30)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sdt",
                table: "KhachHang",
                type: "char(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sdt",
                table: "KhachHang");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "char(30)",
                unicode: false,
                fixedLength: true,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
