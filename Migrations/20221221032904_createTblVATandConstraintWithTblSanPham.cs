using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class createTblVATandConstraintWithTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaBan",
                table: "SanPham");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBanLe",
                table: "SoLuongDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBanSi",
                table: "SoLuongDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaNhap",
                table: "SoLuongDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VAT",
                table: "SoLuongDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBanLe",
                table: "SanPham",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBanSi",
                table: "SanPham",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaNhap",
                table: "SanPham",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDVat",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    giaTri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vats", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Vats_IDBrand",
                table: "SanPham",
                column: "IDBrand",
                principalTable: "Vats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Vats_IDBrand",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "Vats");

            migrationBuilder.DropColumn(
                name: "GiaBanLe",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "GiaBanSi",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "GiaNhap",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "SoLuongDetails");

            migrationBuilder.DropColumn(
                name: "GiaBanLe",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "GiaBanSi",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "GiaNhap",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDVat",
                table: "SanPham");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBan",
                table: "SanPham",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
