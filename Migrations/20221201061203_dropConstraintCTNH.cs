using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class dropConstraintCTNH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_ChiTietPhieuNhaps_ChiTietPhieuNhapmaSP_ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_ChiTietPhieuNhapmaSP_ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "ChiTietPhieuNhapmaSP",
                table: "ChiTietPhieuNhaps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChiTietPhieuNhapmaSP",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_ChiTietPhieuNhapmaSP_ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "ChiTietPhieuNhapmaSP", "ChiTietPhieuNhapmaPN" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_ChiTietPhieuNhaps_ChiTietPhieuNhapmaSP_ChiTietPhieuNhapmaPN",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "ChiTietPhieuNhapmaSP", "ChiTietPhieuNhapmaPN" },
                principalTable: "ChiTietPhieuNhaps",
                principalColumns: new[] { "maSP", "maPN" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
