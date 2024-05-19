using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class initLoaiPhieus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LoaiPhieu",
                columns: new[] { "MaPhieu", "MoTa", "TenPhieu" },
                values: new object[,]
                {
                    { "PHIEUNHAP", null, null },
                    { "PHIEUXUAT", null, null },
                    { "PHIEUTHU", null, null },
                    { "PHIEUCHI", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoaiPhieu",
                keyColumn: "MaPhieu",
                keyValue: "PHIEUCHI");

            migrationBuilder.DeleteData(
                table: "LoaiPhieu",
                keyColumn: "MaPhieu",
                keyValue: "PHIEUNHAP");

            migrationBuilder.DeleteData(
                table: "LoaiPhieu",
                keyColumn: "MaPhieu",
                keyValue: "PHIEUTHU");

            migrationBuilder.DeleteData(
                table: "LoaiPhieu",
                keyColumn: "MaPhieu",
                keyValue: "PHIEUXUAT");
        }
    }
}
