using Microsoft.EntityFrameworkCore.Migrations;

namespace InstaHub_MVC.Migrations
{
    public partial class sean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
