using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class alterColumnTypeSDT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_id_KH",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "TaiKhoan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "SdtKH",
                table: "HoaDon",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_SdtKH",
                table: "HoaDon",
                column: "SdtKH");

            migrationBuilder.AddForeignKey(
                name: "fk_HD_KH",
                table: "HoaDon",
                column: "SdtKH",
                principalTable: "KhachHang",
                principalColumn: "Sdt",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_HD_KH",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_SdtKH",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "SdtKH",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "TaiKhoan",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_id_KH",
                table: "HoaDon",
                type: "int",
                nullable: true);
        }
    }
}
