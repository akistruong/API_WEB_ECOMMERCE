using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class AddFieldIDTypeandIDbrandTblSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDBrand",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDType",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDBrand",
                table: "SanPham",
                column: "IDBrand");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDType",
                table: "SanPham",
                column: "IDType");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Brands_IDBrand",
                table: "SanPham",
                column: "IDBrand",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Types_IDType",
                table: "SanPham",
                column: "IDType",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Brands_IDBrand",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Types_IDType",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IDBrand",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_IDType",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDBrand",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDType",
                table: "SanPham");
        }
    }
}
