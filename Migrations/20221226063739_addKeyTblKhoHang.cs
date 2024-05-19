using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addKeyTblKhoHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs",
                columns: new[] { "MaChiNhanh", "MaSanPham", "IDLichSu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs",
                columns: new[] { "MaChiNhanh", "MaSanPham" });
        }
    }
}
