using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class dropTblLichSuNhapXuatHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhoHangs_LichSuNhapHangs_IDLichSu",
                table: "KhoHangs");

            migrationBuilder.DropTable(
                name: "LichSuNhapHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs");

            migrationBuilder.DropIndex(
                name: "IX_KhoHangs_IDLichSu",
                table: "KhoHangs");

            migrationBuilder.DropColumn(
                name: "IDLichSu",
                table: "KhoHangs");

            migrationBuilder.AlterColumn<int>(
                name: "IDDiaChi",
                table: "NhaCungCap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAT",
                table: "ChiTietPhieuNhaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "logText",
                table: "ChiTietPhieuNhaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAT",
                table: "ChiTietPhieuNhaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs",
                columns: new[] { "MaChiNhanh", "MaSanPham" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs");

            migrationBuilder.DropColumn(
                name: "createdAT",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "logText",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "updatedAT",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AlterColumn<int>(
                name: "IDDiaChi",
                table: "NhaCungCap",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDLichSu",
                table: "KhoHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhoHangs",
                table: "KhoHangs",
                columns: new[] { "MaChiNhanh", "MaSanPham", "IDLichSu" });

            migrationBuilder.CreateTable(
                name: "LichSuNhapHangs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qtyChange = table.Column<int>(type: "int", nullable: true),
                    updatedAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuNhapHangs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhoHangs_IDLichSu",
                table: "KhoHangs",
                column: "IDLichSu");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoHangs_LichSuNhapHangs_IDLichSu",
                table: "KhoHangs",
                column: "IDLichSu",
                principalTable: "LichSuNhapHangs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
