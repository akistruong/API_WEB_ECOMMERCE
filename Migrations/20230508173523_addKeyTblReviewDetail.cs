using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addKeyTblReviewDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails",
                columns: new[] { "MaSanPham", "StarReviewID", "IDDonHang" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails",
                columns: new[] { "MaSanPham", "StarReviewID" });
        }
    }
}
