using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeConstraintSP_ReviewDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarReviewDetails_SanPham_MaSanPham",
                table: "StarReviewDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails");

            migrationBuilder.DropIndex(
                name: "IX_StarReviewDetails_StarReviewID",
                table: "StarReviewDetails");

            migrationBuilder.AlterColumn<string>(
                name: "MaSanPham",
                table: "StarReviewDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AddColumn<string>(
                name: "MasanPhamNavigationMaSanPham",
                table: "StarReviewDetails",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails",
                columns: new[] { "StarReviewID", "IDDonHang" });

            migrationBuilder.CreateIndex(
                name: "IX_StarReviewDetails_MasanPhamNavigationMaSanPham",
                table: "StarReviewDetails",
                column: "MasanPhamNavigationMaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_StarReviewDetails_SanPham_MasanPhamNavigationMaSanPham",
                table: "StarReviewDetails",
                column: "MasanPhamNavigationMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarReviewDetails_SanPham_MasanPhamNavigationMaSanPham",
                table: "StarReviewDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails");

            migrationBuilder.DropIndex(
                name: "IX_StarReviewDetails_MasanPhamNavigationMaSanPham",
                table: "StarReviewDetails");

            migrationBuilder.DropColumn(
                name: "MasanPhamNavigationMaSanPham",
                table: "StarReviewDetails");

            migrationBuilder.AlterColumn<string>(
                name: "MaSanPham",
                table: "StarReviewDetails",
                type: "char(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails",
                columns: new[] { "MaSanPham", "StarReviewID", "IDDonHang" });

            migrationBuilder.CreateIndex(
                name: "IX_StarReviewDetails_StarReviewID",
                table: "StarReviewDetails",
                column: "StarReviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_StarReviewDetails_SanPham_MaSanPham",
                table: "StarReviewDetails",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
