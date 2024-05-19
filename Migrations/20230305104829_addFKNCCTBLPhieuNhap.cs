using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFKNCCTBLPhieuNhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_NhaCungCapNavigationID",
                table: "PhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhaps_NhaCungCapNavigationID",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "NhaCungCapNavigationID",
                table: "PhieuNhaps");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_IDNCC",
                table: "PhieuNhaps",
                column: "IDNCC");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_IDNCC",
                table: "PhieuNhaps",
                column: "IDNCC",
                principalTable: "NhaCungCap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_IDNCC",
                table: "PhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhaps_IDNCC",
                table: "PhieuNhaps");

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapNavigationID",
                table: "PhieuNhaps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NhaCungCapNavigationID",
                table: "PhieuNhaps",
                column: "NhaCungCapNavigationID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_NhaCungCapNavigationID",
                table: "PhieuNhaps",
                column: "NhaCungCapNavigationID",
                principalTable: "NhaCungCap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
