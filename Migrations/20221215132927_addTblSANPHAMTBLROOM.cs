using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblSANPHAMTBLROOM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creatorID = table.Column<string>(type: "char(20)", nullable: true),
                    ParentMessageID = table.Column<int>(type: "int", nullable: false),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Messages_ParentMessageID",
                        column: x => x.ParentMessageID,
                        principalTable: "Messages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Messages_TaiKhoan_creatorID",
                        column: x => x.creatorID,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomMessages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<string>(type: "char(10)", nullable: false),
                    UserID = table.Column<string>(type: "char(20)", nullable: false),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMessages", x => new { x.ID, x.MaSP, x.UserID });
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "RoomMessages");
        }
    }
}
