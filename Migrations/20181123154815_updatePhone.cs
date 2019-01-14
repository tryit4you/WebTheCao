using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTheCao.Migrations
{
    public partial class updatePhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sdt",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sdt",
                table: "AspNetUsers");
        }
    }
}
