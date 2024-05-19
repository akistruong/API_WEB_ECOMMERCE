using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class modfFieldTblCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DieuKien",
                table: "Coupons",
                newName: "LoaiKhuyenMai");

            migrationBuilder.AddColumn<int>(
                name: "SoLanMuaHang",
                table: "TaiKhoan",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLanMuaHang",
                table: "TaiKhoan");

            migrationBuilder.RenameColumn(
                name: "LoaiKhuyenMai",
                table: "Coupons",
                newName: "DieuKien");
        }
    }
}
