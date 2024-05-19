using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeTblRoomMessages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomMessage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomMessage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageID = table.Column<int>(type: "int", nullable: false),
                    SanPhamNavigationMaSanPham = table.Column<string>(type: "char(10)", nullable: true),
                    TaiKhoanNavigationTenTaiKhoan = table.Column<string>(type: "char(20)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomMessage_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomMessage_SanPham_SanPhamNavigationMaSanPham",
                        column: x => x.SanPhamNavigationMaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomMessage_TaiKhoan_TaiKhoanNavigationTenTaiKhoan",
                        column: x => x.TaiKhoanNavigationTenTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }
    }
}
