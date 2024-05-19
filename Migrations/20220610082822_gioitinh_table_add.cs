using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class gioitinh_table_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc",
                column: "GioiTinh_Code");

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

            migrationBuilder.DropIndex(
                name: "IX_DanhMuc_GioiTinh_Code",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "GioiTinh_Code",
                table: "DanhMuc");
        }
    }
}
