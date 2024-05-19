using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFiledSoLuongDaBanFieldImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BoSuuTap_IdBstNavigationId",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IdBstNavigationId",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "IdBstNavigationId",
                table: "SanPham",
                newName: "SoLuongDaBan");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "ChiTietNhapXuats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "ChiTietNhapXuats");

            migrationBuilder.RenameColumn(
                name: "SoLuongDaBan",
                table: "SanPham",
                newName: "IdBstNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdBstNavigationId",
                table: "SanPham",
                column: "IdBstNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BoSuuTap_IdBstNavigationId",
                table: "SanPham",
                column: "IdBstNavigationId",
                principalTable: "BoSuuTap",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
