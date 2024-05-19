using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class dropTblSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Sizes_Size",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "SoLuongDetails");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_Size",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "SoLuongDetailsMaSanPham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SoLuongDetails_idSize",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.AddColumn<int>(
                name: "IDAnh",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDColor",
                table: "SanPham",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDSize",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ChiTietHoaDon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "MaSanPham", "Color" });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDAnh",
                table: "SanPham",
                column: "IDAnh");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDColor",
                table: "SanPham",
                column: "IDColor");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_HinhAnh_IDAnh",
                table: "SanPham",
                column: "IDAnh",
                principalTable: "HinhAnh",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_MauSac_IDColor",
                table: "SanPham",
                column: "IDColor",
                principalTable: "MauSac",
                principalColumn: "MaMau",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_HinhAnh_IDAnh",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_MauSac_IDColor",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IDAnh",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IDColor",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "IDAnh",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDColor",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDSize",
                table: "SanPham");

            migrationBuilder.AddColumn<string>(
                name: "SoLuongDetailsMaSanPham",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongDetails_idSize",
                table: "ChiTietPhieuNhaps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "MaSanPham", "Size", "Color" });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "SoLuongDetails",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", nullable: false),
                    _idSize = table.Column<int>(type: "int", nullable: false),
                    maMau = table.Column<string>(type: "char(20)", nullable: false),
                    GiaBanLe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GiaBanSi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IDSanPham = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: true),
                    SoluongTon = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0"),
                    VAT = table.Column<int>(type: "int", nullable: true),
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoLuongDetails", x => new { x.MaSanPham, x._idSize, x.maMau });
                    table.ForeignKey(
                        name: "FK_SoLuongDetails_MauSac_maMau",
                        column: x => x.maMau,
                        principalTable: "MauSac",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoLuongDetails_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoLuongDetails_Sizes__idSize",
                        column: x => x._idSize,
                        principalTable: "Sizes",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SoLuongDetailsMaSanPham", "SoLuongDetails_idSize", "SoLuongDetailsmaMau" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_Size",
                table: "ChiTietHoaDon",
                column: "Size");

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails__idSize",
                table: "SoLuongDetails",
                column: "_idSize");

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maMau",
                table: "SoLuongDetails",
                column: "maMau");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Sizes_Size",
                table: "ChiTietHoaDon",
                column: "Size",
                principalTable: "Sizes",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SoLuongDetailsMaSanPham", "SoLuongDetails_idSize", "SoLuongDetailsmaMau" },
                principalTable: "SoLuongDetails",
                principalColumns: new[] { "MaSanPham", "_idSize", "maMau" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
