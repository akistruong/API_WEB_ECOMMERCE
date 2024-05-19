using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateNameFieldDiaChi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_DiaChis_IdDiaChi",
                table: "HoaDon");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "DiaChis",
                newName: "ProvinceID");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_DiaChis_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi",
                principalTable: "DiaChis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_DiaChis_IdDiaChi",
                table: "HoaDon");

            migrationBuilder.RenameColumn(
                name: "ProvinceID",
                table: "DiaChis",
                newName: "Province");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_DiaChis_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi",
                principalTable: "DiaChis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
