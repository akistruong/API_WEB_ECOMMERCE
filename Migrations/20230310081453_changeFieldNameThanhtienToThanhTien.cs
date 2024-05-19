using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class changeFieldNameThanhtienToThanhTien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thanhtien",
                table: "PhieuNhapXuats",
                newName: "ThanhTien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThanhTien",
                table: "PhieuNhapXuats",
                newName: "Thanhtien");
        }
    }
}
