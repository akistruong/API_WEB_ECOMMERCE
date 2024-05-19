using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addInitTblRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[,]
                {
                    { "PROCMANAGER", "Thêm, sửa, xóa, sản phẩm", "Quản lý sản phẩm", "" },
                    { "CATMANAGER", "Thêm, sửa, xóa, danh mục", "Quản lý danh mục", "" },
                    { "MEMANAGER", "Quản lý tài khoản hội viên", "Quản lý thành viên", "" },
                    { "BSTMNG", null, "Quản lý bộ sưu tập", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "BSTMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "CATMANAGER");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "MEMANAGER");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "PROCMANAGER");
        }
    }
}
