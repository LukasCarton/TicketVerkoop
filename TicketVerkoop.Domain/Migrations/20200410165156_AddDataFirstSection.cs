using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class AddDataFirstSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Capacity", "Name", "OccupiedSeats", "PriceFactor", "Ring", "StadiumId" },
                values: new object[] { "1", 1000, "North", 0, 1.0, 0, "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
