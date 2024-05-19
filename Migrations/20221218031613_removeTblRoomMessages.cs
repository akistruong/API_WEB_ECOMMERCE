using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeTblRoomMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_ParentMessageID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_Messages_MessageID",
                table: "RoomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_SanPham_MaSP",
                table: "RoomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_TaiKhoan_UserID",
                table: "RoomMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessages_MaSP",
                table: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessages_UserID",
                table: "RoomMessages");

            migrationBuilder.RenameTable(
                name: "RoomMessages",
                newName: "RoomMessage");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "RoomMessage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AlterColumn<string>(
                name: "MaSP",
                table: "RoomMessage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AddColumn<string>(
                name: "SanPhamNavigationMaSanPham",
                table: "RoomMessage",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaiKhoanNavigationTenTaiKhoan",
                table: "RoomMessage",
                type: "char(20)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessage",
                table: "RoomMessage",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessage_MessageID",
                table: "RoomMessage",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessage_SanPhamNavigationMaSanPham",
                table: "RoomMessage",
                column: "SanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessage_TaiKhoanNavigationTenTaiKhoan",
                table: "RoomMessage",
                column: "TaiKhoanNavigationTenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_ParentMessageID",
                table: "Messages",
                column: "ParentMessageID",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessage_Messages_MessageID",
                table: "RoomMessage",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessage_SanPham_SanPhamNavigationMaSanPham",
                table: "RoomMessage",
                column: "SanPhamNavigationMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessage_TaiKhoan_TaiKhoanNavigationTenTaiKhoan",
                table: "RoomMessage",
                column: "TaiKhoanNavigationTenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_ParentMessageID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessage_Messages_MessageID",
                table: "RoomMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessage_SanPham_SanPhamNavigationMaSanPham",
                table: "RoomMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessage_TaiKhoan_TaiKhoanNavigationTenTaiKhoan",
                table: "RoomMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessage",
                table: "RoomMessage");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessage_MessageID",
                table: "RoomMessage");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessage_SanPhamNavigationMaSanPham",
                table: "RoomMessage");

            migrationBuilder.DropIndex(
                name: "IX_RoomMessage_TaiKhoanNavigationTenTaiKhoan",
                table: "RoomMessage");

            migrationBuilder.DropColumn(
                name: "SanPhamNavigationMaSanPham",
                table: "RoomMessage");

            migrationBuilder.DropColumn(
                name: "TaiKhoanNavigationTenTaiKhoan",
                table: "RoomMessage");

            migrationBuilder.RenameTable(
                name: "RoomMessage",
                newName: "RoomMessages");

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
                name: "MaSP",
                table: "RoomMessages",
                type: "char(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "MaSP", "UserID" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_MaSP",
                table: "RoomMessages",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_UserID",
                table: "RoomMessages",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_ParentMessageID",
                table: "Messages",
                column: "ParentMessageID",
                principalTable: "Messages",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_Messages_MessageID",
                table: "RoomMessages",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_SanPham_MaSP",
                table: "RoomMessages",
                column: "MaSP",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
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
