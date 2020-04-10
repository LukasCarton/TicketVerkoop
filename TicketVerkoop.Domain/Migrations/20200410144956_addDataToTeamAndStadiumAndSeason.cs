using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addDataToTeamAndStadiumAndSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { "1", new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2", new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Stadia",
                columns: new[] { "Id", "City", "Country", "Name", "Street", "Zipcode" },
                values: new object[,]
                {
                    { "1", "Brugge", "België", "Jan Breydelstadion", "Olympialaan 74", "8000" },
                    { "2", "Brussel", "België", "Constant Vanden Stock stadion", "Theo Verbeecklaan 2", "1070" },
                    { "3", "Oostende", "België", "Albertparkstadion", "Leopold Van Tyghemlaan 62", "8400" },
                    { "4", "Waregem", "België", "Regenboogstadion", "Zuiderlaan 17", "8790" },
                    { "5", "Gentbrugge", "België", "Ghelamco Arena", "Bruiloftstraat 42", "9050" },
                    { "6", "Genk", "België", "Cristal Arena", "Stadionplein", "3600" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Club Brugge" },
                    { "2", "Oostende" },
                    { "3", "RSC Anderlecht" },
                    { "4", "Zulte Waregem" },
                    { "5", "Genk" },
                    { "6", "AA Gent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Stadia",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Stadia",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Stadia",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Stadia",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Stadia",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Stadia",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "6");
        }
    }
}
