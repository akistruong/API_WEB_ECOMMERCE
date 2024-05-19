using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class setNullFieldIdSizeTblCTSL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoluongBan",
                table: "SoLuongDetails");

            migrationBuilder.AlterColumn<int>(
                name: "_idSize",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "_idSize",
                table: "SoLuongDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoluongBan",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                defaultValueSql: "0");
        }
    }
}
