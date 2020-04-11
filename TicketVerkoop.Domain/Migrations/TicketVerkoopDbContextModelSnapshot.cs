﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Domain.Migrations
{
    [DbContext(typeof(TicketVerkoopDbContext))]
    partial class TicketVerkoopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Street");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Match", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AwayTeamId");

                    b.Property<double>("BasePriceTicket");

                    b.Property<string>("HomeTeamId");

                    b.Property<DateTime>("MatchDate");

                    b.Property<string>("SeasonId");

                    b.Property<string>("StadiumId");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AwayTeamId = "2",
                            BasePriceTicket = 15.0,
                            HomeTeamId = "1",
                            MatchDate = new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "1",
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "2",
                            AwayTeamId = "1",
                            BasePriceTicket = 12.0,
                            HomeTeamId = "3",
                            MatchDate = new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "1",
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "3",
                            AwayTeamId = "4",
                            BasePriceTicket = 13.0,
                            HomeTeamId = "2",
                            MatchDate = new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "2",
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "4",
                            AwayTeamId = "3",
                            BasePriceTicket = 14.0,
                            HomeTeamId = "4",
                            MatchDate = new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "1",
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "5",
                            AwayTeamId = "4",
                            BasePriceTicket = 20.0,
                            HomeTeamId = "6",
                            MatchDate = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "2",
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "6",
                            AwayTeamId = "5",
                            BasePriceTicket = 25.0,
                            HomeTeamId = "2",
                            MatchDate = new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "1",
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "7",
                            AwayTeamId = "3",
                            BasePriceTicket = 30.0,
                            HomeTeamId = "1",
                            MatchDate = new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "1",
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "8",
                            AwayTeamId = "1",
                            BasePriceTicket = 21.0,
                            HomeTeamId = "3",
                            MatchDate = new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "1",
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "9",
                            AwayTeamId = "3",
                            BasePriceTicket = 14.0,
                            HomeTeamId = "2",
                            MatchDate = new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "2",
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "10",
                            AwayTeamId = "3",
                            BasePriceTicket = 12.0,
                            HomeTeamId = "4",
                            MatchDate = new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = "2",
                            StadiumId = "4"
                        });
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<string>("MatchId");

                    b.Property<int>("NumberOfTickets");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<string>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MatchId");

                    b.HasIndex("SectionId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Season", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Seasons");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            EndDate = new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "2",
                            EndDate = new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Section", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Name");

                    b.Property<int>("OccupiedSeats");

                    b.Property<double>("PriceFactor");

                    b.Property<int>("Ring");

                    b.Property<string>("StadiumId");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "2",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "3",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "4",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "5",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "6",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "7",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "8",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "1"
                        },
                        new
                        {
                            Id = "9",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "10",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "11",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "12",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "13",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "14",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "15",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "16",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "2"
                        },
                        new
                        {
                            Id = "17",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "18",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "19",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "20",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "21",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "22",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "23",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "24",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "3"
                        },
                        new
                        {
                            Id = "25",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "26",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "27",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "28",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "29",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "30",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "31",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "32",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "4"
                        },
                        new
                        {
                            Id = "33",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "34",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "35",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "36",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "37",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "38",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "39",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "40",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "5"
                        },
                        new
                        {
                            Id = "41",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "42",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "43",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 0.80000000000000004,
                            Ring = 0,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "44",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.2,
                            Ring = 0,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "45",
                            Capacity = 1000,
                            Name = "North",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "46",
                            Capacity = 3000,
                            Name = "East",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "47",
                            Capacity = 1000,
                            Name = "South",
                            OccupiedSeats = 0,
                            PriceFactor = 1.1000000000000001,
                            Ring = 1,
                            StadiumId = "6"
                        },
                        new
                        {
                            Id = "48",
                            Capacity = 3000,
                            Name = "West",
                            OccupiedSeats = 0,
                            PriceFactor = 1.5,
                            Ring = 1,
                            StadiumId = "6"
                        });
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Stadium", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("Street");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.ToTable("Stadia");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            City = "Brugge",
                            Country = "België",
                            Name = "Jan Breydelstadion",
                            Street = "Olympialaan 74",
                            Zipcode = "8000"
                        },
                        new
                        {
                            Id = "2",
                            City = "Brussel",
                            Country = "België",
                            Name = "Constant Vanden Stock stadion",
                            Street = "Theo Verbeecklaan 2",
                            Zipcode = "1070"
                        },
                        new
                        {
                            Id = "3",
                            City = "Oostende",
                            Country = "België",
                            Name = "Albertparkstadion",
                            Street = "Leopold Van Tyghemlaan 62",
                            Zipcode = "8400"
                        },
                        new
                        {
                            Id = "4",
                            City = "Waregem",
                            Country = "België",
                            Name = "Regenboogstadion",
                            Street = "Zuiderlaan 17",
                            Zipcode = "8790"
                        },
                        new
                        {
                            Id = "5",
                            City = "Gentbrugge",
                            Country = "België",
                            Name = "Ghelamco Arena",
                            Street = "Bruiloftstraat 42",
                            Zipcode = "9050"
                        },
                        new
                        {
                            Id = "6",
                            City = "Genk",
                            Country = "België",
                            Name = "Cristal Arena",
                            Street = "Stadionplein",
                            Zipcode = "3600"
                        });
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Subscription", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<string>("SeasonId");

                    b.Property<string>("SectionId");

                    b.Property<string>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("SectionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Logo = "/images/Club_Brugge.png",
                            Name = "Club Brugge"
                        },
                        new
                        {
                            Id = "2",
                            Logo = "/images/Oostende.png",
                            Name = "Oostende"
                        },
                        new
                        {
                            Id = "3",
                            Logo = "/images/RSC_Anderlecht.png",
                            Name = "RSC Anderlecht"
                        },
                        new
                        {
                            Id = "4",
                            Logo = "/images/Zulte_Waregem.png",
                            Name = "Zulte Waregem"
                        },
                        new
                        {
                            Id = "5",
                            Logo = "/images/Genk.png",
                            Name = "Genk"
                        },
                        new
                        {
                            Id = "6",
                            Logo = "/images/AA_Gent.png",
                            Name = "AA Gent"
                        });
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Match", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("TicketVerkoop.Domain.Context.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");

                    b.HasOne("TicketVerkoop.Domain.Context.Season", "Season")
                        .WithMany("Matches")
                        .HasForeignKey("SeasonId");

                    b.HasOne("TicketVerkoop.Domain.Context.Stadium", "Stadium")
                        .WithMany("Matches")
                        .HasForeignKey("StadiumId");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Reservation", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.HasOne("TicketVerkoop.Domain.Context.Match", "Match")
                        .WithMany("Reservations")
                        .HasForeignKey("MatchId");

                    b.HasOne("TicketVerkoop.Domain.Context.Section", "Section")
                        .WithMany("Reservations")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Section", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Stadium", "Stadium")
                        .WithMany("Sections")
                        .HasForeignKey("StadiumId");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Subscription", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Customer", "Customer")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId");

                    b.HasOne("TicketVerkoop.Domain.Context.Season", "Season")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SeasonId");

                    b.HasOne("TicketVerkoop.Domain.Context.Section", "Section")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SectionId");

                    b.HasOne("TicketVerkoop.Domain.Context.Team", "Team")
                        .WithMany("Subscriptions")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
