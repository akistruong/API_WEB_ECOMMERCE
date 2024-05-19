using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class init_db_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaMauSac",
                table: "MauSac_Detail",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "TenMau",
                table: "MauSac",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MaMau",
                table: "MauSac",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "GioiTinh_Code",
                table: "DanhMuc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GioiTinh",
                columns: table => new
                {
                    gioitinh_code = table.Column<int>(type: "int", nullable: false),
                    gioitinh_text = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gioitinh", x => x.gioitinh_code);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh_SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    _id_HinhAnh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hinhanh_sanpham", x => new { x.MaSanPham, x._id_HinhAnh });
                    table.ForeignKey(
                        name: "fk_cthd_hinhanh",
                        column: x => x._id_HinhAnh,
                        principalTable: "HinhAnh",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cthd_sanpham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc",
                column: "GioiTinh_Code");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPham__id_HinhAnh",
                table: "HinhAnh_SanPham",
                column: "_id_HinhAnh");

            migrationBuilder.AddForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc",
                column: "GioiTinh_Code",
                principalTable: "GioiTinh",
                principalColumn: "gioitinh_code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc");

            migrationBuilder.DropTable(
                name: "GioiTinh");

            migrationBuilder.DropTable(
                name: "HinhAnh_SanPham");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "GioiTinh_Code",
                table: "DanhMuc");

            migrationBuilder.AlterColumn<string>(
                name: "MaMauSac",
                table: "MauSac_Detail",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 20,
                oldDefaultValueSql: "('')");

            migrationBuilder.AlterColumn<string>(
                name: "TenMau",
                table: "MauSac",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "MaMau",
                table: "MauSac",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 20,
                oldDefaultValueSql: "('')");
        }
    }
}
