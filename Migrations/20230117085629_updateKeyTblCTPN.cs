using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateKeyTblCTPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AddColumn<decimal>(
                name: "DaThanhToan",
                table: "PhieuNhaps",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "ChiTietPhieuNhaps",
                type: "char(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "MaSanPham", "IDPN", "MaChiNhanh" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_MaChiNhanh",
                table: "ChiTietPhieuNhaps",
                column: "MaChiNhanh");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_Branchs_MaChiNhanh",
                table: "ChiTietPhieuNhaps",
                column: "MaChiNhanh",
                principalTable: "Branchs",
                principalColumn: "MaChiNhanh",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_Branchs_MaChiNhanh",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_MaChiNhanh",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "DaThanhToan",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "MaSanPham", "IDPN" });
        }
    }
}
