using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFkTblCTHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_Color",
                table: "ChiTietHoaDon",
                column: "Color");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_Size",
                table: "ChiTietHoaDon",
                column: "Size");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_MauSac_Color",
                table: "ChiTietHoaDon",
                column: "Color",
                principalTable: "MauSac",
                principalColumn: "MaMau",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Sizes_Size",
                table: "ChiTietHoaDon",
                column: "Size",
                principalTable: "Sizes",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_MauSac_Color",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Sizes_Size",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_Color",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_Size",
                table: "ChiTietHoaDon");
        }
    }
}
