using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketVerkoop.Domain.Migrations
{
    public partial class toevoegenData : Migration
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
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    StadiumId = table.Column<string>(nullable: true),
                    SubscriptionPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Stadia_StadiumId",
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
                    { "2", new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3", new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Stadia",
                columns: new[] { "Id", "City", "Country", "Name", "Street", "Zipcode" },
                values: new object[,]
                {
                    { "1", "Brugge", "België", "Jan Breydelstadion", "Olympialaan 74", "8000" },
                    { "2", "Oostende", "België", "Albertparkstadion", "Leopold Van Tyghemlaan 62", "8400" },
                    { "3", "Brussel", "België", "Constant Vanden Stock stadion", "Theo Verbeecklaan 2", "1070" },
                    { "4", "Waregem", "België", "Regenboogstadion", "Zuiderlaan 17", "8790" },
                    { "5", "Genk", "België", "Cristal Arena", "Stadionplein", "3600" },
                    { "6", "Gentbrugge", "België", "Ghelamco Arena", "Bruiloftstraat 42", "9050" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Capacity", "Name", "OccupiedSubscriptionSeats", "PriceFactor", "Ring", "StadiumId" },
                values: new object[,]
                {
                    { "1", 1000, "North", 0, 0.80000000000000004, 0, "1" },
                    { "48", 3000, "West", 0, 1.5, 1, "6" },
                    { "25", 1000, "North", 0, 0.80000000000000004, 0, "4" },
                    { "26", 3000, "East", 0, 1.2, 0, "4" },
                    { "27", 1000, "South", 0, 0.80000000000000004, 0, "4" },
                    { "28", 3000, "West", 0, 1.2, 0, "4" },
                    { "29", 1000, "North", 0, 1.1000000000000001, 1, "4" },
                    { "30", 3000, "East", 0, 1.5, 1, "4" },
                    { "31", 1000, "South", 0, 1.1000000000000001, 1, "4" },
                    { "32", 3000, "West", 0, 1.5, 1, "4" },
                    { "24", 3000, "West", 0, 1.5, 1, "3" },
                    { "45", 1000, "North", 0, 1.1000000000000001, 1, "6" },
                    { "34", 3000, "East", 0, 1.2, 0, "5" },
                    { "35", 1000, "South", 0, 0.80000000000000004, 0, "5" },
                    { "36", 3000, "West", 0, 1.2, 0, "5" },
                    { "37", 1000, "North", 0, 1.1000000000000001, 1, "5" },
                    { "38", 3000, "East", 0, 1.5, 1, "5" },
                    { "39", 1000, "South", 0, 1.1000000000000001, 1, "5" },
                    { "40", 3000, "West", 0, 1.5, 1, "5" },
                    { "44", 3000, "West", 0, 1.2, 0, "6" },
                    { "41", 1000, "North", 0, 0.80000000000000004, 0, "6" },
                    { "33", 1000, "North", 0, 0.80000000000000004, 0, "5" },
                    { "23", 1000, "South", 0, 1.1000000000000001, 1, "3" },
                    { "22", 3000, "East", 0, 1.5, 1, "3" },
                    { "21", 1000, "North", 0, 1.1000000000000001, 1, "3" },
                    { "2", 3000, "East", 0, 1.2, 0, "1" },
                    { "3", 1000, "South", 0, 0.80000000000000004, 0, "1" },
                    { "4", 3000, "West", 0, 1.2, 0, "1" },
                    { "5", 1000, "North", 0, 1.1000000000000001, 1, "1" },
                    { "6", 3000, "East", 0, 1.5, 1, "1" },
                    { "7", 1000, "South", 0, 1.1000000000000001, 1, "1" },
                    { "8", 3000, "West", 0, 1.5, 1, "1" },
                    { "47", 1000, "South", 0, 1.1000000000000001, 1, "6" },
                    { "9", 1000, "North", 0, 0.80000000000000004, 0, "2" },
                    { "10", 3000, "East", 0, 1.2, 0, "2" },
                    { "11", 1000, "South", 0, 0.80000000000000004, 0, "2" },
                    { "12", 3000, "West", 0, 1.2, 0, "2" },
                    { "13", 1000, "North", 0, 1.1000000000000001, 1, "2" },
                    { "14", 3000, "East", 0, 1.5, 1, "2" },
                    { "15", 1000, "South", 0, 1.1000000000000001, 1, "2" },
                    { "16", 3000, "West", 0, 1.5, 1, "2" },
                    { "46", 3000, "East", 0, 1.5, 1, "6" },
                    { "17", 1000, "North", 0, 0.80000000000000004, 0, "3" },
                    { "18", 3000, "East", 0, 1.2, 0, "3" },
                    { "19", 1000, "South", 0, 0.80000000000000004, 0, "3" },
                    { "20", 3000, "West", 0, 1.2, 0, "3" },
                    { "42", 3000, "East", 0, 1.2, 0, "6" },
                    { "43", 1000, "South", 0, 0.80000000000000004, 0, "6" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Logo", "Name", "StadiumId", "SubscriptionPrice" },
                values: new object[,]
                {
                    { "2", "/images/Oostende.png", "Oostende", "3", 200.0 },
                    { "4", "/images/Zulte_Waregem.png", "Zulte Waregem", "4", 250.0 },
                    { "3", "/images/RSC_Anderlecht.png", "RSC Anderlecht", "2", 500.0 },
                    { "1", "/images/Club_Brugge.png", "Club Brugge", "1", 450.0 },
                    { "6", "/images/AA_Gent.png", "AA Gent", "5", 300.0 },
                    { "5", "/images/Genk.png", "Genk", "6", 350.0 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamId", "BasePriceTicket", "HomeTeamId", "MatchDate", "SeasonId", "StadiumId" },
                values: new object[,]
                {
                    { "1", "2", 15.0, "1", new DateTime(2020, 4, 18, 18, 30, 0, 0, DateTimeKind.Unspecified), "1", "1" },
                    { "12", "5", 12.0, "4", new DateTime(2020, 5, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), "1", "4" },
                    { "9", "6", 13.0, "5", new DateTime(2020, 5, 2, 19, 30, 0, 0, DateTimeKind.Unspecified), "1", "5" },
                    { "6", "5", 12.0, "4", new DateTime(2020, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "1", "4" },
                    { "3", "6", 13.0, "5", new DateTime(2020, 4, 18, 18, 30, 0, 0, DateTimeKind.Unspecified), "1", "5" },
                    { "16", "1", 15.0, "6", new DateTime(2020, 5, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), "1", "6" },
                    { "10", "6", 15.0, "6", new DateTime(2020, 5, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), "1", "6" },
                    { "4", "1", 15.0, "6", new DateTime(2020, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "1", "6" },
                    { "14", "4", 12.0, "3", new DateTime(2020, 5, 16, 17, 30, 0, 0, DateTimeKind.Unspecified), "1", "3" },
                    { "8", "4", 12.0, "3", new DateTime(2020, 5, 2, 19, 30, 0, 0, DateTimeKind.Unspecified), "1", "3" },
                    { "2", "4", 12.0, "3", new DateTime(2020, 4, 18, 18, 30, 0, 0, DateTimeKind.Unspecified), "1", "3" },
                    { "17", "3", 12.0, "2", new DateTime(2020, 5, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), "1", "2" },
                    { "13", "2", 15.0, "1", new DateTime(2020, 5, 16, 17, 30, 0, 0, DateTimeKind.Unspecified), "1", "1" },
                    { "11", "3", 12.0, "2", new DateTime(2020, 5, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), "1", "2" },
                    { "7", "2", 15.0, "1", new DateTime(2020, 5, 2, 19, 30, 0, 0, DateTimeKind.Unspecified), "1", "1" },
                    { "5", "3", 12.0, "2", new DateTime(2020, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "1", "2" },
                    { "15", "6", 13.0, "5", new DateTime(2020, 5, 16, 17, 30, 0, 0, DateTimeKind.Unspecified), "1", "5" },
                    { "18", "5", 12.0, "4", new DateTime(2020, 5, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), "1", "4" }
                });

            migrationBuilder.InsertData(
                table: "MatchSections",
                columns: new[] { "Id", "MatchId", "OccupiedReservationSeats", "SectionId" },
                values: new object[,]
                {
                    { "1", "1", 0, "1" },
                    { "125", "16", 0, "45" },
                    { "126", "16", 0, "46" },
                    { "127", "16", 0, "17" },
                    { "128", "16", 0, "48" },
                    { "17", "3", 0, "33" },
                    { "18", "3", 0, "34" },
                    { "124", "16", 0, "44" },
                    { "19", "3", 0, "35" },
                    { "21", "3", 0, "37" },
                    { "22", "3", 0, "38" },
                    { "23", "3", 0, "39" },
                    { "24", "3", 0, "40" },
                    { "41", "6", 0, "25" },
                    { "42", "6", 0, "26" },
                    { "20", "3", 0, "36" },
                    { "43", "6", 0, "27" },
                    { "123", "16", 0, "43" },
                    { "121", "16", 0, "41" },
                    { "27", "4", 0, "43" },
                    { "28", "4", 0, "44" },
                    { "29", "4", 0, "45" },
                    { "30", "4", 0, "46" },
                    { "31", "4", 0, "17" },
                    { "32", "4", 0, "48" },
                    { "122", "16", 0, "42" },
                    { "73", "10", 0, "41" },
                    { "75", "10", 0, "43" },
                    { "76", "10", 0, "44" },
                    { "77", "10", 0, "45" },
                    { "78", "10", 0, "46" },
                    { "79", "10", 0, "17" },
                    { "80", "10", 0, "48" },
                    { "74", "10", 0, "42" },
                    { "26", "4", 0, "42" },
                    { "44", "6", 0, "28" },
                    { "46", "6", 0, "30" },
                    { "113", "15", 0, "33" },
                    { "114", "15", 0, "34" },
                    { "115", "15", 0, "35" },
                    { "116", "15", 0, "36" },
                    { "117", "15", 0, "37" },
                    { "118", "15", 0, "38" },
                    { "96", "12", 0, "32" },
                    { "119", "15", 0, "39" },
                    { "137", "18", 0, "25" },
                    { "138", "18", 0, "26" },
                    { "139", "18", 0, "27" },
                    { "140", "18", 0, "28" },
                    { "141", "18", 0, "29" },
                    { "142", "18", 0, "30" },
                    { "120", "15", 0, "40" },
                    { "45", "6", 0, "29" },
                    { "95", "12", 0, "31" },
                    { "93", "12", 0, "29" },
                    { "47", "6", 0, "31" },
                    { "48", "6", 0, "32" },
                    { "65", "9", 0, "33" },
                    { "66", "9", 0, "34" },
                    { "67", "9", 0, "35" },
                    { "68", "9", 0, "36" },
                    { "94", "12", 0, "30" },
                    { "69", "9", 0, "37" },
                    { "71", "9", 0, "39" },
                    { "72", "9", 0, "40" },
                    { "89", "12", 0, "25" },
                    { "90", "12", 0, "26" },
                    { "91", "12", 0, "27" },
                    { "92", "12", 0, "28" },
                    { "70", "9", 0, "38" },
                    { "25", "4", 0, "41" },
                    { "112", "14", 0, "24" },
                    { "111", "14", 0, "23" },
                    { "52", "7", 0, "4" },
                    { "53", "7", 0, "5" },
                    { "54", "7", 0, "6" },
                    { "55", "7", 0, "7" },
                    { "56", "7", 0, "8" },
                    { "81", "11", 0, "9" },
                    { "51", "7", 0, "3" },
                    { "82", "11", 0, "10" },
                    { "84", "11", 0, "12" },
                    { "85", "11", 0, "13" },
                    { "86", "11", 0, "14" },
                    { "87", "11", 0, "15" },
                    { "88", "11", 0, "16" },
                    { "97", "13", 0, "1" },
                    { "83", "11", 0, "11" },
                    { "98", "13", 0, "2" },
                    { "50", "7", 0, "2" },
                    { "40", "5", 0, "16" },
                    { "2", "1", 0, "2" },
                    { "3", "1", 0, "3" },
                    { "4", "1", 0, "4" },
                    { "5", "1", 0, "5" },
                    { "6", "1", 0, "6" },
                    { "7", "1", 0, "7" },
                    { "49", "7", 0, "1" },
                    { "8", "1", 0, "8" },
                    { "34", "5", 0, "10" },
                    { "35", "5", 0, "11" },
                    { "36", "5", 0, "12" },
                    { "37", "5", 0, "13" },
                    { "38", "5", 0, "14" },
                    { "39", "5", 0, "15" },
                    { "33", "5", 0, "9" },
                    { "99", "13", 0, "3" },
                    { "100", "13", 0, "4" },
                    { "101", "13", 0, "5" },
                    { "57", "8", 0, "17" },
                    { "58", "8", 0, "18" },
                    { "59", "8", 0, "19" },
                    { "60", "8", 0, "20" },
                    { "61", "8", 0, "21" },
                    { "62", "8", 0, "22" },
                    { "16", "2", 0, "24" },
                    { "63", "8", 0, "23" },
                    { "105", "14", 0, "17" },
                    { "106", "14", 0, "18" },
                    { "107", "14", 0, "19" },
                    { "108", "14", 0, "20" },
                    { "109", "14", 0, "21" },
                    { "110", "14", 0, "22" },
                    { "64", "8", 0, "24" },
                    { "15", "2", 0, "23" },
                    { "14", "2", 0, "22" },
                    { "13", "2", 0, "21" },
                    { "102", "13", 0, "6" },
                    { "103", "13", 0, "7" },
                    { "104", "13", 0, "8" },
                    { "129", "17", 0, "9" },
                    { "130", "17", 0, "10" },
                    { "131", "17", 0, "11" },
                    { "132", "17", 0, "12" },
                    { "133", "17", 0, "13" },
                    { "134", "17", 0, "14" },
                    { "135", "17", 0, "15" },
                    { "136", "17", 0, "16" },
                    { "9", "2", 0, "17" },
                    { "10", "2", 0, "18" },
                    { "11", "2", 0, "19" },
                    { "12", "2", 0, "20" },
                    { "143", "18", 0, "31" },
                    { "144", "18", 0, "32" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");
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
