using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFiledIsActiveTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleDetails_Role_RoleCode",
                table: "RoleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoleDetails");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "TaiKhoan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleCode");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleDetails_Roles_RoleCode",
                table: "RoleDetails",
                column: "RoleCode",
                principalTable: "Roles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleDetails_Roles_RoleCode",
                table: "RoleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "TaiKhoan");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RoleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleCode");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleDetails_Role_RoleCode",
                table: "RoleDetails",
                column: "RoleCode",
                principalTable: "Role",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
