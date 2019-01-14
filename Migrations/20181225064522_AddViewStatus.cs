using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTheCao.Migrations
{
    public partial class AddViewStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ViewStatus",
                table: "NopCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewStatus",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewStatus",
                table: "NopCards");

            migrationBuilder.DropColumn(
                name: "ViewStatus",
                table: "AspNetUsers");
        }
    }
}
