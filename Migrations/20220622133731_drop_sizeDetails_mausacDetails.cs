using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class drop_sizeDetails_mausacDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MauSac_Detail");

            migrationBuilder.DropTable(
                name: "Size_Detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MauSac_Detail",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    MaMauSac = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_MauSac_Detail", x => new { x.MaSanPham, x.MaMauSac });
                    table.ForeignKey(
                        name: "fk_detail_mausac_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_detail_mausac_sizes",
                        column: x => x.MaMauSac,
                        principalTable: "MauSac",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size_Detail",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    _id_sizes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_size_detail", x => new { x.MaSanPham, x._id_sizes });
                    table.ForeignKey(
                        name: "fk_detail_sanpham_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_detail_sanpham_sizes",
                        column: x => x._id_sizes,
                        principalTable: "Sizes",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MauSac_Detail_MaMauSac",
                table: "MauSac_Detail",
                column: "MaMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_Size_Detail__id_sizes",
                table: "Size_Detail",
                column: "_id_sizes");
        }
    }
}
