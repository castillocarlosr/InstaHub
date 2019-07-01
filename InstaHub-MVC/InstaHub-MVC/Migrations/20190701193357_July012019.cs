using Microsoft.EntityFrameworkCore.Migrations;

namespace InstaHub_MVC.Migrations
{
    public partial class July012019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "GroupType", "Name" },
                values: new object[] { 1, 1, "Code-R-Us" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "GroupType", "Name" },
                values: new object[] { 2, 1, "Public Code" });
        }
    }
}
