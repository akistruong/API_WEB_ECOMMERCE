using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addConstraintTblSoLuongDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoluongTon",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoluongBan",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoluongTon",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "SoluongBan",
                table: "SoLuongDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "0");
        }
    }
}
