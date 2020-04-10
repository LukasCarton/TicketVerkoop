using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addCollectionsInDomainModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_AwayTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_HomeTeamId",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "AwayTeam",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TeamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwayTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwayTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeTeam",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TeamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwayTeam_TeamId",
                table: "AwayTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTeam_TeamId",
                table: "HomeTeam",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AwayTeam_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId",
                principalTable: "AwayTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_HomeTeam_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId",
                principalTable: "HomeTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AwayTeam_AwayTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_HomeTeam_HomeTeamId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "AwayTeam");

            migrationBuilder.DropTable(
                name: "HomeTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
