using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class TicketVerkoopDbContext : DbContext
    {
        public TicketVerkoopDbContext()
        {

        }

        public TicketVerkoopDbContext(DbContextOptions<TicketVerkoopDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Stadium> Stadia { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchSection> MatchSections { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQL_VIVES;Database=TicketVerkoop;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        // Add Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var team1 = new Team { Id = "1", Name = "Club Brugge", Logo = "/images/Club_Brugge.png", StadiumId = "1", SubscriptionPrice = 450 };  //1 - 1
            var team2 = new Team { Id = "2", Name = "Oostende", Logo = "/images/Oostende.png", StadiumId = "2", SubscriptionPrice = 200 };  //2 - 3
            var team3 = new Team { Id = "3", Name = "RSC Anderlecht", Logo = "/images/RSC_Anderlecht.png", StadiumId = "3", SubscriptionPrice = 500 }; // 3 - 2
            var team4 = new Team { Id = "4", Name = "Zulte Waregem", Logo = "/images/Zulte_Waregem.png", StadiumId = "4", SubscriptionPrice = 250 }; // 4 - 4
            var team5 = new Team { Id = "5", Name = "Genk", Logo = "/images/Genk.png", StadiumId = "5", SubscriptionPrice = 350 };  // 5 - 6
            var team6 = new Team { Id = "6", Name = "AA Gent", Logo = "/images/AA_Gent.png", StadiumId = "6", SubscriptionPrice = 300 }; // 6 - 5

            // Add teams
            modelBuilder.Entity<Team>().HasData(
                team1, team2, team3, team4, team5, team6
                );

            var season1 = new Season { Id = "1", StartDate = new DateTime(2019, 7, 26), EndDate = new DateTime(2020, 5, 24) };
            var season2 = new Season { Id = "2", StartDate = new DateTime(2020, 7, 24), EndDate = new DateTime(2021, 5, 23) };
            var season3 = new Season { Id = "3", StartDate = new DateTime(2021, 7, 23), EndDate = new DateTime(2022, 5, 22) };

            // Add Season
            modelBuilder.Entity<Season>().HasData(
                season1, season2, season3
                );

            var stadium1 = new Stadium { Id = "1", Name = "Jan Breydelstadion", Street = "Olympialaan 74", City = "Brugge", Zipcode = "8000", Country = "België" };
            var stadium2 = new Stadium { Id = "2", Name = "Albertparkstadion", Street = "Leopold Van Tyghemlaan 62", City = "Oostende", Zipcode = "8400", Country = "België" };
            var stadium3 = new Stadium { Id = "3", Name = "Constant Vanden Stock stadion", Street = "Theo Verbeecklaan 2", City = "Brussel", Zipcode = "1070", Country = "België" };
            var stadium4 = new Stadium { Id = "4", Name = "Regenboogstadion", Street = "Zuiderlaan 17", City = "Waregem", Zipcode = "8790", Country = "België" };
            var stadium5 = new Stadium { Id = "5", Name = "Cristal Arena", Street = "Stadionplein", City = "Genk", Zipcode = "3600", Country = "België" };
            var stadium6 = new Stadium { Id = "6", Name = "Ghelamco Arena", Street = "Bruiloftstraat 42", City = "Gentbrugge", Zipcode = "9050", Country = "België" };

            // Add Stadium
            modelBuilder.Entity<Stadium>().HasData(
                stadium1, stadium2, stadium3, stadium4, stadium5, stadium6
                );

            // Add section
            var section1 = new Section { Id = "1", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "1" };
            var section2 = new Section { Id = "2", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "1" };
            var section3 = new Section { Id = "3", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "1" };
            var section4 = new Section { Id = "4", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "1" };
            var section5 = new Section { Id = "5", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "1" };
            var section6 = new Section { Id = "6", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "1" };
            var section7 = new Section { Id = "7", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "1" };
            var section8 = new Section { Id = "8", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "1" };

            var section9 = new Section { Id = "9", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "2" };
            var section10 = new Section { Id = "10", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "2" };
            var section11 = new Section { Id = "11", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "2" };
            var section12 = new Section { Id = "12", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "2" };
            var section13 = new Section { Id = "13", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "2" };
            var section14 = new Section { Id = "14", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "2" };
            var section15 = new Section { Id = "15", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "2" };
            var section16 = new Section { Id = "16", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "2" };

            var section17 = new Section { Id = "17", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "3" };
            var section18 = new Section { Id = "18", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "3" };
            var section19 = new Section { Id = "19", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "3" };
            var section20 = new Section { Id = "20", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "3" };
            var section21 = new Section { Id = "21", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "3" };
            var section22 = new Section { Id = "22", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "3" };
            var section23 = new Section { Id = "23", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "3" };
            var section24 = new Section { Id = "24", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "3" };

            var section25 = new Section { Id = "25", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "4" };
            var section26 = new Section { Id = "26", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "4" };
            var section27 = new Section { Id = "27", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "4" };
            var section28 = new Section { Id = "28", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "4" };
            var section29 = new Section { Id = "29", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "4" };
            var section30 = new Section { Id = "30", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "4" };
            var section31 = new Section { Id = "31", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "4" };
            var section32 = new Section { Id = "32", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "4" };

            var section33 = new Section { Id = "33", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "5" };
            var section34 = new Section { Id = "34", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "5" };
            var section35 = new Section { Id = "35", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "5" };
            var section36 = new Section { Id = "36", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "5" };
            var section37 = new Section { Id = "37", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "5" };
            var section38 = new Section { Id = "38", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "5" };
            var section39 = new Section { Id = "39", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "5" };
            var section40 = new Section { Id = "40", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "5" };

            var section41 = new Section { Id = "41", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "6" };
            var section42 = new Section { Id = "42", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "6" };
            var section43 = new Section { Id = "43", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "6" };
            var section44 = new Section { Id = "44", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "6" };
            var section45 = new Section { Id = "45", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "6" };
            var section46 = new Section { Id = "46", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "6" };
            var section47 = new Section { Id = "47", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "6" };
            var section48 = new Section { Id = "48", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "6" };

            modelBuilder.Entity<Section>().HasData(
                section1, section2, section3, section4, section5, section6, section7, section8, section9, section10,
                section11, section12, section13, section14, section15, section16, section17, section18, section19, section20,
                section21, section22, section23, section24, section25, section26, section27, section28, section29, section30,
                section31, section32, section33, section34, section35, section36, section37, section38, section39, section40,
                section41, section42, section43, section44, section45, section46, section47, section48
                );

            // Add Matches
            var match1 = new Match { Id = "1", MatchDate = new DateTime(2020, 4, 18, 18, 30, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "1", AwayTeamId = "2" };
            var match2 = new Match { Id = "2", MatchDate = new DateTime(2020, 4, 18, 18, 30, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "3", AwayTeamId = "4" };
            var match3 = new Match { Id = "3", MatchDate = new DateTime(2020, 4, 18, 18, 30, 0), BasePriceTicket = 13, SeasonId = "1", HomeTeamId = "5", AwayTeamId = "6" };
            var match4 = new Match { Id = "4", MatchDate = new DateTime(2020, 4, 25, 18, 00, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "6", AwayTeamId = "1" };
            var match5 = new Match { Id = "5", MatchDate = new DateTime(2020, 4, 25, 18, 00, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "2", AwayTeamId = "3" };
            var match6 = new Match { Id = "6", MatchDate = new DateTime(2020, 4, 25, 18, 00, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "4", AwayTeamId = "5" };

            var match7 = new Match { Id = "7", MatchDate = new DateTime(2020, 5, 2, 19, 30, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "1", AwayTeamId = "2" };
            var match8 = new Match { Id = "8", MatchDate = new DateTime(2020, 5, 2, 19, 30, 0), BasePriceTicket = 12,  SeasonId = "1", HomeTeamId = "3", AwayTeamId = "4" };
            var match9 = new Match { Id = "9", MatchDate = new DateTime(2020, 5, 2, 19, 30, 0), BasePriceTicket = 13, SeasonId = "1", HomeTeamId = "5", AwayTeamId = "6" };
            var match10 = new Match { Id = "10", MatchDate = new DateTime(2020, 5, 9, 19, 0, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "6", AwayTeamId = "6" };
            var match11 = new Match { Id = "11", MatchDate = new DateTime(2020, 5, 9, 19, 0, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "2", AwayTeamId = "3" };
            var match12 = new Match { Id = "12", MatchDate = new DateTime(2020, 5, 9, 19, 0, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "4", AwayTeamId = "5" };

            var match13 = new Match { Id = "13", MatchDate = new DateTime(2020, 5, 16, 17, 30, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "1", AwayTeamId = "2" };
            var match14 = new Match { Id = "14", MatchDate = new DateTime(2020, 5, 16, 17, 30, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "3", AwayTeamId = "4" };
            var match15 = new Match { Id = "15", MatchDate = new DateTime(2020, 5, 16, 17, 30, 0), BasePriceTicket = 13, SeasonId = "1", HomeTeamId = "5", AwayTeamId = "6" };
            var match16 = new Match { Id = "16", MatchDate = new DateTime(2020, 5, 24, 17, 0, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "6", AwayTeamId = "1" };
            var match17 = new Match { Id = "17", MatchDate = new DateTime(2020, 5, 24, 17, 0, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "2", AwayTeamId = "3" };
            var match18 = new Match { Id = "18", MatchDate = new DateTime(2020, 5, 24, 17, 0, 0), BasePriceTicket = 12, SeasonId = "1", HomeTeamId = "4", AwayTeamId = "5" };
            var match19 = new Match { Id = "19", MatchDate = new DateTime(2020, 4, 26, 17, 0, 0), BasePriceTicket = 15, SeasonId = "1", HomeTeamId = "1", AwayTeamId = "2" };

            modelBuilder.Entity<Match>().HasData(
                match1, match2, match3, match4, match5, match6, match7, match8, match9, match10,
                match11, match12, match13, match14, match15, match16, match17, match18,match19);

            //Add matchsections
            var matchSection1 = new MatchSection { Id = "1", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "1" };
            var matchSection2 = new MatchSection { Id = "2", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "2" };
            var matchSection3 = new MatchSection { Id = "3", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "3" };
            var matchSection4 = new MatchSection { Id = "4", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "4" };
            var matchSection5 = new MatchSection { Id = "5", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "5" };
            var matchSection6 = new MatchSection { Id = "6", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "6" };
            var matchSection7 = new MatchSection { Id = "7", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "7" };
            var matchSection8 = new MatchSection { Id = "8", OccupiedReservationSeats = 0, MatchId = "1", SectionId = "8" };

            var matchSection9 = new MatchSection { Id = "9", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "17" };
            var matchSection10 = new MatchSection { Id = "10", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "18" };
            var matchSection11 = new MatchSection { Id = "11", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "19" };
            var matchSection12 = new MatchSection { Id = "12", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "20" };
            var matchSection13 = new MatchSection { Id = "13", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "21" };
            var matchSection14 = new MatchSection { Id = "14", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "22" };
            var matchSection15 = new MatchSection { Id = "15", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "23" };
            var matchSection16 = new MatchSection { Id = "16", OccupiedReservationSeats = 0, MatchId = "2", SectionId = "24" };

            var matchSection17 = new MatchSection { Id = "17", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "33" };
            var matchSection18 = new MatchSection { Id = "18", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "34" };
            var matchSection19 = new MatchSection { Id = "19", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "35" };
            var matchSection20 = new MatchSection { Id = "20", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "36" };
            var matchSection21 = new MatchSection { Id = "21", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "37" };
            var matchSection22 = new MatchSection { Id = "22", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "38" };
            var matchSection23 = new MatchSection { Id = "23", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "39" };
            var matchSection24 = new MatchSection { Id = "24", OccupiedReservationSeats = 0, MatchId = "3", SectionId = "40" };

            var matchSection25 = new MatchSection { Id = "25", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "41" };
            var matchSection26 = new MatchSection { Id = "26", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "42" };
            var matchSection27 = new MatchSection { Id = "27", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "43" };
            var matchSection28 = new MatchSection { Id = "28", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "44" };
            var matchSection29 = new MatchSection { Id = "29", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "45" };
            var matchSection30 = new MatchSection { Id = "30", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "46" };
            var matchSection31 = new MatchSection { Id = "31", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "17" };
            var matchSection32 = new MatchSection { Id = "32", OccupiedReservationSeats = 0, MatchId = "4", SectionId = "48" };

            var matchSection33 = new MatchSection { Id = "33", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "9" };
            var matchSection34 = new MatchSection { Id = "34", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "10" };
            var matchSection35 = new MatchSection { Id = "35", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "11" };
            var matchSection36 = new MatchSection { Id = "36", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "12" };
            var matchSection37 = new MatchSection { Id = "37", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "13" };
            var matchSection38 = new MatchSection { Id = "38", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "14" };
            var matchSection39 = new MatchSection { Id = "39", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "15" };
            var matchSection40 = new MatchSection { Id = "40", OccupiedReservationSeats = 0, MatchId = "5", SectionId = "16" };

            var matchSection41 = new MatchSection { Id = "41", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "25" };
            var matchSection42 = new MatchSection { Id = "42", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "26" };
            var matchSection43 = new MatchSection { Id = "43", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "27" };
            var matchSection44 = new MatchSection { Id = "44", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "28" };
            var matchSection45 = new MatchSection { Id = "45", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "29" };
            var matchSection46 = new MatchSection { Id = "46", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "30" };
            var matchSection47 = new MatchSection { Id = "47", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "31" };
            var matchSection48 = new MatchSection { Id = "48", OccupiedReservationSeats = 0, MatchId = "6", SectionId = "32" };

            var matchSection49 = new MatchSection { Id = "49", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "1" };
            var matchSection50 = new MatchSection { Id = "50", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "2" };
            var matchSection51 = new MatchSection { Id = "51", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "3" };
            var matchSection52 = new MatchSection { Id = "52", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "4" };
            var matchSection53 = new MatchSection { Id = "53", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "5" };
            var matchSection54 = new MatchSection { Id = "54", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "6" };
            var matchSection55 = new MatchSection { Id = "55", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "7" };
            var matchSection56 = new MatchSection { Id = "56", OccupiedReservationSeats = 0, MatchId = "7", SectionId = "8" };

            var matchSection57 = new MatchSection { Id = "57", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "17" };
            var matchSection58 = new MatchSection { Id = "58", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "18" };
            var matchSection59 = new MatchSection { Id = "59", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "19" };
            var matchSection60 = new MatchSection { Id = "60", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "20" };
            var matchSection61 = new MatchSection { Id = "61", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "21" };
            var matchSection62 = new MatchSection { Id = "62", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "22" };
            var matchSection63 = new MatchSection { Id = "63", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "23" };
            var matchSection64 = new MatchSection { Id = "64", OccupiedReservationSeats = 0, MatchId = "8", SectionId = "24" };

            var matchSection65 = new MatchSection { Id = "65", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "33" };
            var matchSection66 = new MatchSection { Id = "66", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "34" };
            var matchSection67 = new MatchSection { Id = "67", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "35" };
            var matchSection68 = new MatchSection { Id = "68", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "36" };
            var matchSection69 = new MatchSection { Id = "69", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "37" };
            var matchSection70 = new MatchSection { Id = "70", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "38" };
            var matchSection71 = new MatchSection { Id = "71", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "39" };
            var matchSection72 = new MatchSection { Id = "72", OccupiedReservationSeats = 0, MatchId = "9", SectionId = "40" };

            var matchSection73 = new MatchSection { Id = "73", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "41" };
            var matchSection74 = new MatchSection { Id = "74", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "42" };
            var matchSection75 = new MatchSection { Id = "75", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "43" };
            var matchSection76 = new MatchSection { Id = "76", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "44" };
            var matchSection77 = new MatchSection { Id = "77", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "45" };
            var matchSection78 = new MatchSection { Id = "78", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "46" };
            var matchSection79 = new MatchSection { Id = "79", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "17" };
            var matchSection80 = new MatchSection { Id = "80", OccupiedReservationSeats = 0, MatchId = "10", SectionId = "48" };

            var matchSection81 = new MatchSection { Id = "81", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "9" };
            var matchSection82 = new MatchSection { Id = "82", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "10" };
            var matchSection83 = new MatchSection { Id = "83", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "11" };
            var matchSection84 = new MatchSection { Id = "84", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "12" };
            var matchSection85 = new MatchSection { Id = "85", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "13" };
            var matchSection86 = new MatchSection { Id = "86", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "14" };
            var matchSection87 = new MatchSection { Id = "87", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "15" };
            var matchSection88 = new MatchSection { Id = "88", OccupiedReservationSeats = 0, MatchId = "11", SectionId = "16" };

            var matchSection89 = new MatchSection { Id = "89", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "25" };
            var matchSection90 = new MatchSection { Id = "90", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "26" };
            var matchSection91 = new MatchSection { Id = "91", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "27" };
            var matchSection92 = new MatchSection { Id = "92", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "28" };
            var matchSection93 = new MatchSection { Id = "93", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "29" };
            var matchSection94 = new MatchSection { Id = "94", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "30" };
            var matchSection95 = new MatchSection { Id = "95", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "31" };
            var matchSection96 = new MatchSection { Id = "96", OccupiedReservationSeats = 0, MatchId = "12", SectionId = "32" };

            var matchSection97 = new MatchSection { Id = "97", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "1" };
            var matchSection98 = new MatchSection { Id = "98", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "2" };
            var matchSection99 = new MatchSection { Id = "99", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "3" };
            var matchSection100 = new MatchSection { Id = "100", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "4" };
            var matchSection101 = new MatchSection { Id = "101", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "5" };
            var matchSection102 = new MatchSection { Id = "102", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "6" };
            var matchSection103 = new MatchSection { Id = "103", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "7" };
            var matchSection104 = new MatchSection { Id = "104", OccupiedReservationSeats = 0, MatchId = "13", SectionId = "8" };

            var matchSection105 = new MatchSection { Id = "105", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "17" };
            var matchSection106 = new MatchSection { Id = "106", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "18" };
            var matchSection107 = new MatchSection { Id = "107", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "19" };
            var matchSection108 = new MatchSection { Id = "108", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "20" };
            var matchSection109 = new MatchSection { Id = "109", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "21" };
            var matchSection110 = new MatchSection { Id = "110", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "22" };
            var matchSection111 = new MatchSection { Id = "111", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "23" };
            var matchSection112 = new MatchSection { Id = "112", OccupiedReservationSeats = 0, MatchId = "14", SectionId = "24" };

            var matchSection113 = new MatchSection { Id = "113", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "33" };
            var matchSection114 = new MatchSection { Id = "114", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "34" };
            var matchSection115 = new MatchSection { Id = "115", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "35" };
            var matchSection116 = new MatchSection { Id = "116", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "36" };
            var matchSection117 = new MatchSection { Id = "117", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "37" };
            var matchSection118 = new MatchSection { Id = "118", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "38" };
            var matchSection119 = new MatchSection { Id = "119", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "39" };
            var matchSection120 = new MatchSection { Id = "120", OccupiedReservationSeats = 0, MatchId = "15", SectionId = "40" };

            var matchSection121 = new MatchSection { Id = "121", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "41" };
            var matchSection122 = new MatchSection { Id = "122", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "42" };
            var matchSection123 = new MatchSection { Id = "123", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "43" };
            var matchSection124 = new MatchSection { Id = "124", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "44" };
            var matchSection125 = new MatchSection { Id = "125", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "45" };
            var matchSection126 = new MatchSection { Id = "126", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "46" };
            var matchSection127 = new MatchSection { Id = "127", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "17" };
            var matchSection128 = new MatchSection { Id = "128", OccupiedReservationSeats = 0, MatchId = "16", SectionId = "48" };

            var matchSection129 = new MatchSection { Id = "129", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "9" };
            var matchSection130 = new MatchSection { Id = "130", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "10" };
            var matchSection131 = new MatchSection { Id = "131", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "11" };
            var matchSection132 = new MatchSection { Id = "132", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "12" };
            var matchSection133 = new MatchSection { Id = "133", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "13" };
            var matchSection134 = new MatchSection { Id = "134", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "14" };
            var matchSection135 = new MatchSection { Id = "135", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "15" };
            var matchSection136 = new MatchSection { Id = "136", OccupiedReservationSeats = 0, MatchId = "17", SectionId = "16" };

            var matchSection137 = new MatchSection { Id = "137", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "25" };
            var matchSection138 = new MatchSection { Id = "138", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "26" };
            var matchSection139 = new MatchSection { Id = "139", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "27" };
            var matchSection140 = new MatchSection { Id = "140", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "28" };
            var matchSection141 = new MatchSection { Id = "141", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "29" };
            var matchSection142 = new MatchSection { Id = "142", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "30" };
            var matchSection143 = new MatchSection { Id = "143", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "31" };
            var matchSection144 = new MatchSection { Id = "144", OccupiedReservationSeats = 0, MatchId = "18", SectionId = "32" };

            var matchSection145 = new MatchSection { Id = "145", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "1" };
            var matchSection146 = new MatchSection { Id = "146", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "2" };
            var matchSection147 = new MatchSection { Id = "147", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "3" };
            var matchSection148 = new MatchSection { Id = "148", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "4" };
            var matchSection149 = new MatchSection { Id = "149", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "5" };
            var matchSection150 = new MatchSection { Id = "150", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "6" };
            var matchSection151 = new MatchSection { Id = "151", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "7" };
            var matchSection152 = new MatchSection { Id = "152", OccupiedReservationSeats = 0, MatchId = "19", SectionId = "8" };



            modelBuilder.Entity<MatchSection>().HasData(
                matchSection1, matchSection2, matchSection3, matchSection4, matchSection5, matchSection6, matchSection7, matchSection8, matchSection9,
                matchSection10, matchSection11, matchSection12, matchSection13, matchSection14, matchSection15, matchSection16, matchSection17, matchSection18, matchSection19,
                matchSection20, matchSection21, matchSection22, matchSection23, matchSection24, matchSection25, matchSection26, matchSection27, matchSection28, matchSection29,
                matchSection30, matchSection31, matchSection32, matchSection33, matchSection34, matchSection35, matchSection36, matchSection37, matchSection38, matchSection39,
                matchSection40, matchSection41, matchSection42, matchSection43, matchSection44, matchSection45, matchSection46, matchSection47, matchSection48, matchSection49,
                matchSection50, matchSection51, matchSection52, matchSection53, matchSection54, matchSection55, matchSection56, matchSection57, matchSection58, matchSection59,
                matchSection60, matchSection61, matchSection62, matchSection63, matchSection64, matchSection65, matchSection66, matchSection67, matchSection68, matchSection69,
                matchSection70, matchSection71, matchSection72, matchSection73, matchSection74, matchSection75, matchSection76, matchSection77, matchSection78, matchSection79,
                matchSection80, matchSection81, matchSection82, matchSection83, matchSection84, matchSection85, matchSection86, matchSection87, matchSection88, matchSection89,
                matchSection90, matchSection91, matchSection92, matchSection93, matchSection94, matchSection95, matchSection96, matchSection97, matchSection98, matchSection99,
                matchSection100, matchSection101, matchSection102, matchSection103, matchSection104, matchSection105, matchSection106, matchSection107, matchSection108, matchSection109,
                matchSection110, matchSection111, matchSection112, matchSection113, matchSection114, matchSection115, matchSection116, matchSection117, matchSection118, matchSection119,
                matchSection120, matchSection121, matchSection122, matchSection123, matchSection124, matchSection125, matchSection126, matchSection127, matchSection128, matchSection129,
                matchSection130, matchSection131, matchSection132, matchSection133, matchSection134, matchSection135, matchSection136, matchSection137, matchSection138, matchSection139,
                matchSection140, matchSection141, matchSection142, matchSection143, matchSection144, matchSection145, matchSection146, matchSection147, matchSection148, matchSection149, 
                matchSection150, matchSection151, matchSection152
                ) ;



        }
    }
}