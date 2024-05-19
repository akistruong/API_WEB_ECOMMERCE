using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblChiTietBST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sanpham_BST",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "_id_BST",
                table: "SanPham",
                newName: "IdBstNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham__id_BST",
                table: "SanPham",
                newName: "IX_SanPham_IdBstNavigationId");

            migrationBuilder.AddColumn<string>(
                name: "MotaChiTiet",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChiTietBSTs",
                columns: table => new
                {
                    IDBST = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietBSTs", x => new { x.IDBST, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_ChiTietBSTs_BoSuuTap_IDBST",
                        column: x => x.IDBST,
                        principalTable: "BoSuuTap",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietBSTs_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBSTs_MaSanPham",
                table: "ChiTietBSTs",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BoSuuTap_IdBstNavigationId",
                table: "SanPham",
                column: "IdBstNavigationId",
                principalTable: "BoSuuTap",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BoSuuTap_IdBstNavigationId",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "ChiTietBSTs");

            migrationBuilder.DropColumn(
                name: "MotaChiTiet",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "IdBstNavigationId",
                table: "SanPham",
                newName: "_id_BST");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_IdBstNavigationId",
                table: "SanPham",
                newName: "IX_SanPham__id_BST");

            migrationBuilder.AddForeignKey(
                name: "fk_sanpham_BST",
                table: "SanPham",
                column: "_id_BST",
                principalTable: "BoSuuTap",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
