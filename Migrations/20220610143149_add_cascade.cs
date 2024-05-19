using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class add_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cts_Sale",
                table: "ChiTietSale");

            migrationBuilder.DropForeignKey(
                name: "fk_cts_SP",
                table: "ChiTietSale");

            migrationBuilder.AddForeignKey(
                name: "fk_cts_Sale",
                table: "ChiTietSale",
                column: "_id_sale",
                principalTable: "Sale",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_cts_SP",
                table: "ChiTietSale",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cts_Sale",
                table: "ChiTietSale");

            migrationBuilder.DropForeignKey(
                name: "fk_cts_SP",
                table: "ChiTietSale");

            migrationBuilder.AddForeignKey(
                name: "fk_cts_Sale",
                table: "ChiTietSale",
                column: "_id_sale",
                principalTable: "Sale",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_cts_SP",
                table: "ChiTietSale",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
