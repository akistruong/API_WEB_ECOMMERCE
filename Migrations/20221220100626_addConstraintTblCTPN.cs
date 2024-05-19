using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintTblCTPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_id~",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_idSize_SanPhamDet~",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SanPhamDetailsNavigationIDSanPham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SanPhamDetailsNavigationMaSanPham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SanPhamDetailsNavigation_idSize",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SanPhamDetailsNavigationmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AlterColumn<string>(
                name: "maMau",
                table: "SoLuongDetails",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AddColumn<string>(
                name: "maSP",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                column: "MaSanPham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "IDPN", "maSP" });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maMau",
                table: "SoLuongDetails",
                column: "maMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_maSP",
                table: "ChiTietPhieuNhaps",
                column: "maSP");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_maSP",
                table: "ChiTietPhieuNhaps",
                column: "maSP",
                principalTable: "SoLuongDetails",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_SoLuongDetails_maMau",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AlterColumn<string>(
                name: "maMau",
                table: "SoLuongDetails",
                type: "char(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SanPhamDetailsNavigationIDSanPham",
                table: "ChiTietPhieuNhaps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanPhamDetailsNavigationMaSanPham",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SanPhamDetailsNavigation_idSize",
                table: "ChiTietPhieuNhaps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanPhamDetailsNavigationmaMau",
                table: "ChiTietPhieuNhaps",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "IDSanPham", "_idSize", "MaSanPham" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                column: "IDPN");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_idSize_SanPhamDet~",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SanPhamDetailsNavigationmaMau", "SanPhamDetailsNavigationIDSanPham", "SanPhamDetailsNavigation_idSize", "SanPhamDetailsNavigationMaSanPham" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_id~",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SanPhamDetailsNavigationmaMau", "SanPhamDetailsNavigationIDSanPham", "SanPhamDetailsNavigation_idSize", "SanPhamDetailsNavigationMaSanPham" },
                principalTable: "SoLuongDetails",
                principalColumns: new[] { "maMau", "IDSanPham", "_idSize", "MaSanPham" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
