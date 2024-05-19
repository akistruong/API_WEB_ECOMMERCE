using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class removeFKTblPhiNhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_NhaCungCapNavigationID",
                table: "PhieuNhaps");

            migrationBuilder.RenameColumn(
                name: "ThanhToan",
                table: "PhieuNhaps",
                newName: "TienDaThanhToan");

            migrationBuilder.AddColumn<bool>(
                name: "DaThanhToan",
                table: "PhieuNhaps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_NhaCungCapNavigationID",
                table: "PhieuNhaps",
                column: "NhaCungCapNavigationID",
                principalTable: "NhaCungCap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_NhaCungCapNavigationID",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "DaThanhToan",
                table: "PhieuNhaps");

            migrationBuilder.RenameColumn(
                name: "TienDaThanhToan",
                table: "PhieuNhaps",
                newName: "ThanhToan");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_NhaCungCap_NhaCungCapNavigationID",
                table: "PhieuNhaps",
                column: "NhaCungCapNavigationID",
                principalTable: "NhaCungCap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
