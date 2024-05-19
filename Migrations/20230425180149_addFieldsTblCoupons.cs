using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldsTblCoupons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KieuGiaTri",
                table: "Coupons");

            migrationBuilder.AddColumn<int>(
                name: "DieuKien",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaTriDonHangToiThieu",
                table: "Coupons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NhomDoiTuong",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongSPToiThieu",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DieuKien",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "GiaTriDonHangToiThieu",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "NhomDoiTuong",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "SoLuongSPToiThieu",
                table: "Coupons");

            migrationBuilder.AddColumn<bool>(
                name: "KieuGiaTri",
                table: "Coupons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
