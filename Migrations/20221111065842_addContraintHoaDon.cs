using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addContraintHoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDiaChi",
                table: "HoaDon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi",
                unique: true,
                filter: "[IdDiaChi] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_DiaChis_IdDiaChi",
                table: "HoaDon",
                column: "IdDiaChi",
                principalTable: "DiaChis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_DiaChis_IdDiaChi",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_IdDiaChi",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "IdDiaChi",
                table: "HoaDon");
        }
    }
}
