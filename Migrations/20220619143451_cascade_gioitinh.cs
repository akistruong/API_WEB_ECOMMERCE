using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class cascade_gioitinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc");

            migrationBuilder.AddForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc",
                column: "GioiTinh_Code",
                principalTable: "GioiTinh",
                principalColumn: "gioitinh_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc");

            migrationBuilder.AddForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc",
                column: "GioiTinh_Code",
                principalTable: "GioiTinh",
                principalColumn: "gioitinh_code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
