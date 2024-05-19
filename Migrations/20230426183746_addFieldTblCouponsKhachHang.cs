using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldTblCouponsKhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiSanPham",
                table: "Coupons_KhachHangs");

            migrationBuilder.AddColumn<decimal>(
                name: "SoLanDaMua",
                table: "Coupons_KhachHangs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TongTienThanhToan",
                table: "Coupons_KhachHangs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiSanPham",
                table: "ChiTietCoupons",
                type: "char(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLanDaMua",
                table: "Coupons_KhachHangs");

            migrationBuilder.DropColumn(
                name: "TongTienThanhToan",
                table: "Coupons_KhachHangs");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Coupons");

            migrationBuilder.AddColumn<string>(
                name: "LoaiSanPham",
                table: "Coupons_KhachHangs",
                type: "char(5)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiSanPham",
                table: "ChiTietCoupons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldNullable: true);
        }
    }
}
