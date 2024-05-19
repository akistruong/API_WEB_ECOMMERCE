using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateTBLMessageandRoomMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_MessageNavigationID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_TaiKhoan_userNavigationTenTaiKhoan",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageNavigationID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_userNavigationTenTaiKhoan",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageNavigationID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "userNavigationTenTaiKhoan",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "creatorID",
                table: "Messages",
                type: "char(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RoomMessages",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "char(10)", nullable: false),
                    UserID = table.Column<string>(type: "char(20)", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMessages", x => new { x.MessageID, x.MaSP, x.UserID });
                    table.ForeignKey(
                        name: "FK_RoomMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomMessages_SanPham_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomMessages_TaiKhoan_UserID",
                        column: x => x.UserID,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_creatorID",
                table: "Messages",
                column: "creatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ParentMessageID",
                table: "Messages",
                column: "ParentMessageID");

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
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_TaiKhoan_creatorID",
                table: "Messages",
                column: "creatorID",
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
                name: "FK_Messages_TaiKhoan_creatorID",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "RoomMessages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_creatorID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ParentMessageID",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "creatorID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageNavigationID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userNavigationTenTaiKhoan",
                table: "Messages",
                type: "char(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageNavigationID",
                table: "Messages",
                column: "MessageNavigationID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_userNavigationTenTaiKhoan",
                table: "Messages",
                column: "userNavigationTenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_MessageNavigationID",
                table: "Messages",
                column: "MessageNavigationID",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_TaiKhoan_userNavigationTenTaiKhoan",
                table: "Messages",
                column: "userNavigationTenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
