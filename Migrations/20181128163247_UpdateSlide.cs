using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTheCao.Migrations
{
    public partial class UpdateSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChoose",
                table: "Slides");

            migrationBuilder.RenameColumn(
                name: "Authors",
                table: "Slides",
                newName: "Captant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Captant",
                table: "Slides",
                newName: "Authors");

            migrationBuilder.AddColumn<bool>(
                name: "IsChoose",
                table: "Slides",
                nullable: false,
                defaultValue: false);
        }
    }
}
