using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initValues4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "HOMEADMIN", "Xem tổng quan về cửa hàng, doanh thu, sản phẩm nổi bật,...", "Trang chủ admin", "" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "HOMEMANAGER", "Xem tổng quan về đơn hàng, kho hàng dành cho người quản lý", "Trang chủ manager", "" });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[] { "HOMEADMIN", "ADMIN", "", false });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[] { "HOMEMANAGER", "ADMIN", "", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "HOMEADMIN", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "HOMEMANAGER", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "HOMEADMIN");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "HOMEMANAGER");
        }
    }
}
