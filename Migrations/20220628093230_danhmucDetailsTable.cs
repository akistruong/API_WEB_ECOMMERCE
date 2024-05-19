using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class danhmucDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sanpham_danhmuc",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "_id_DM",
                table: "SanPham",
                newName: "DanhMucId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham__id_DM",
                table: "SanPham",
                newName: "IX_SanPham_DanhMucId");

            migrationBuilder.CreateTable(
                name: "DanhMucDetails",
                columns: table => new
                {
                    maSP = table.Column<string>(type: "char(10)", nullable: false),
                    danhMucId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucDetails", x => new { x.danhMucId, x.maSP });
                    table.ForeignKey(
                        name: "FK_DanhMucDetails_DanhMuc_danhMucId",
                        column: x => x.danhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucDetails_SanPham_maSP",
                        column: x => x.maSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDetails_maSP",
                table: "DanhMucDetails",
                column: "maSP");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_DanhMuc_DanhMucId",
                table: "SanPham",
                column: "DanhMucId",
                principalTable: "DanhMuc",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_DanhMuc_DanhMucId",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "DanhMucDetails");

            migrationBuilder.RenameColumn(
                name: "DanhMucId",
                table: "SanPham",
                newName: "_id_DM");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_DanhMucId",
                table: "SanPham",
                newName: "IX_SanPham__id_DM");

            migrationBuilder.AddForeignKey(
                name: "fk_sanpham_danhmuc",
                table: "SanPham",
                column: "_id_DM",
                principalTable: "DanhMuc",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
