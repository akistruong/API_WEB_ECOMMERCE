using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblRoleDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleCode = table.Column<string>(type: "char(15)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleCode);
                });

            migrationBuilder.CreateTable(
                name: "RoleDetails",
                columns: table => new
                {
                    TenTaiKhoan = table.Column<string>(type: "char(20)", nullable: false),
                    RoleCode = table.Column<string>(type: "char(15)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDetails", x => new { x.RoleCode, x.TenTaiKhoan });
                    table.ForeignKey(
                        name: "FK_RoleDetails_Role_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "Role",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleDetails_TaiKhoan_TenTaiKhoan",
                        column: x => x.TenTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleDetails_TenTaiKhoan",
                table: "RoleDetails",
                column: "TenTaiKhoan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleDetails");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
