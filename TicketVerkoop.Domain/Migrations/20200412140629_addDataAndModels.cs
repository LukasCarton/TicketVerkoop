using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class addDataAndModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadia",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    OccupiedSubscriptionSeats = table.Column<int>(nullable: false),
                    PriceFactor = table.Column<double>(nullable: false),
                    Ring = table.Column<int>(nullable: false),
                    StadiumId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Stadia_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    BasePriceTicket = table.Column<double>(nullable: false),
                    StadiumId = table.Column<string>(nullable: true),
                    SeasonId = table.Column<string>(nullable: true),
                    HomeTeamId = table.Column<string>(nullable: true),
                    AwayTeamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Stadia_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SeasonId = table.Column<string>(nullable: true),
                    TeamId = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchSections",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OccupiedReservationSeats = table.Column<int>(nullable: false),
                    MatchId = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchSections_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    NumberOfTickets = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    MatchSectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_MatchSections_MatchSectionId",
                        column: x => x.MatchSectionId,
                        principalTable: "MatchSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "Id", "Logo", "Name" },
                values: new object[,]
                {
                    { "1", "/images/Club_Brugge.png", "Club Brugge" },
                    { "2", "/images/Oostende.png", "Oostende" },
                    { "3", "/images/RSC_Anderlecht.png", "RSC Anderlecht" },
                    { "4", "/images/Zulte_Waregem.png", "Zulte Waregem" },
                    { "5", "/images/Genk.png", "Genk" },
                    { "6", "/images/AA_Gent.png", "AA Gent" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamId", "BasePriceTicket", "HomeTeamId", "MatchDate", "SeasonId", "StadiumId" },
                values: new object[,]
                {
                    { "5", "4", 20.0, "6", new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "5" },
                    { "1", "2", 15.0, "1", new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "1" },
                    { "2", "1", 12.0, "3", new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "2" },
                    { "6", "5", 25.0, "2", new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "6" },
                    { "4", "3", 14.0, "4", new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "4" },
                    { "3", "4", 13.0, "2", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "3" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Capacity", "Name", "OccupiedSubscriptionSeats", "PriceFactor", "Ring", "StadiumId" },
                values: new object[,]
                {
                    { "29", 1000, "North", 0, 1.1000000000000001, 1, "4" },
                    { "30", 3000, "East", 0, 1.5, 1, "4" },
                    { "31", 1000, "South", 0, 1.1000000000000001, 1, "4" },
                    { "32", 3000, "West", 0, 1.5, 1, "4" },
                    { "33", 1000, "North", 0, 0.80000000000000004, 0, "5" },
                    { "34", 3000, "East", 0, 1.2, 0, "5" },
                    { "35", 1000, "South", 0, 0.80000000000000004, 0, "5" },
                    { "36", 3000, "West", 0, 1.2, 0, "5" },
                    { "37", 1000, "North", 0, 1.1000000000000001, 1, "5" },
                    { "38", 3000, "East", 0, 1.5, 1, "5" },
                    { "28", 3000, "West", 0, 1.2, 0, "4" },
                    { "41", 1000, "North", 0, 0.80000000000000004, 0, "6" },
                    { "42", 3000, "East", 0, 1.2, 0, "6" },
                    { "43", 1000, "South", 0, 0.80000000000000004, 0, "6" },
                    { "44", 3000, "West", 0, 1.2, 0, "6" },
                    { "45", 1000, "North", 0, 1.1000000000000001, 1, "6" },
                    { "46", 3000, "East", 0, 1.5, 1, "6" },
                    { "47", 1000, "South", 0, 1.1000000000000001, 1, "6" },
                    { "48", 3000, "West", 0, 1.5, 1, "6" },
                    { "39", 1000, "South", 0, 1.1000000000000001, 1, "5" },
                    { "40", 3000, "West", 0, 1.5, 1, "5" },
                    { "27", 1000, "South", 0, 0.80000000000000004, 0, "4" },
                    { "25", 1000, "North", 0, 0.80000000000000004, 0, "4" },
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
                    { "23", 1000, "South", 0, 1.1000000000000001, 1, "3" },
                    { "24", 3000, "West", 0, 1.5, 1, "3" },
                    { "26", 3000, "East", 0, 1.2, 0, "4" },
                    { "1", 1000, "North", 0, 0.80000000000000004, 0, "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchSections_MatchId",
                table: "MatchSections",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchSections_SectionId",
                table: "MatchSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MatchSectionId",
                table: "Reservations",
                column: "MatchSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_StadiumId",
                table: "Sections",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SeasonId",
                table: "Subscriptions",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SectionId",
                table: "Subscriptions",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_TeamId",
                table: "Subscriptions",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "MatchSections");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Stadia");
        }
    }
}
