using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFiledTblTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gioitinh",
                table: "TaiKhoan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TienThanhToan",
                table: "TaiKhoan",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gioitinh",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "TienThanhToan",
                table: "TaiKhoan");
        }
    }
}
