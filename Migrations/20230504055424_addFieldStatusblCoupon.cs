using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldStatusblCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "trangThai",
                table: "Coupons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[,]
                {
                    { "PNMANAGER", null, "Quản lý phiếu nhập", "" },
                    { "ORDERMNG", null, "Quản lý đơn hàng", "" },
                    { "ROLEMNG", null, "Quản lý quyền", "" },
                    { "INVENTORYMNG", null, "Quản lý kho hàng", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "INVENTORYMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "ORDERMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "PNMANAGER");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "ROLEMNG");

            migrationBuilder.DropColumn(
                name: "trangThai",
                table: "Coupons");
        }
    }
}
