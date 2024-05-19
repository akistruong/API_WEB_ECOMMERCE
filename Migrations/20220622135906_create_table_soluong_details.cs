using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class create_table_soluong_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoLuongDetails",
                columns: table => new
                {
                    maMau = table.Column<string>(type: "char(20)", nullable: false),
                    maSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    _idSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoLuongDetails", x => new { x.maMau, x.maSanPham, x._idSize });
                    table.ForeignKey(
                        name: "FK_SoLuongDetails_MauSac_maMau",
                        column: x => x.maMau,
                        principalTable: "MauSac",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoLuongDetails_SanPham_maSanPham",
                        column: x => x.maSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoLuongDetails_Sizes__idSize",
                        column: x => x._idSize,
                        principalTable: "Sizes",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails__idSize",
                table: "SoLuongDetails",
                column: "_idSize");

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maSanPham",
                table: "SoLuongDetails",
                column: "maSanPham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoLuongDetails");
        }
    }
}
