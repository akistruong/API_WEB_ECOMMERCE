using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "PROCMANAGER");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "ROLEMNG");

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "MaChiNhanh", "DiaChiNavigationID", "IDAddress", "TenChiNhanh", "isDefault" },
                values: new object[] { "CN01", null, null, "Chi nhánh mặc định", false });

            migrationBuilder.InsertData(
                table: "MauSac",
                column: "MaMau",
                values: new object[]
                {
                    "teal",
                    "gray",
                    "olive",
                    "purple",
                    "silver",
                    "maroon",
                    "aqua",
                    "yellow",
                    "browb",
                    "green",
                    "blue",
                    "white",
                    "black",
                    "red",
                    "fuchsia"
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "GroupName", "GroupDsc" },
                values: new object[,]
                {
                    { "MANAGER", null },
                    { "USER", null },
                    { "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[,]
                {
                    { "COUPONMNG", null, "Quản lý Coupon", "" },
                    { "SALEMNG", null, "Quản lý Khuyến mãi", "" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "size" },
                values: new object[,]
                {
                    { "40", "40" },
                    { "2XL", "2XL" },
                    { "XL", "XL" },
                    { "L", "L" },
                    { "M", "M" },
                    { "S", "S" },
                    { "46", "46" },
                    { "45", "45" },
                    { "44", "44" },
                    { "43", "43" },
                    { "42", "42" },
                    { "41", "41" },
                    { "39", "39" },
                    { "28", "28" },
                    { "37", "37" },
                    { "36", "36" },
                    { "35", "35" },
                    { "34", "34" },
                    { "33", "33" },
                    { "32", "32" },
                    { "31", "31" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "size" },
                values: new object[,]
                {
                    { "30", "30" },
                    { "29", "29" },
                    { "3XL", "3XL" },
                    { "27", "27" },
                    { "26", "26" },
                    { "25", "25" },
                    { "38", "38" },
                    { "4XL", "4XL" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "TenTaiKhoan", "Avatar", "Email", "Gioitinh", "MatKhau", "RoleGroup", "SoLanMuaHang", "TenHienThi", "TienThanhToan", "idKH", "isActive", "isBlocked" },
                values: new object[] { "admin", "", null, null, "admin", "ADMIN", 0, "", 0m, null, false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "MaChiNhanh",
                keyValue: "CN01");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "aqua");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "black");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "blue");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "browb");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "fuchsia");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "gray");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "green");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "maroon");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "olive");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "purple");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "red");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "silver");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "teal");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "white");

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "MaMau",
                keyValue: "yellow");

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "GroupName",
                keyValue: "MANAGER");

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "GroupName",
                keyValue: "USER");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "COUPONMNG");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleCode",
                keyValue: "SALEMNG");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "26");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "27");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "28");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "29");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "2XL");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "30");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "31");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "32");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "33");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "34");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "35");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "36");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "37");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "38");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "39");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "3XL");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "40");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "41");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "42");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "43");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "44");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "45");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "46");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "4XL");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "L");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "M");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "S");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: "XL");

            migrationBuilder.DeleteData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "GroupName",
                keyValue: "ADMIN");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "PROCMANAGER", "Thêm, sửa, xóa, sản phẩm", "Quản lý sản phẩm", "" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleCode", "RoleDsc", "RoleName", "Type" },
                values: new object[] { "ROLEMNG", null, "Quản lý quyền", "" });
        }
    }
}
