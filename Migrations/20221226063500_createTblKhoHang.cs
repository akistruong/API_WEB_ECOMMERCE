using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class createTblKhoHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenSanPham",
                table: "SanPham",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "LichSuNhapHangs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    qtyChange = table.Column<int>(type: "int", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuNhapHangs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhoHangs",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    MaChiNhanh = table.Column<string>(type: "char(20)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDLichSu = table.Column<int>(type: "int", nullable: false),
                    TonKho = table.Column<int>(type: "int", nullable: false),
                    GiaVon = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoLuongTon = table.Column<int>(type: "int", nullable: true),
                    SoLuongCoTheban = table.Column<int>(type: "int", nullable: true),
                    SoLuongHangDangVe = table.Column<int>(type: "int", nullable: true),
                    SoLuongHangDangGiao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoHangs", x => new { x.MaChiNhanh, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_KhoHangs_Branchs_MaChiNhanh",
                        column: x => x.MaChiNhanh,
                        principalTable: "Branchs",
                        principalColumn: "MaChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoHangs_LichSuNhapHangs_IDLichSu",
                        column: x => x.IDLichSu,
                        principalTable: "LichSuNhapHangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoHangs_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhoHangs_IDLichSu",
                table: "KhoHangs",
                column: "IDLichSu");

            migrationBuilder.CreateIndex(
                name: "IX_KhoHangs_MaSanPham",
                table: "KhoHangs",
                column: "MaSanPham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoHangs");

            migrationBuilder.DropTable(
                name: "LichSuNhapHangs");

            migrationBuilder.AlterColumn<string>(
                name: "TenSanPham",
                table: "SanPham",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
