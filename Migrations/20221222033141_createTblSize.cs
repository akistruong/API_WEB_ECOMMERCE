using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class createTblSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IDSize",
                table: "SanPham",
                type: "char(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "ChiTietHoaDon",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(10)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDSize",
                table: "SanPham",
                column: "IDSize");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_SizeId",
                table: "ChiTietHoaDon",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Sizes_SizeId",
                table: "ChiTietHoaDon",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Sizes_IDSize",
                table: "SanPham",
                column: "IDSize",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Sizes_SizeId",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Sizes_IDSize",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IDSize",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_SizeId",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ChiTietHoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "IDSize",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldNullable: true);
        }
    }
}
