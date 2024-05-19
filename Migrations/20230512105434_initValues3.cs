using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initValues3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "CATMANAGER", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "CATMANAGER");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[,]
                {
                    { "   ", "Thêm, sửa, xóa, danh mục", "Quản lý danh mục", "" },
                    { "ROLEMNG", null, "Quản lý phân quyền", "" },
                    { "PRODMNG", null, "Quản lý Sản phẩm", "" },
                    { "TKDTMNG", null, "Thống kê doanh thu", "" },
                    { "CUSTOMERMNG", null, "Quản lý khách hàng", "" }
                });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[,]
                {
                    { "   ", "ADMIN", "", false },
                    { "ROLEMNG", "ADMIN", "", false },
                    { "PRODMNG", "ADMIN", "", false },
                    { "TKDTMNG", "ADMIN", "", false },
                    { "CUSTOMERMNG", "ADMIN", "", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "   ", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "CUSTOMERMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "PRODMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "ROLEMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "TKDTMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "   ");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "CUSTOMERMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "PRODMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "ROLEMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "TKDTMNG");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "CATMANAGER", "Thêm, sửa, xóa, danh mục", "Quản lý danh mục", "" });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[] { "CATMANAGER", "ADMIN", "", false });
        }
    }
}
