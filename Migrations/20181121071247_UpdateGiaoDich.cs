using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTheCao.Migrations
{
    public partial class UpdateGiaoDich : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flag",
                table: "GiaoDichs");

            migrationBuilder.AlterColumn<int>(
                name: "Content",
                table: "GiaoDichs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "GiaoDichs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "flag",
                table: "GiaoDichs",
                nullable: false,
                defaultValue: false);
        }
    }
}
