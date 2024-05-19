using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldImgXImgYTblChiTietCoupons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "img",
                table: "ChiTietCoupons",
                newName: "imgY");

            migrationBuilder.AddColumn<string>(
                name: "imgX",
                table: "ChiTietCoupons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgX",
                table: "ChiTietCoupons");

            migrationBuilder.RenameColumn(
                name: "imgY",
                table: "ChiTietCoupons",
                newName: "img");
        }
    }
}
