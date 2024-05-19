using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintTblSoLuongDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.AddColumn<string>(
                name: "maPhieuNhap",
                table: "SoLuongDetails",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize", "maPhieuNhap" });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maPhieuNhap",
                table: "SoLuongDetails",
                column: "maPhieuNhap");

            migrationBuilder.AddForeignKey(
                name: "FK_SoLuongDetails_PhieuNhaps_maPhieuNhap",
                table: "SoLuongDetails",
                column: "maPhieuNhap",
                principalTable: "PhieuNhaps",
                principalColumn: "maPhieuNhap",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoLuongDetails_PhieuNhaps_maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_SoLuongDetails_maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize" });
        }
    }
}
