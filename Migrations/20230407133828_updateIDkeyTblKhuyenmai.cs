using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateIDkeyTblKhuyenmai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhuyenMais_KhuyenMais_maDotKhuyenMai",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhuyenMais",
                table: "KhuyenMais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietKhuyenMais",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKhuyenMais_maDotKhuyenMai",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropColumn(
                name: "MaDotKhuyenMai",
                table: "KhuyenMais");

            migrationBuilder.DropColumn(
                name: "maDotKhuyenMai",
                table: "ChiTietKhuyenMais");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "KhuyenMais",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhuyenMais",
                table: "KhuyenMais",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietKhuyenMais",
                table: "ChiTietKhuyenMais",
                columns: new[] { "maSanPham", "IDDotKhuyenMai" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMais_IDDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                column: "IDDotKhuyenMai");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhuyenMais_KhuyenMais_IDDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                column: "IDDotKhuyenMai",
                principalTable: "KhuyenMais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhuyenMais_KhuyenMais_IDDotKhuyenMai",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhuyenMais",
                table: "KhuyenMais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietKhuyenMais",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKhuyenMais_IDDotKhuyenMai",
                table: "ChiTietKhuyenMais");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "KhuyenMais");

            migrationBuilder.DropColumn(
                name: "IDDotKhuyenMai",
                table: "ChiTietKhuyenMais");

            migrationBuilder.AddColumn<string>(
                name: "MaDotKhuyenMai",
                table: "KhuyenMais",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "maDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhuyenMais",
                table: "KhuyenMais",
                column: "MaDotKhuyenMai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietKhuyenMais",
                table: "ChiTietKhuyenMais",
                columns: new[] { "maSanPham", "maDotKhuyenMai" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMais_maDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                column: "maDotKhuyenMai");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhuyenMais_KhuyenMais_maDotKhuyenMai",
                table: "ChiTietKhuyenMais",
                column: "maDotKhuyenMai",
                principalTable: "KhuyenMais",
                principalColumn: "MaDotKhuyenMai",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
