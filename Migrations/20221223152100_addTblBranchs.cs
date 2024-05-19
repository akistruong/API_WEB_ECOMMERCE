using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblBranchs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    MaChiNhanh = table.Column<string>(type: "char(20)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChiNhanh = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IDAddress = table.Column<int>(type: "int", nullable: true),
                    isDefault = table.Column<bool>(type: "bit", nullable: true),
                    DiaChiNavigationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.MaChiNhanh);
                    table.ForeignKey(
                        name: "FK_Branchs_DiaChis_DiaChiNavigationID",
                        column: x => x.DiaChiNavigationID,
                        principalTable: "DiaChis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_DiaChiNavigationID",
                table: "Branchs",
                column: "DiaChiNavigationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branchs");
        }
    }
}
