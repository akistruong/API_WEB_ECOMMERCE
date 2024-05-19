using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateTblStarReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar");

            migrationBuilder.DropIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "reviewStar");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "reviewStar");

            migrationBuilder.AddColumn<decimal>(
                name: "TienDaGiam",
                table: "SanPham",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSale",
                table: "SanPham",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanPhamMaSanPham",
                table: "reviewStar",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StarReviewDetails",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    StarReviewID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguoiBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarReviewDetails", x => new { x.MaSanPham, x.StarReviewID });
                    table.ForeignKey(
                        name: "FK_StarReviewDetails_reviewStar_StarReviewID",
                        column: x => x.StarReviewID,
                        principalTable: "reviewStar",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarReviewDetails_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reviewStar_SanPhamMaSanPham",
                table: "reviewStar",
                column: "SanPhamMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_StarReviewDetails_StarReviewID",
                table: "StarReviewDetails",
                column: "StarReviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_reviewStar_SanPham_SanPhamMaSanPham",
                table: "reviewStar",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviewStar_SanPham_SanPhamMaSanPham",
                table: "reviewStar");

            migrationBuilder.DropTable(
                name: "StarReviewDetails");

            migrationBuilder.DropIndex(
                name: "IX_reviewStar_SanPhamMaSanPham",
                table: "reviewStar");

            migrationBuilder.DropColumn(
                name: "TienDaGiam",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "isSale",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SanPhamMaSanPham",
                table: "reviewStar");

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "reviewStar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "reviewStar",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
