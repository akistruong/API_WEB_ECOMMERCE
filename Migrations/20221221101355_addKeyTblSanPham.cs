using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addKeyTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ctha_sanpham",
                table: "ChiTietHinhAnh");

            migrationBuilder.DropForeignKey(
                name: "fk_ChiTietHoaDon_KH",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SanPham_SanPhamId",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDetails_SanPham_IDSanPham",
                table: "DanhMucDetails");

            migrationBuilder.DropForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_SanPham_IDSanPham",
                table: "RoomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_SoLuongDetails_SanPham_IDSanPham",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_SoLuongDetails_IDSanPham",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sanpham",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessages_IDSanPham",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucDetails",
                table: "DanhMucDetails");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDetails_IDSanPham",
                table: "DanhMucDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_SanPhamId",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHA",
                table: "ChiTietHinhAnh");

            migrationBuilder.RenameColumn(
                name: "SanPhamId",
                table: "ChiTietPhieuNhaps",
                newName: "SoLuongDetails_idSize");

            migrationBuilder.RenameColumn(
                name: "maSP",
                table: "ChiTietPhieuNhaps",
                newName: "MaSanPham");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "Vats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "Types",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "maMau",
                table: "SoLuongDetails",
                type: "char(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "_idSize",
                table: "SoLuongDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "SanPham",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentID",
                table: "SanPham",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "RoomMessages",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "reviewStar",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "DanhMucDetails",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SoLuongDetailsMaSanPham",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "ChiTietHoaDon",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "ChiTietHinhAnh",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "BoSuuTap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "MaSanPham", "_idSize", "maMau" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_sanpham",
                table: "SanPham",
                column: "MaSanPham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "MaSanPham", "UserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucDetails",
                table: "DanhMucDetails",
                columns: new[] { "danhMucId", "MaSanPham" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "MaSanPham", "IDPN" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "MaSanPham", "Size", "Color" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHA",
                table: "ChiTietHinhAnh",
                columns: new[] { "MaSanPham", "_id_HinhAnh", "IdMaMau" });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ParentID",
                table: "SanPham",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_MaSanPham",
                table: "RoomMessages",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDetails_MaSanPham",
                table: "DanhMucDetails",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps",
                column: "IDPN");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SoLuongDetailsMaSanPham", "SoLuongDetails_idSize", "SoLuongDetailsmaMau" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "fk_ctha_sanpham",
                table: "ChiTietHinhAnh",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ChiTietHoaDon_KH",
                table: "ChiTietHoaDon",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SanPham_MaSanPham",
                table: "ChiTietPhieuNhaps",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SoLuongDetailsMaSanPham", "SoLuongDetails_idSize", "SoLuongDetailsmaMau" },
                principalTable: "SoLuongDetails",
                principalColumns: new[] { "MaSanPham", "_idSize", "maMau" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDetails_SanPham_MaSanPham",
                table: "DanhMucDetails",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_SanPham_MaSanPham",
                table: "RoomMessages",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_SanPham_ParentID",
                table: "SanPham",
                column: "ParentID",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoLuongDetails_SanPham_MaSanPham",
                table: "SoLuongDetails",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ctha_sanpham",
                table: "ChiTietHinhAnh");

            migrationBuilder.DropForeignKey(
                name: "fk_ChiTietHoaDon_KH",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SanPham_MaSanPham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDetails_SanPham_MaSanPham",
                table: "DanhMucDetails");

            migrationBuilder.DropForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_SanPham_MaSanPham",
                table: "RoomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_SanPham_ParentID",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SoLuongDetails_SanPham_MaSanPham",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sanpham",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_ParentID",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessages_MaSanPham",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucDetails",
                table: "DanhMucDetails");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDetails_MaSanPham",
                table: "DanhMucDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_SoLuongDetailsMaSanPham_SoLuongDetails_idSize_SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_CTHA",
                table: "ChiTietHinhAnh");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "Vats");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "RoomMessages");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "reviewStar");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "DanhMucDetails");

            migrationBuilder.DropColumn(
                name: "SoLuongDetailsMaSanPham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "SoLuongDetailsmaMau",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "ChiTietHinhAnh");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "BoSuuTap");

            migrationBuilder.RenameColumn(
                name: "SoLuongDetails_idSize",
                table: "ChiTietPhieuNhaps",
                newName: "SanPhamId");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "ChiTietPhieuNhaps",
                newName: "maSP");

            migrationBuilder.AlterColumn<string>(
                name: "maMau",
                table: "SoLuongDetails",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AlterColumn<int>(
                name: "_idSize",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                column: "MaSanPham");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sanpham",
                table: "SanPham",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "IDSanPham", "UserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucDetails",
                table: "DanhMucDetails",
                columns: new[] { "danhMucId", "IDSanPham" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "IDPN", "maSP" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "IDSanPham", "Size", "Color" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHA",
                table: "ChiTietHinhAnh",
                columns: new[] { "IDSanPham", "_id_HinhAnh", "IdMaMau" });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_IDSanPham",
                table: "SoLuongDetails",
                column: "IDSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_IDSanPham",
                table: "RoomMessages",
                column: "IDSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar",
                column: "IDSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDetails_IDSanPham",
                table: "DanhMucDetails",
                column: "IDSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_maSP",
                table: "ChiTietPhieuNhaps",
                column: "maSP");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_SanPhamId",
                table: "ChiTietPhieuNhaps",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon",
                column: "IDSanPham");

            migrationBuilder.AddForeignKey(
                name: "fk_ctha_sanpham",
                table: "ChiTietHinhAnh",
                column: "IDSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ChiTietHoaDon_KH",
                table: "ChiTietHoaDon",
                column: "IDSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SanPham_SanPhamId",
                table: "ChiTietPhieuNhaps",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_maSP",
                table: "ChiTietPhieuNhaps",
                column: "maSP",
                principalTable: "SoLuongDetails",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDetails_SanPham_IDSanPham",
                table: "DanhMucDetails",
                column: "IDSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar",
                column: "IDSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_SanPham_IDSanPham",
                table: "RoomMessages",
                column: "IDSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoLuongDetails_SanPham_IDSanPham",
                table: "SoLuongDetails",
                column: "IDSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
