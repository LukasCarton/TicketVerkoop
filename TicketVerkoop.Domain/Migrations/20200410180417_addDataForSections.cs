using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addDataForSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "1",
                column: "PriceFactor",
                value: 0.80000000000000004);

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Capacity", "Name", "OccupiedSeats", "PriceFactor", "Ring", "StadiumId" },
                values: new object[,]
                {
                    { "27", 1000, "South", 0, 0.80000000000000004, 0, "4" },
                    { "28", 3000, "West", 0, 1.2, 0, "4" },
                    { "29", 1000, "North", 0, 1.1000000000000001, 1, "4" },
                    { "30", 3000, "East", 0, 1.5, 1, "4" },
                    { "31", 1000, "South", 0, 1.1000000000000001, 1, "4" },
                    { "32", 3000, "West", 0, 1.5, 1, "4" },
                    { "33", 1000, "North", 0, 0.80000000000000004, 0, "5" },
                    { "34", 3000, "East", 0, 1.2, 0, "5" },
                    { "35", 1000, "South", 0, 0.80000000000000004, 0, "5" },
                    { "26", 3000, "East", 0, 1.2, 0, "4" },
                    { "36", 3000, "West", 0, 1.2, 0, "5" },
                    { "38", 3000, "East", 0, 1.5, 1, "5" },
                    { "39", 1000, "South", 0, 1.1000000000000001, 1, "5" },
                    { "40", 3000, "West", 0, 1.5, 1, "5" },
                    { "41", 1000, "North", 0, 0.80000000000000004, 0, "6" },
                    { "42", 3000, "East", 0, 1.2, 0, "6" },
                    { "43", 1000, "South", 0, 0.80000000000000004, 0, "6" },
                    { "44", 3000, "West", 0, 1.2, 0, "6" },
                    { "45", 1000, "North", 0, 1.1000000000000001, 1, "6" },
                    { "46", 3000, "East", 0, 1.5, 1, "6" },
                    { "37", 1000, "North", 0, 1.1000000000000001, 1, "5" },
                    { "25", 1000, "North", 0, 0.80000000000000004, 0, "4" },
                    { "24", 3000, "West", 0, 1.5, 1, "3" },
                    { "23", 1000, "South", 0, 1.1000000000000001, 1, "3" },
                    { "2", 3000, "East", 0, 1.2, 0, "1" },
                    { "3", 1000, "South", 0, 0.80000000000000004, 0, "1" },
                    { "4", 3000, "West", 0, 1.2, 0, "1" },
                    { "5", 1000, "North", 0, 1.1000000000000001, 1, "1" },
                    { "6", 3000, "East", 0, 1.5, 1, "1" },
                    { "7", 1000, "South", 0, 1.1000000000000001, 1, "1" },
                    { "8", 3000, "West", 0, 1.5, 1, "1" },
                    { "9", 1000, "North", 0, 0.80000000000000004, 0, "2" },
                    { "10", 3000, "East", 0, 1.2, 0, "2" },
                    { "11", 1000, "South", 0, 0.80000000000000004, 0, "2" },
                    { "12", 3000, "West", 0, 1.2, 0, "2" },
                    { "13", 1000, "North", 0, 1.1000000000000001, 1, "2" },
                    { "14", 3000, "East", 0, 1.5, 1, "2" },
                    { "15", 1000, "South", 0, 1.1000000000000001, 1, "2" },
                    { "16", 3000, "West", 0, 1.5, 1, "2" },
                    { "17", 1000, "North", 0, 0.80000000000000004, 0, "3" },
                    { "18", 3000, "East", 0, 1.2, 0, "3" },
                    { "19", 1000, "South", 0, 0.80000000000000004, 0, "3" },
                    { "20", 3000, "West", 0, 1.2, 0, "3" },
                    { "21", 1000, "North", 0, 1.1000000000000001, 1, "3" },
                    { "22", 3000, "East", 0, 1.5, 1, "3" },
                    { "47", 1000, "South", 0, 1.1000000000000001, 1, "6" },
                    { "48", 3000, "West", 0, 1.5, 1, "6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "16");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "21");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "23");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "24");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "26");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "27");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "28");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "29");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "30");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "31");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "32");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "33");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "34");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "35");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "36");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "37");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "38");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "39");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "40");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "41");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "42");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "43");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "44");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "45");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "46");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "47");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "48");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: "1",
                column: "PriceFactor",
                value: 1.0);
        }
    }
}
