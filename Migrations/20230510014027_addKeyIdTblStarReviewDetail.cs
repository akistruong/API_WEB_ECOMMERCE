using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addKeyIdTblStarReviewDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "StarReviewDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails",
                columns: new[] { "StarReviewID", "IDDonHang", "ID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "StarReviewDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarReviewDetails",
                table: "StarReviewDetails",
                columns: new[] { "StarReviewID", "IDDonHang" });
        }
    }
}
