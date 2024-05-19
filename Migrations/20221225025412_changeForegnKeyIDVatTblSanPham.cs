using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class changeForegnKeyIDVatTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Vats_IDBrand",
                table: "SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDVat",
                table: "SanPham",
                column: "IDVat");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Vats_IDVat",
                table: "SanPham",
                column: "IDVat",
                principalTable: "Vats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Vats_IDVat",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IDVat",
                table: "SanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Vats_IDBrand",
                table: "SanPham",
                column: "IDBrand",
                principalTable: "Vats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
