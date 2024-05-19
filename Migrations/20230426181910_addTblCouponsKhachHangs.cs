using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DSCS2_WEBBANGIAY.Migrations
{
    public partial class addTblCouponsKhachHangs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoaiSanPham",
                table: "ChiTietCoupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coupons_KhachHangs",
                columns: table => new
                {
                    MaCoupon = table.Column<string>(type: "char(15)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "char(50)", nullable: false),
                    LoaiSanPham = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons_KhachHangs", x => new { x.MaCoupon, x.TenTaiKhoan });
                    table.ForeignKey(
                        name: "FK_Coupons_KhachHangs_Coupons_MaCoupon",
                        column: x => x.MaCoupon,
                        principalTable: "Coupons",
                        principalColumn: "MaCoupon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coupons_KhachHangs_TaiKhoan_TenTaiKhoan",
                        column: x => x.TenTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_KhachHangs_TenTaiKhoan",
                table: "Coupons_KhachHangs",
                column: "TenTaiKhoan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons_KhachHangs");

            migrationBuilder.DropColumn(
                name: "LoaiSanPham",
                table: "ChiTietCoupons");
        }
    }
}
