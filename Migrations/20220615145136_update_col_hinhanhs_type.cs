using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class update_col_hinhanhs_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "file_name",
                table: "HinhAnh",
                type: "char(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "file_name",
                table: "HinhAnh",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(255)",
                oldNullable: true);
        }
    }
}
