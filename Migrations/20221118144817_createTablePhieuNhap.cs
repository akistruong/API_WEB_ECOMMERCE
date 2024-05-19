using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class createTablePhieuNhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.AddColumn<string>(
                name: "maPhieuNhap",
                table: "SoLuongDetails",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize", "maPhieuNhap" });

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
                columns: table => new
                {
                    maPhieuNhap = table.Column<string>(type: "char(10)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Dvt = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhaps", x => x.maPhieuNhap);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maPhieuNhap",
                table: "SoLuongDetails",
                column: "maPhieuNhap");

            migrationBuilder.AddForeignKey(
                name: "FK_SoLuongDetails_PhieuNhaps_maPhieuNhap",
                table: "SoLuongDetails",
                column: "maPhieuNhap",
                principalTable: "PhieuNhaps",
                principalColumn: "maPhieuNhap",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoLuongDetails_PhieuNhaps_maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_SoLuongDetails_maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "maPhieuNhap",
                table: "SoLuongDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize" });
        }
    }
}
