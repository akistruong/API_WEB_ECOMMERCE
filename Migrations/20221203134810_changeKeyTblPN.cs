using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class changeKeyTblPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_PhieuNhaps_maPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuNhaps",
                table: "PhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_maPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "maPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AlterColumn<string>(
                name: "maPhieuNhap",
                table: "PhieuNhaps",
                type: "char(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AddColumn<int>(
                name: "IDPN",
                table: "ChiTietPhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuNhaps",
                table: "PhieuNhaps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "maSP", "IDPN" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps",
                column: "IDPN");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_PhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps",
                column: "IDPN",
                principalTable: "PhieuNhaps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_PhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuNhaps",
                table: "PhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "IDPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AlterColumn<string>(
                name: "maPhieuNhap",
                table: "PhieuNhaps",
                type: "char(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "maPN",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuNhaps",
                table: "PhieuNhaps",
                column: "maPhieuNhap");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "maSP", "maPN" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_maPN",
                table: "ChiTietPhieuNhaps",
                column: "maPN");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_PhieuNhaps_maPN",
                table: "ChiTietPhieuNhaps",
                column: "maPN",
                principalTable: "PhieuNhaps",
                principalColumn: "maPhieuNhap",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
