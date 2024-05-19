using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class alterTablePhieuNhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maPhieuNhap",
                table: "PhieuNhaps");

            migrationBuilder.RenameColumn(
                name: "VAT",
                table: "PhieuNhaps",
                newName: "ThanhTien");

            migrationBuilder.RenameColumn(
                name: "TongSoLuong",
                table: "PhieuNhaps",
                newName: "ChietKhau");

            migrationBuilder.RenameColumn(
                name: "DaThanhToan",
                table: "PhieuNhaps",
                newName: "ThanhToan");

            migrationBuilder.AddColumn<bool>(
                name: "DaNhapHang",
                table: "PhieuNhaps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "steps",
                table: "PhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaNhapHang",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "steps",
                table: "PhieuNhaps");

            migrationBuilder.RenameColumn(
                name: "ThanhToan",
                table: "PhieuNhaps",
                newName: "DaThanhToan");

            migrationBuilder.RenameColumn(
                name: "ThanhTien",
                table: "PhieuNhaps",
                newName: "VAT");

            migrationBuilder.RenameColumn(
                name: "ChietKhau",
                table: "PhieuNhaps",
                newName: "TongSoLuong");

            migrationBuilder.AddColumn<string>(
                name: "maPhieuNhap",
                table: "PhieuNhaps",
                type: "char(10)",
                nullable: true);
        }
    }
}
