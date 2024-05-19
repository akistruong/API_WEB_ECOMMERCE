using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class creatTblDiaChi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HinhAnh_SanPham");

            migrationBuilder.AddColumn<int>(
                name: "IdDiaChi",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiaChis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDsc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviceID = table.Column<int>(type: "int", nullable: false),
                    DistrictID = table.Column<int>(type: "int", nullable: false),
                    WardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChis", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_IdDiaChi",
                table: "KhachHang",
                column: "IdDiaChi");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPham__id_HinhAnh",
                table: "ChiTietHinhAnh",
                column: "_id_HinhAnh");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_DiaChis_IdDiaChi",
                table: "KhachHang",
                column: "IdDiaChi",
                principalTable: "DiaChis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_DiaChis_IdDiaChi",
                table: "KhachHang");

            migrationBuilder.DropTable(
                name: "DiaChis");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_IdDiaChi",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_HinhAnh_SanPham__id_HinhAnh",
                table: "ChiTietHinhAnh");

            migrationBuilder.DropColumn(
                name: "IdDiaChi",
                table: "KhachHang");

            migrationBuilder.CreateTable(
                name: "HinhAnh_SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    _id_HinhAnh = table.Column<int>(type: "int", nullable: false),
                    IdMaMau = table.Column<string>(type: "char(20)", maxLength: 20, nullable: false),
                    MauSacNavigationMaMau = table.Column<string>(type: "char(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hinhanh_sanpham", x => new { x.MaSanPham, x._id_HinhAnh, x.IdMaMau });
                    table.ForeignKey(
                        name: "fk_cthd_hinhanh",
                        column: x => x._id_HinhAnh,
                        principalTable: "HinhAnh",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cthd_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HinhAnh_SanPham_MauSac_MauSacNavigationMaMau",
                        column: x => x.MauSacNavigationMaMau,
                        principalTable: "MauSac",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPham__id_HinhAnh",
                table: "HinhAnh_SanPham",
                column: "_id_HinhAnh");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPham_MauSacNavigationMaMau",
                table: "HinhAnh_SanPham",
                column: "MauSacNavigationMaMau");
        }
    }
}
