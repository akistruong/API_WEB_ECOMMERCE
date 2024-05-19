using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFKTblTaiKhoan_RoleGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_RoleGroup_RoleGroupNavigationGroupName",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan_RoleGroupNavigationGroupName",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "RoleGroupNavigationGroupName",
                table: "TaiKhoan");

            migrationBuilder.AlterColumn<string>(
                name: "RoleGroup",
                table: "TaiKhoan",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_RoleGroup",
                table: "TaiKhoan",
                column: "RoleGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_RoleGroup_RoleGroup",
                table: "TaiKhoan",
                column: "RoleGroup",
                principalTable: "RoleGroup",
                principalColumn: "GroupName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_RoleGroup_RoleGroup",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan_RoleGroup",
                table: "TaiKhoan");

            migrationBuilder.AlterColumn<string>(
                name: "RoleGroup",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleGroupNavigationGroupName",
                table: "TaiKhoan",
                type: "char(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_RoleGroupNavigationGroupName",
                table: "TaiKhoan",
                column: "RoleGroupNavigationGroupName");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_RoleGroup_RoleGroupNavigationGroupName",
                table: "TaiKhoan",
                column: "RoleGroupNavigationGroupName",
                principalTable: "RoleGroup",
                principalColumn: "GroupName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
