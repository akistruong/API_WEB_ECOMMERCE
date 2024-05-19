using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeFieldTblCTPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongSoLuong",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.RenameColumn(
                name: "SoMatHang",
                table: "ChiTietPhieuNhaps",
                newName: "SoLuong");

            migrationBuilder.AddColumn<int>(
                name: "SoMatHang",
                table: "PhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TongSoLuong",
                table: "PhieuNhaps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VAT",
                table: "PhieuNhaps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoMatHang",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "TongSoLuong",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "PhieuNhaps");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "ChiTietPhieuNhaps",
                newName: "SoMatHang");

            migrationBuilder.AddColumn<decimal>(
                name: "TongSoLuong",
                table: "ChiTietPhieuNhaps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VAT",
                table: "ChiTietPhieuNhaps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
