using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayManagement.DataAccess.Migrations
{
    public partial class HolidayApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "HolidayApplications");

            migrationBuilder.AddColumn<string>(
                name: "Reasons",
                table: "HolidayApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "HolidayApplications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reasons",
                table: "HolidayApplications");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "HolidayApplications");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "HolidayApplications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
