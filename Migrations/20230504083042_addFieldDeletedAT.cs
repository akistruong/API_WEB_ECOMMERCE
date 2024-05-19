using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addFieldDeletedAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAT",
                table: "PhieuNhapXuats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAT",
                table: "ChiTietNhapXuats",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deletedAT",
                table: "PhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "deletedAT",
                table: "ChiTietNhapXuats");
        }
    }
}
