using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFkTblCTReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenNguoiBinhLuan",
                table: "StarReviewDetails");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "StarReviewDetails",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "IDDonHang",
                table: "StarReviewDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewID",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StarReviewDetails_IDDonHang",
                table: "StarReviewDetails",
                column: "IDDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ReviewID",
                table: "SanPham",
                column: "ReviewID",
                unique: true,
                filter: "[ReviewID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_reviewStar_ReviewID",
                table: "SanPham",
                column: "ReviewID",
                principalTable: "reviewStar",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StarReviewDetails_PhieuNhapXuats_IDDonHang",
                table: "StarReviewDetails",
                column: "IDDonHang",
                principalTable: "PhieuNhapXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_reviewStar_ReviewID",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_StarReviewDetails_PhieuNhapXuats_IDDonHang",
                table: "StarReviewDetails");

            migrationBuilder.DropIndex(
                name: "IX_StarReviewDetails_IDDonHang",
                table: "StarReviewDetails");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_ReviewID",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDDonHang",
                table: "StarReviewDetails");

            migrationBuilder.DropColumn(
                name: "ReviewID",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "StarReviewDetails",
                newName: "rating");

            migrationBuilder.AddColumn<string>(
                name: "TenNguoiBinhLuan",
                table: "StarReviewDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
