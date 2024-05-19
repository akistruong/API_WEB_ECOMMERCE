using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initValues5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "   ", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "   ");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "CATEMNG", "Thêm, sửa, xóa, danh mục", "Quản lý danh mục", "" });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[] { "CATEMNG", "ADMIN", "", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "CATEMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "CATEMNG");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "   ", "Thêm, sửa, xóa, danh mục", "Quản lý danh mục", "" });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[] { "   ", "ADMIN", "", false });
        }
    }
}
