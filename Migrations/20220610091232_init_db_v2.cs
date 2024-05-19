using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class init_db_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc");

            migrationBuilder.DropForeignKey(
                name: "fk_detail_mausac_sizes",
                table: "MauSac_Detail");

            migrationBuilder.DropTable(
                name: "GioiTinh");

            migrationBuilder.DropTable(
                name: "HinhAnh_SanPham");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropPrimaryKey(
                name: "pk_MauSac_Detail",
                table: "MauSac_Detail");

            migrationBuilder.DropIndex(
                name: "IX_MauSac_Detail__id_mausac",
                table: "MauSac_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac");

            migrationBuilder.DropIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "Mota",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "_id_mausac",
                table: "MauSac_Detail");

            migrationBuilder.DropColumn(
                name: "_id",
                table: "MauSac");

            migrationBuilder.DropColumn(
                name: "GioiTinh_Code",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "Mota",
                table: "BoSuuTap");

            migrationBuilder.RenameColumn(
                name: "mamau",
                table: "MauSac",
                newName: "MaMau");

            migrationBuilder.AddColumn<string>(
                name: "MaMauSac",
                table: "MauSac_Detail",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MaMau",
                table: "MauSac",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenMau",
                table: "MauSac",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_MauSac_Detail",
                table: "MauSac_Detail",
                columns: new[] { "MaSanPham", "MaMauSac" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_mausac",
                table: "MauSac",
                column: "MaMau");

            migrationBuilder.CreateIndex(
                name: "IX_MauSac_Detail_MaMauSac",
                table: "MauSac_Detail",
                column: "MaMauSac");

            migrationBuilder.AddForeignKey(
                name: "fk_detail_mausac_sizes",
                table: "MauSac_Detail",
                column: "MaMauSac",
                principalTable: "MauSac",
                principalColumn: "MaMau",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_detail_mausac_sizes",
                table: "MauSac_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "pk_MauSac_Detail",
                table: "MauSac_Detail");

            migrationBuilder.DropIndex(
                name: "IX_MauSac_Detail_MaMauSac",
                table: "MauSac_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "pk_mausac",
                table: "MauSac");

            migrationBuilder.DropColumn(
                name: "MaMauSac",
                table: "MauSac_Detail");

            migrationBuilder.DropColumn(
                name: "TenMau",
                table: "MauSac");

            migrationBuilder.RenameColumn(
                name: "MaMau",
                table: "MauSac",
                newName: "mamau");

            migrationBuilder.AddColumn<string>(
                name: "Mota",
                table: "SanPham",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_id_mausac",
                table: "MauSac_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "mamau",
                table: "MauSac",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "_id",
                table: "MauSac",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GioiTinh_Code",
                table: "DanhMuc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mota",
                table: "BoSuuTap",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_MauSac_Detail",
                table: "MauSac_Detail",
                columns: new[] { "MaSanPham", "_id_mausac" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac",
                column: "_id");

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
                name: "IX_MauSac_Detail__id_mausac",
                table: "MauSac_Detail",
                column: "_id_mausac");

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

            migrationBuilder.AddForeignKey(
                name: "fk_detail_mausac_sizes",
                table: "MauSac_Detail",
                column: "_id_mausac",
                principalTable: "MauSac",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
