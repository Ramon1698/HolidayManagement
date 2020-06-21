using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayManagement.DataAccess.Migrations
{
    public partial class HolidayDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableHoldayDays",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ConsumedHolidayDays",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumedHolidayDays",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "AvailableHoldayDays",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
