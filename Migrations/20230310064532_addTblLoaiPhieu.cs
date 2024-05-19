using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblLoaiPhieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoaiPhieu",
                table: "PhieuNhapXuats",
                type: "char(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiPhieu",
                columns: table => new
                {
                    MaPhieu = table.Column<string>(type: "char(10)", nullable: false),
                    TenPhieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhieu", x => x.MaPhieu);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapXuats_LoaiPhieu",
                table: "PhieuNhapXuats",
                column: "LoaiPhieu");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapXuats_LoaiPhieu_LoaiPhieu",
                table: "PhieuNhapXuats",
                column: "LoaiPhieu",
                principalTable: "LoaiPhieu",
                principalColumn: "MaPhieu",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapXuats_LoaiPhieu_LoaiPhieu",
                table: "PhieuNhapXuats");

            migrationBuilder.DropTable(
                name: "LoaiPhieu");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapXuats_LoaiPhieu",
                table: "PhieuNhapXuats");

            migrationBuilder.AlterColumn<string>(
                name: "LoaiPhieu",
                table: "PhieuNhapXuats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldNullable: true);
        }
    }
}
