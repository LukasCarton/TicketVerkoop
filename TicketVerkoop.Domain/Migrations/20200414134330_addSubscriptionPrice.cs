using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addSubscriptionPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SubscriptionPrice",
                table: "Teams",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "1",
                column: "SubscriptionPrice",
                value: 450.0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "2",
                column: "SubscriptionPrice",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "3",
                column: "SubscriptionPrice",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "4",
                column: "SubscriptionPrice",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "5",
                column: "SubscriptionPrice",
                value: 350.0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "6",
                column: "SubscriptionPrice",
                value: 300.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionPrice",
                table: "Teams");
        }
    }
}
