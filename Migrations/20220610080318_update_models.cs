using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class update_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh_SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    _id_HinhAnh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hinhanh_sanpham", x => new { x.MaSanPham, x._id_HinhAnh });
                    table.ForeignKey(
                        name: "fk_cthd_hinhanh",
                        column: x => x._id_HinhAnh,
                        principalTable: "HinhAnh",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cthd_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPham__id_HinhAnh",
                table: "HinhAnh_SanPham",
                column: "_id_HinhAnh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HinhAnh_SanPham");

            migrationBuilder.DropTable(
                name: "HinhAnh");
        }
    }
}
