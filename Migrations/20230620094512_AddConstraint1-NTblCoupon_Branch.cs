using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class AddConstraint1NTblCoupon_Branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Branchs_MaChiNhanh",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_MaChiNhanh",
                table: "Coupons");

            migrationBuilder.AddColumn<string>(
                name: "CouponNavigationMaCoupon",
                table: "Branchs",
                type: "char(15)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_MaChiNhanh",
                table: "Coupons",
                column: "MaChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_CouponNavigationMaCoupon",
                table: "Branchs",
                column: "CouponNavigationMaCoupon");

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Coupons_CouponNavigationMaCoupon",
                table: "Branchs",
                column: "CouponNavigationMaCoupon",
                principalTable: "Coupons",
                principalColumn: "MaCoupon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Branchs_MaChiNhanh",
                table: "Coupons",
                column: "MaChiNhanh",
                principalTable: "Branchs",
                principalColumn: "MaChiNhanh",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Coupons_CouponNavigationMaCoupon",
                table: "Branchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Branchs_MaChiNhanh",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_MaChiNhanh",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Branchs_CouponNavigationMaCoupon",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "CouponNavigationMaCoupon",
                table: "Branchs");

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
    }
}
