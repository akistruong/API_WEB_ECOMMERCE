using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldMaSanPhamXMaSanPhamYTblChiTietCoupons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCoupons_SanPham_MaSanPham",
                table: "ChiTietCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietCoupons",
                table: "ChiTietCoupons");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Coupons");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "ChiTietCoupons",
                newName: "MaSanPhamY");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPhamX",
                table: "ChiTietCoupons",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "ChiTietCoupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietCoupons",
                table: "ChiTietCoupons",
                columns: new[] { "MaSanPhamX", "MaSanPhamY", "MaCoupon" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCoupons_MaSanPhamY",
                table: "ChiTietCoupons",
                column: "MaSanPhamY");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCoupons_SanPham_MaSanPhamX",
                table: "ChiTietCoupons",
                column: "MaSanPhamX",
                principalTable: "SanPham",
                principalColumn: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCoupons_SanPham_MaSanPhamY",
                table: "ChiTietCoupons",
                column: "MaSanPhamY",
                principalTable: "SanPham",
                principalColumn: "MaSanPham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCoupons_SanPham_MaSanPhamX",
                table: "ChiTietCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCoupons_SanPham_MaSanPhamY",
                table: "ChiTietCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietCoupons",
                table: "ChiTietCoupons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCoupons_MaSanPhamY",
                table: "ChiTietCoupons");

            migrationBuilder.DropColumn(
                name: "MaSanPhamX",
                table: "ChiTietCoupons");

            migrationBuilder.DropColumn(
                name: "img",
                table: "ChiTietCoupons");

            migrationBuilder.RenameColumn(
                name: "MaSanPhamY",
                table: "ChiTietCoupons",
                newName: "MaSanPham");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietCoupons",
                table: "ChiTietCoupons",
                columns: new[] { "MaSanPham", "MaCoupon" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCoupons_SanPham_MaSanPham",
                table: "ChiTietCoupons",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
