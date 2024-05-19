using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "maPhieuNhap",
                table: "SanPham",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_maPhieuNhap",
                table: "SanPham",
                column: "maPhieuNhap");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_PhieuNhaps_maPhieuNhap",
                table: "SanPham",
                column: "maPhieuNhap",
                principalTable: "PhieuNhaps",
                principalColumn: "maPhieuNhap",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_PhieuNhaps_maPhieuNhap",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_maPhieuNhap",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "maPhieuNhap",
                table: "SanPham");
        }
    }
}
