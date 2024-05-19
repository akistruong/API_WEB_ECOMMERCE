using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldViewCountTblSPTblDanhMuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc");

            migrationBuilder.RenameColumn(
                name: "GioiTinhCode",
                table: "DanhMuc",
                newName: "ViewCount");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "SanPham",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "ViewCount",
                table: "DanhMuc",
                newName: "GioiTinhCode");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc",
                column: "GioiTinhCode");
        }
    }
}
