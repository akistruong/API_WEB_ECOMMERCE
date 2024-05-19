using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintRoomMessageTBLRoomMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.AddColumn<int>(
                name: "MessageID",
                table: "RoomMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "MessageID", "MaSP", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMessages_Messages_MessageID",
                table: "RoomMessages",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMessages_Messages_MessageID",
                table: "RoomMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages");

            migrationBuilder.DropColumn(
                name: "MessageID",
                table: "RoomMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMessages",
                table: "RoomMessages",
                columns: new[] { "ID", "MaSP", "UserID" });
        }
    }
}
