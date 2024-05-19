using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblRoleGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleDetails_TaiKhoan_TenTaiKhoan",
                table: "RoleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoleDetails_TenTaiKhoan",
                table: "RoleDetails");

            migrationBuilder.DropColumn(
                name: "TenTaiKhoan",
                table: "RoleDetails");

            migrationBuilder.AddColumn<string>(
                name: "RoleGroup",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleGroupNavigationGroupName",
                table: "TaiKhoan",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleGroup",
                table: "RoleDetails",
                type: "char(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RoleDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails",
                columns: new[] { "RoleCode", "RoleGroup" });

            migrationBuilder.CreateTable(
                name: "RoleGroup",
                columns: table => new
                {
                    GroupName = table.Column<string>(type: "char(20)", nullable: false),
                    GroupDsc = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroup", x => x.GroupName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_RoleGroupNavigationGroupName",
                table: "TaiKhoan",
                column: "RoleGroupNavigationGroupName");

            migrationBuilder.CreateIndex(
                name: "IX_RoleDetails_RoleGroup",
                table: "RoleDetails",
                column: "RoleGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleDetails_RoleGroup_RoleGroup",
                table: "RoleDetails",
                column: "RoleGroup",
                principalTable: "RoleGroup",
                principalColumn: "GroupName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_RoleGroup_RoleGroupNavigationGroupName",
                table: "TaiKhoan",
                column: "RoleGroupNavigationGroupName",
                principalTable: "RoleGroup",
                principalColumn: "GroupName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleDetails_RoleGroup_RoleGroup",
                table: "RoleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_RoleGroup_RoleGroupNavigationGroupName",
                table: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "RoleGroup");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan_RoleGroupNavigationGroupName",
                table: "TaiKhoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoleDetails_RoleGroup",
                table: "RoleDetails");

            migrationBuilder.DropColumn(
                name: "RoleGroup",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "RoleGroupNavigationGroupName",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "RoleGroup",
                table: "RoleDetails");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RoleDetails");

            migrationBuilder.AddColumn<string>(
                name: "TenTaiKhoan",
                table: "RoleDetails",
                type: "char(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails",
                columns: new[] { "RoleCode", "TenTaiKhoan" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleDetails_TenTaiKhoan",
                table: "RoleDetails",
                column: "TenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleDetails_TaiKhoan_TenTaiKhoan",
                table: "RoleDetails",
                column: "TenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
