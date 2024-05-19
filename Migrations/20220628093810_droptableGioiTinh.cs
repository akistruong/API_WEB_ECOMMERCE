using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class droptableGioiTinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMuc_ParentCategory_ParentCategoryID",
                table: "DanhMuc");

            migrationBuilder.DropForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc");

            migrationBuilder.DropTable(
                name: "GioiTinh");

            migrationBuilder.RenameColumn(
                name: "GioiTinh_Code",
                table: "DanhMuc",
                newName: "GioiTinhCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMuc_ParentCategory_ParentCategoryID",
                table: "DanhMuc",
                column: "ParentCategoryID",
                principalTable: "ParentCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMuc_ParentCategory_ParentCategoryID",
                table: "DanhMuc");

            migrationBuilder.RenameColumn(
                name: "GioiTinhCode",
                table: "DanhMuc",
                newName: "GioiTinh_Code");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMuc_ParentCategory_ParentCategoryID",
                table: "DanhMuc",
                column: "ParentCategoryID",
                principalTable: "ParentCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_DM_GT",
                table: "DanhMuc",
                column: "GioiTinh_Code",
                principalTable: "GioiTinh",
                principalColumn: "gioitinh_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
