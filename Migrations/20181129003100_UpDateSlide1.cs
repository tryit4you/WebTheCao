using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTheCao.Migrations
{
    public partial class UpDateSlide1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaptantPostion",
                table: "Slides",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaptantPostion",
                table: "Slides");
        }
    }
}
