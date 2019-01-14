using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTheCao.Migrations
{
    public partial class addTKNH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiKhoanNganHangs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TenNH = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    SoTK = table.Column<string>(nullable: true),
                    NguoiThuHuong = table.Column<string>(nullable: true),
                    TenChiNhanh = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanNganHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoanNganHangs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanNganHangs_UserId",
                table: "TaiKhoanNganHangs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiKhoanNganHangs");
        }
    }
}
