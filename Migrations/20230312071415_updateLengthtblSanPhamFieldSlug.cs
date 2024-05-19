using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateLengthtblSanPhamFieldSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "SanPham",
                type: "char(500)",
                unicode: false,
                fixedLength: true,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(50)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "SanPham",
                type: "char(50)",
                unicode: false,
                fixedLength: true,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(500)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
