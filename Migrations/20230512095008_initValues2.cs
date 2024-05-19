using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initValues2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branchs",
                keyColumn: "MaChiNhanh",
                keyValue: "CN01",
                column: "TenChiNhanh",
                value: "Chi nhánh Đồng tháp");

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[,]
                {
                    { "CATMANAGER", "ADMIN", "", false },
                    { "MEMANAGER", "ADMIN", "", false },
                    { "BSTMNG", "ADMIN", "", false },
                    { "PNMANAGER", "ADMIN", "", false },
                    { "ORDERMNG", "ADMIN", "", false },
                    { "INVENTORYMNG", "ADMIN", "", false },
                    { "COUPONMNG", "ADMIN", "", false },
                    { "SALEMNG", "ADMIN", "", false }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "size" },
                values: new object[] { "47", "47" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "BSTMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "CATMANAGER", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "COUPONMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "INVENTORYMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "MEMANAGER", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "ORDERMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "PNMANAGER", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "SALEMNG", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "47");

            migrationBuilder.UpdateData(
                table: "Branchs",
                keyColumn: "MaChiNhanh",
                keyValue: "CN01",
                column: "TenChiNhanh",
                value: "Chi nhánh mặc định");
        }
    }
}
