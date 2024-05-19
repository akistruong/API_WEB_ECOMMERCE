using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class createTblCTPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhaps",
                columns: table => new
                {
                    maSP = table.Column<string>(type: "char(10)", nullable: false),
                    maPN = table.Column<string>(type: "char(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongSoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoMatHang = table.Column<int>(type: "int", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChiTietPhieuNhapmaPN = table.Column<string>(type: "char(10)", nullable: true),
                    ChiTietPhieuNhapmaSP = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhaps", x => new { x.maSP, x.maPN });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_ChiTietPhieuNhaps_ChiTietPhieuNhapmaSP_ChiTietPhieuNhapmaPN",
                        columns: x => new { x.ChiTietPhieuNhapmaSP, x.ChiTietPhieuNhapmaPN },
                        principalTable: "ChiTietPhieuNhaps",
                        principalColumns: new[] { "maSP", "maPN" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_PhieuNhaps_maPN",
                        column: x => x.maPN,
                        principalTable: "PhieuNhaps",
                        principalColumn: "maPhieuNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_SanPham_maSP",
                        column: x => x.maSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_ChiTietPhieuNhapmaSP_ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "ChiTietPhieuNhapmaSP", "ChiTietPhieuNhapmaPN" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_maPN",
                table: "ChiTietPhieuNhaps",
                column: "maPN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhaps");
        }
    }
}
