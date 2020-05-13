using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addOneMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamId", "BasePriceTicket", "HomeTeamId", "MatchDate", "SeasonId" },
                values: new object[] { "19", "2", 15.0, "1", new DateTime(2020, 4, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "1" });

            migrationBuilder.InsertData(
                table: "MatchSections",
                columns: new[] { "Id", "MatchId", "OccupiedReservationSeats", "SectionId" },
                values: new object[,]
                {
                    { "145", "19", 0, "1" },
                    { "146", "19", 0, "2" },
                    { "147", "19", 0, "3" },
                    { "148", "19", 0, "4" },
                    { "149", "19", 0, "5" },
                    { "150", "19", 0, "6" },
                    { "151", "19", 0, "7" },
                    { "152", "19", 0, "8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "145");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "146");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "147");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "148");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "149");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "150");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "151");

            migrationBuilder.DeleteData(
                table: "MatchSections",
                keyColumn: "Id",
                keyValue: "152");

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: "19");
        }
    }
}
