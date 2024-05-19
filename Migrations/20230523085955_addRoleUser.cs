using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addRoleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup", "Type", "isActive" },
                values: new object[] { "MEMANAGER", "USER", "", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumns: new[] { "RoleCode", "RoleGroup" },
                keyValues: new object[] { "MEMANAGER", "USER" });
        }
    }
}
