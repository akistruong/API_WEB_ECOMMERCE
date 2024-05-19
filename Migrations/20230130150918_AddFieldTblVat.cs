using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class AddFieldTblVat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "giaTri",
                table: "Vats",
                newName: "giaTriThueDauVao");

            migrationBuilder.AddColumn<int>(
                name: "giaTriThueDauRa",
                table: "Vats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "giaTriThueDauRa",
                table: "Vats");

            migrationBuilder.RenameColumn(
                name: "giaTriThueDauVao",
                table: "Vats",
                newName: "giaTri");
        }
    }
}
