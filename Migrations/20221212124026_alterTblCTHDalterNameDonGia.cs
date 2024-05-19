using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class alterTblCTHDalterNameDonGia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonGia",
                table: "ChiTietHoaDon",
                newName: "giaBan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "giaBan",
                table: "ChiTietHoaDon",
                newName: "DonGia");
        }
    }
}
