using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintFK_coupon_branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "Coupons",
                type: "char(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_MaChiNhanh",
                table: "Coupons",
                column: "MaChiNhanh",
                unique: true,
                filter: "[MaChiNhanh] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Branchs_MaChiNhanh",
                table: "Coupons",
                column: "MaChiNhanh",
                principalTable: "Branchs",
                principalColumn: "MaChiNhanh",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Branchs_MaChiNhanh",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_MaChiNhanh",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "Coupons");
        }
    }
}
