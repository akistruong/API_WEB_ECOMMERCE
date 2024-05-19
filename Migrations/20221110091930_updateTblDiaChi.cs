using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class updateTblDiaChi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenTaiKhoan",
                table: "DiaChis",
                type: "char(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiaChis_TenTaiKhoan",
                table: "DiaChis",
                column: "TenTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_TaiKhoan_TenTaiKhoan",
                table: "DiaChis",
                column: "TenTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "TenTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaChis_TaiKhoan_TenTaiKhoan",
                table: "DiaChis");

            migrationBuilder.DropIndex(
                name: "IX_DiaChis_TenTaiKhoan",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "TenTaiKhoan",
                table: "DiaChis");
        }
    }
}
