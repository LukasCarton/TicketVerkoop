﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Domain.Migrations
{
    [DbContext(typeof(TicketVerkoopDbContext))]
    [Migration("20200410144956_addDataToTeamAndStadiumAndSeason")]
    partial class addDataToTeamAndStadiumAndSeason
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Club Brugge"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Oostende"
                        },
                        new
                        {
                            Id = "3",
                            Name = "RSC Anderlecht"
                        },
                        new
                        {
                            Id = "4",
                            Name = "Zulte Waregem"
                        },
                        new
                        {
                            Id = "5",
                            Name = "Genk"
                        },
                        new
                        {
                            Id = "6",
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
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.HasOne("TicketVerkoop.Domain.Context.Stadium", "Stadium")
                        .WithMany()
                        .HasForeignKey("StadiumId");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Reservation", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("TicketVerkoop.Domain.Context.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId");

                    b.HasOne("TicketVerkoop.Domain.Context.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Section", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Stadium", "Stadium")
                        .WithMany()
                        .HasForeignKey("StadiumId");
                });

            modelBuilder.Entity("TicketVerkoop.Domain.Context.Subscription", b =>
                {
                    b.HasOne("TicketVerkoop.Domain.Context.Customer")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId");

                    b.HasOne("TicketVerkoop.Domain.Context.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.HasOne("TicketVerkoop.Domain.Context.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.HasOne("TicketVerkoop.Domain.Context.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}