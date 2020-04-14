using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addStadiumTeamsConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StadiumId",
                table: "Teams",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[] { "3", new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "1",
                column: "StadiumId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "2",
                column: "StadiumId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "3",
                column: "StadiumId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "4",
                column: "StadiumId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "5",
                column: "StadiumId",
                value: "6");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "6",
                column: "StadiumId",
                value: "5");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadia_StadiumId",
                table: "Teams",
                column: "StadiumId",
                principalTable: "Stadia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadia_StadiumId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams");

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DropColumn(
                name: "StadiumId",
                table: "Teams");
        }
    }
}
