using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class rmvFieldIdDmdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_DanhMuc_DanhMucId",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_DanhMucId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "DanhMucId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DanhMucDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DanhMucId",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DanhMucDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_DanhMucId",
                table: "SanPham",
                column: "DanhMucId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_DanhMuc_DanhMucId",
                table: "SanPham",
                column: "DanhMucId",
                principalTable: "DanhMuc",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
