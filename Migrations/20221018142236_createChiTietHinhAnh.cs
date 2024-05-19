using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class createChiTietHinhAnh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietHinhAnh",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    _id_HinhAnh = table.Column<int>(type: "int", nullable: false),
                    IdMaMau = table.Column<string>(type: "char(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_CTHA", x => new { x.MaSanPham, x._id_HinhAnh, x.IdMaMau });
                    table.ForeignKey(
                        name: "fk_ctha_hinhanh",
                        column: x => x._id_HinhAnh,
                        principalTable: "HinhAnh",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ctha_mausac",
                        column: x => x.IdMaMau,
                        principalTable: "MauSac",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ctha_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHinhAnh__id_HinhAnh",
                table: "ChiTietHinhAnh",
                column: "_id_HinhAnh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHinhAnh_IdMaMau",
                table: "ChiTietHinhAnh",
                column: "IdMaMau");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHinhAnh");
        }
    }
}
