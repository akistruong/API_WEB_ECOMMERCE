using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateKeyTblCTHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "ChiTietHoaDon",
                type: "char(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "MasanPham", "Size", "Color" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "ChiTietHoaDon",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "MasanPham" });
        }
    }
}
