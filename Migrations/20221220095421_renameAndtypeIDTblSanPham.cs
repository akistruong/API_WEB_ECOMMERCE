using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class renameAndtypeIDTblSanPham : Migration
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
                name: "FK_ChiTietPhieuNhaps_SanPham_maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDetails_SanPham_maSP",
                table: "DanhMucDetails");

            migrationBuilder.DropForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_SanPham_MaSP",
                table: "RoomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_SoLuongDetails_SanPham_maSanPham",
                table: "SoLuongDetails");

            migrationBuilder.DropTable(
                name: "ChiTietSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails");

            migrationBuilder.DropIndex(
                name: "IX_SoLuongDetails_maSanPham",
                table: "SoLuongDetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sanpham",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessages_MaSP",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucDetails",
                table: "DanhMucDetails");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDetails_maSP",
                table: "DanhMucDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
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
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "img",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "MaSP",
                table: "RoomMessages");

            migrationBuilder.DropColumn(
                name: "MasanPham",
                table: "reviewStar");

            migrationBuilder.DropColumn(
                name: "maSP",
                table: "DanhMucDetails");

            migrationBuilder.DropColumn(
                name: "maSP",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "MasanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "ChiTietHinhAnh");

            migrationBuilder.RenameColumn(
                name: "maSanPham",
                table: "SoLuongDetails",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "SanPham",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "SoLuongDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "RoomMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "reviewStar",
                type: "int",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "DanhMucDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "SanPhamId",
                table: "ChiTietPhieuNhaps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "ChiTietHinhAnh",
                type: "int",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "IDSanPham", "_idSize", "MaSanPham" });

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
                column: "IDPN");

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
                name: "IX_ChiTietPhieuNhaps_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_idSize_SanPhamDet~",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SanPhamDetailsNavigationmaMau", "SanPhamDetailsNavigationIDSanPham", "SanPhamDetailsNavigation_idSize", "SanPhamDetailsNavigationMaSanPham" });

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
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_id~",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "SanPhamDetailsNavigationmaMau", "SanPhamDetailsNavigationIDSanPham", "SanPhamDetailsNavigation_idSize", "SanPhamDetailsNavigationMaSanPham" },
                principalTable: "SoLuongDetails",
                principalColumns: new[] { "maMau", "IDSanPham", "_idSize", "MaSanPham" },
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_ChiTietPhieuNhaps_SoLuongDetails_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_id~",
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
                name: "IX_ChiTietPhieuNhaps_SanPhamDetailsNavigationmaMau_SanPhamDetailsNavigationIDSanPham_SanPhamDetailsNavigation_idSize_SanPhamDet~",
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

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "RoomMessages");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "reviewStar");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "DanhMucDetails");

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

            migrationBuilder.DropColumn(
                name: "SanPhamId",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "ChiTietHinhAnh");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "SoLuongDetails",
                newName: "maSanPham");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SanPham",
                newName: "_id");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "SanPham",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "SanPham",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSP",
                table: "RoomMessages",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MasanPham",
                table: "reviewStar",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "maSP",
                table: "DanhMucDetails",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "maSP",
                table: "ChiTietPhieuNhaps",
                type: "char(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MasanPham",
                table: "ChiTietHoaDon",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoLuongDetails",
                table: "SoLuongDetails",
                columns: new[] { "maMau", "maSanPham", "_idSize" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_sanpham",
                table: "SanPham",
                column: "MaSanPham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "MaSP", "UserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucDetails",
                table: "DanhMucDetails",
                columns: new[] { "danhMucId", "maSP" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps",
                columns: new[] { "maSP", "IDPN" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHD",
                table: "ChiTietHoaDon",
                columns: new[] { "_id_HoaDon", "MasanPham", "Size", "Color" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_CTHA",
                table: "ChiTietHinhAnh",
                columns: new[] { "MaSanPham", "_id_HinhAnh", "IdMaMau" });

            migrationBuilder.CreateTable(
                name: "ChiTietSale",
                columns: table => new
                {
                    _id_sale = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    giamgia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cts", x => new { x._id_sale, x.MaSanPham });
                    table.ForeignKey(
                        name: "fk_cts_Sale",
                        column: x => x._id_sale,
                        principalTable: "Sale",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cts_SP",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoLuongDetails_maSanPham",
                table: "SoLuongDetails",
                column: "maSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_MaSP",
                table: "RoomMessages",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_reviewStar_MasanPham",
                table: "reviewStar",
                column: "MasanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDetails_maSP",
                table: "DanhMucDetails",
                column: "maSP");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_IDPN",
                table: "ChiTietPhieuNhaps",
                column: "IDPN");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MasanPham",
                table: "ChiTietHoaDon",
                column: "MasanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSale_MaSanPham",
                table: "ChiTietSale",
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
                column: "MasanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_SanPham_maSP",
                table: "ChiTietPhieuNhaps",
                column: "maSP",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDetails_SanPham_maSP",
                table: "DanhMucDetails",
                column: "maSP",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviewStar_sanpham",
                table: "reviewStar",
                column: "MasanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_SanPham_MaSP",
                table: "RoomMessages",
                column: "MaSP",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoLuongDetails_SanPham_maSanPham",
                table: "SoLuongDetails",
                column: "maSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
