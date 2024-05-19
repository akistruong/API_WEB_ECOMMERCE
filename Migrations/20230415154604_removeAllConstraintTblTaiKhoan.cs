using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeAllConstraintTblTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaChis_TaiKhoan_TenTaiKhoan",
                table: "DiaChis");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_TaiKhoan_creatorID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleDetails_TaiKhoan_TenTaiKhoan",
                table: "RoleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_TaiKhoan_UserID",
                table: "RoomMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessages_UserID",
                table: "RoomMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoleDetails_TenTaiKhoan",
                table: "RoleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Messages_creatorID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_DiaChis_TenTaiKhoan",
                table: "DiaChis");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "RoomMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AlterColumn<string>(
                name: "TenTaiKhoan",
                table: "RoleDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AlterColumn<string>(
                name: "creatorID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenTaiKhoan",
                table: "DiaChis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "MaSanPham" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails",
                column: "RoleCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "RoomMessages",
                type: "char(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenTaiKhoan",
                table: "RoleDetails",
                type: "char(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "creatorID",
                table: "Messages",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenTaiKhoan",
                table: "DiaChis",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "MaSanPham", "UserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleDetails",
                table: "RoleDetails",
                columns: new[] { "RoleCode", "TenTaiKhoan" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_UserID",
                table: "RoomMessages",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleDetails_TenTaiKhoan",
                table: "RoleDetails",
                column: "TenTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_creatorID",
                table: "Messages",
                column: "creatorID");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChis_TenTaiKhoan",
                table: "DiaChis",
                column: "TenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_TaiKhoan_TenTaiKhoan",
                table: "DiaChis",
                column: "TenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_TaiKhoan_creatorID",
                table: "Messages",
                column: "creatorID",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleDetails_TaiKhoan_TenTaiKhoan",
                table: "RoleDetails",
                column: "TenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_TaiKhoan_UserID",
                table: "RoomMessages",
                column: "UserID",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
