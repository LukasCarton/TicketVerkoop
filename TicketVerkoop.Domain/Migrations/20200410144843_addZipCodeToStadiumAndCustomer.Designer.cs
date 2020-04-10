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
    [Migration("20200410144843_addZipCodeToStadiumAndCustomer")]
    partial class addZipCodeToStadiumAndCustomer
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
