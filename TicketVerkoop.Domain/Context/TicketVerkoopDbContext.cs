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
            var team1 = new Team { Id = "1", Name = "Club Brugge",Logo= "/images/Club_Brugge.png" };  //1 - 1
            var team2 = new Team { Id = "2", Name = "Oostende", Logo = "/images/Oostende.png"};  //2 - 3
            var team3 = new Team { Id = "3", Name = "RSC Anderlecht", Logo = "/images/RSC_Anderlecht.png" }; // 3 - 2
            var team4 = new Team { Id = "4", Name = "Zulte Waregem" ,Logo = "/images/Zulte_Waregem.png" }; // 4 - 4
            var team5 = new Team { Id = "5", Name = "Genk", Logo = "/images/Genk.png" };  // 5 - 6
            var team6 = new Team { Id = "6", Name = "AA Gent", Logo = "/images/AA_Gent.png"}; // 6 - 5

            // Add teams
            modelBuilder.Entity<Team>().HasData(
                team1, team2, team3, team4, team5, team6
                );

            var stadium1 = new Stadium { Id = "1", Name = "Jan Breydelstadion", Street = "Olympialaan 74", City = "Brugge", Zipcode = "8000", Country = "België" };
            var stadium2 = new Stadium { Id = "2", Name = "Constant Vanden Stock stadion", Street = "Theo Verbeecklaan 2", City = "Brussel", Zipcode = "1070", Country = "België" };
            var stadium3 = new Stadium { Id = "3", Name = "Albertparkstadion", Street = "Leopold Van Tyghemlaan 62", City = "Oostende", Zipcode = "8400", Country = "België" };
            var stadium4 = new Stadium { Id = "4", Name = "Regenboogstadion", Street = "Zuiderlaan 17", City = "Waregem", Zipcode = "8790", Country = "België" };
            var stadium5 = new Stadium { Id = "5", Name = "Ghelamco Arena", Street = "Bruiloftstraat 42", City = "Gentbrugge", Zipcode = "9050", Country = "België" };
            var stadium6 = new Stadium { Id = "6", Name = "Cristal Arena", Street = "Stadionplein", City = "Genk", Zipcode = "3600", Country = "België" };

            // Add Matches
            var match1 = new Match { Id = "1", MatchDate = new DateTime(2020, 4, 30), BasePriceTicket = 15, StadiumId = "1", SeasonId = "1", HomeTeamId = "1", AwayTeamId = "2" };
            var match2 = new Match { Id = "2", MatchDate = new DateTime(2020, 4, 30), BasePriceTicket = 12, StadiumId = "2", SeasonId = "1", HomeTeamId = "3", AwayTeamId = "1" };
            var match3 = new Match { Id = "3", MatchDate = new DateTime(2021, 3, 15), BasePriceTicket = 13, StadiumId = "3", SeasonId = "2", HomeTeamId = "2", AwayTeamId = "4" };
            var match4 = new Match { Id = "4", MatchDate = new DateTime(2020, 5, 7), BasePriceTicket = 14, StadiumId = "4", SeasonId = "1", HomeTeamId = "4", AwayTeamId = "3" };
            var match5 = new Match { Id = "5", MatchDate = new DateTime(2021, 5, 20), BasePriceTicket = 20, StadiumId = "5", SeasonId = "2", HomeTeamId = "6", AwayTeamId = "4" };
            var match6 = new Match { Id = "6", MatchDate = new DateTime(2020, 1, 2), BasePriceTicket = 25, StadiumId = "6", SeasonId = "1", HomeTeamId = "2", AwayTeamId = "5" };
            //var match7 = new Match { Id = "7", MatchDate = new DateTime(2020, 2, 11), BasePriceTicket = 30, StadiumId = "1", SeasonId = "1", HomeTeamId = "1", AwayTeamId = "3" };
            //var match8 = new Match { Id = "8", MatchDate = new DateTime(2020, 11, 18), BasePriceTicket = 21, StadiumId = "2", SeasonId = "1", HomeTeamId = "3", AwayTeamId = "1" };
            //var match9 = new Match { Id = "9", MatchDate = new DateTime(2021, 1, 2), BasePriceTicket = 14, StadiumId = "3", SeasonId = "2", HomeTeamId = "2", AwayTeamId = "3" };
            //var match10 = new Match { Id = "10", MatchDate = new DateTime(2021, 3, 12), BasePriceTicket = 12, StadiumId = "4", SeasonId = "2", HomeTeamId = "4", AwayTeamId = "3" };
            modelBuilder.Entity<Match>().HasData(match1, match2, match3, match4, match5, match6);

            // Add Stadium
            modelBuilder.Entity<Stadium>().HasData(
                stadium1, stadium2, stadium3, stadium4, stadium5, stadium6
                );

            var season1 = new Season { Id = "1", StartDate = new DateTime(2019, 7, 26), EndDate = new DateTime(2020, 5, 24) };
            var season2 = new Season { Id = "2", StartDate = new DateTime(2020, 7, 24), EndDate = new DateTime(2021, 5, 23) };

            // Add Season
            modelBuilder.Entity<Season>().HasData(
                season1, season2
                );
            var matchSection1 = new MatchSection{Id = "1", OccupiedReservationSeats=0,MatchId = "1", SectionId ="1"};
            var matchSection2 = new MatchSection{Id = "2", OccupiedReservationSeats=0,MatchId = "1", SectionId ="2"};
            var matchSection3 = new MatchSection{Id = "3", OccupiedReservationSeats=0,MatchId = "1", SectionId ="3"};
            var matchSection4 = new MatchSection{Id = "4", OccupiedReservationSeats=0,MatchId = "1", SectionId ="4"};
            var matchSection5 = new MatchSection{Id = "5", OccupiedReservationSeats=0,MatchId = "1", SectionId ="5"};
            var matchSection6 = new MatchSection{Id = "6", OccupiedReservationSeats=0,MatchId = "1", SectionId ="6"};
            var matchSection7 = new MatchSection{Id = "7", OccupiedReservationSeats=0,MatchId = "1", SectionId ="7"};
            var matchSection8 = new MatchSection{Id = "8", OccupiedReservationSeats=0,MatchId = "1", SectionId ="8"};

            var matchSection9 = new MatchSection{Id = "9", OccupiedReservationSeats=0,MatchId = "2", SectionId ="9"};
            var matchSection10 = new MatchSection{Id = "10", OccupiedReservationSeats=0,MatchId = "2", SectionId ="10"};
            var matchSection11 = new MatchSection{Id = "11", OccupiedReservationSeats=0,MatchId = "2", SectionId ="11"};
            var matchSection12 = new MatchSection{Id = "12", OccupiedReservationSeats=0,MatchId = "2", SectionId ="12"};
            var matchSection13 = new MatchSection{Id = "13", OccupiedReservationSeats=0,MatchId = "2", SectionId ="13"};
            var matchSection14 = new MatchSection{Id = "14", OccupiedReservationSeats=0,MatchId = "2", SectionId ="14"};
            var matchSection15 = new MatchSection{Id = "15", OccupiedReservationSeats=0,MatchId = "2", SectionId ="15"};
            var matchSection16 = new MatchSection{Id = "16", OccupiedReservationSeats=0,MatchId = "2", SectionId ="16"};

            var matchSection17 = new MatchSection{Id = "17", OccupiedReservationSeats=0,MatchId = "3", SectionId ="17"};
            var matchSection18 = new MatchSection{Id = "18", OccupiedReservationSeats=0,MatchId = "3", SectionId ="18"};
            var matchSection19 = new MatchSection{Id = "19", OccupiedReservationSeats=0,MatchId = "3", SectionId ="19"};
            var matchSection20 = new MatchSection{Id = "20", OccupiedReservationSeats=0,MatchId = "3", SectionId ="20"};
            var matchSection21 = new MatchSection{Id = "21", OccupiedReservationSeats=0,MatchId = "3", SectionId ="21"};
            var matchSection22 = new MatchSection{Id = "22", OccupiedReservationSeats=0,MatchId = "3", SectionId ="22"};
            var matchSection23 = new MatchSection{Id = "23", OccupiedReservationSeats=0,MatchId = "3", SectionId ="23"};
            var matchSection24 = new MatchSection{Id = "24", OccupiedReservationSeats=0,MatchId = "3", SectionId ="24"};

            var matchSection25 = new MatchSection{Id = "25", OccupiedReservationSeats=0,MatchId = "4", SectionId ="25"};
            var matchSection26 = new MatchSection{Id = "26", OccupiedReservationSeats=0,MatchId = "4", SectionId ="26"};
            var matchSection27 = new MatchSection{Id = "27", OccupiedReservationSeats=0,MatchId = "4", SectionId ="27"}; 
            var matchSection28 = new MatchSection{Id = "28", OccupiedReservationSeats=0,MatchId = "4", SectionId ="28"};
            var matchSection29 = new MatchSection{Id = "29", OccupiedReservationSeats=0,MatchId = "4", SectionId ="29"};
            var matchSection30 = new MatchSection{Id = "30", OccupiedReservationSeats=0,MatchId = "4", SectionId ="30"};
            var matchSection31 = new MatchSection{Id = "31", OccupiedReservationSeats=0,MatchId = "4", SectionId ="31"};
            var matchSection32 = new MatchSection{Id = "32", OccupiedReservationSeats=0,MatchId = "4", SectionId ="32"};

            var matchSection33 = new MatchSection{Id = "33", OccupiedReservationSeats=0,MatchId = "5", SectionId ="33"};
            var matchSection34 = new MatchSection{Id = "34", OccupiedReservationSeats=0,MatchId = "5", SectionId ="34"};
            var matchSection35 = new MatchSection{Id = "35", OccupiedReservationSeats=0,MatchId = "5", SectionId ="35"};
            var matchSection36 = new MatchSection{Id = "36", OccupiedReservationSeats=0,MatchId = "5", SectionId ="36"};
            var matchSection37 = new MatchSection{Id = "37", OccupiedReservationSeats=0,MatchId = "5", SectionId ="37"};
            var matchSection38 = new MatchSection{Id = "38", OccupiedReservationSeats=0,MatchId = "5", SectionId ="38"};
            var matchSection39 = new MatchSection{Id = "39", OccupiedReservationSeats=0,MatchId = "5", SectionId ="39"};
            var matchSection40 = new MatchSection{Id = "40", OccupiedReservationSeats=0,MatchId = "5", SectionId ="40"};

            var matchSection41 = new MatchSection{Id = "41", OccupiedReservationSeats=0,MatchId = "6", SectionId ="41"};
            var matchSection42 = new MatchSection{Id = "42", OccupiedReservationSeats=0,MatchId = "6", SectionId ="42"};
            var matchSection43 = new MatchSection{Id = "43", OccupiedReservationSeats=0,MatchId = "6", SectionId ="43"};
            var matchSection44 = new MatchSection{Id = "44", OccupiedReservationSeats=0,MatchId = "6", SectionId ="44"};
            var matchSection45 = new MatchSection{Id = "45", OccupiedReservationSeats=0,MatchId = "6", SectionId ="45"};
            var matchSection46 = new MatchSection{Id = "46", OccupiedReservationSeats=0,MatchId = "6", SectionId ="46"};
            var matchSection47 = new MatchSection{Id = "47", OccupiedReservationSeats=0,MatchId = "6", SectionId ="47"};
            var matchSection48 = new MatchSection{Id = "48", OccupiedReservationSeats=0,MatchId = "6", SectionId ="48"};


            // Add section
            var section1 = new Section { Id = "1", Name = "North", Capacity = 1000,OccupiedSubscriptionSeats=0, PriceFactor = 0.8, Ring = 0, StadiumId = "1" };
            var section2 = new Section { Id = "2", Name = "East", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "1" };
            var section3 = new Section { Id = "3", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "1" };
            var section4 = new Section { Id = "4", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "1" };
            var section5 = new Section { Id = "5", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "1" };
            var section6 = new Section { Id = "6", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "1" };
            var section7 = new Section { Id = "7", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "1" };
            var section8 = new Section { Id = "8", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "1" };

            var section9 = new Section { Id = "9", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "2" };
            var section10 = new Section { Id = "10", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "2" };
            var section11 = new Section { Id = "11", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "2" };
            var section12 = new Section { Id = "12", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "2" };
            var section13 = new Section { Id = "13", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "2" };
            var section14 = new Section { Id = "14", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "2" };
            var section15 = new Section { Id = "15", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "2" };
            var section16 = new Section { Id = "16", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "2" };

            var section17 = new Section { Id = "17", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "3" };
            var section18 = new Section { Id = "18", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "3" };
            var section19 = new Section { Id = "19", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "3" };
            var section20 = new Section { Id = "20", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "3" };
            var section21 = new Section { Id = "21", Name = "North", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "3" };
            var section22 = new Section { Id = "22", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "3" };
            var section23 = new Section { Id = "23", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "3" };
            var section24 = new Section { Id = "24", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "3" };

            var section25 = new Section { Id = "25", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "4" };
            var section26 = new Section { Id = "26", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "4" };
            var section27 = new Section { Id = "27", Name = "South", Capacity = 1000, OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "4" };
            var section28 = new Section { Id = "28", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "4" };
            var section29 = new Section { Id = "29", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "4" };
            var section30 = new Section { Id = "30", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "4" };
            var section31 = new Section { Id = "31", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "4" };
            var section32 = new Section { Id = "32", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "4" };

            var section33 = new Section { Id = "33", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "5" };
            var section34 = new Section { Id = "34", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "5" };
            var section35 = new Section { Id = "35", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "5" };
            var section36 = new Section { Id = "36", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "5" };
            var section37 = new Section { Id = "37", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "5" };
            var section38 = new Section { Id = "38", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "5" };
            var section39 = new Section { Id = "39", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "5" };
            var section40 = new Section { Id = "40", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "5" };

            var section41 = new Section { Id = "41", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "6" };
            var section42 = new Section { Id = "42", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "6" };
            var section43 = new Section { Id = "43", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "6" };
            var section44 = new Section { Id = "44", Name = "West", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "6" };
            var section45 = new Section { Id = "45", Name = "North", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "6" };
            var section46 = new Section { Id = "46", Name = "East", Capacity = 3000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "6" };
            var section47 = new Section { Id = "47", Name = "South", Capacity = 1000,  OccupiedSubscriptionSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "6" };
            var section48 = new Section { Id = "48", Name = "West", Capacity = 3000, OccupiedSubscriptionSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "6" };

            modelBuilder.Entity<Section>().HasData(
                section1, section2, section3, section4, section5, section6, section7, section8, section9, section10,
                section11, section12, section13, section14, section15, section16, section17, section18, section19, section20,
                section21, section22, section23, section24, section25, section26, section27, section28, section29, section30,
                section31, section32, section33, section34, section35, section36, section37, section38, section39, section40,
                section41, section42, section43, section44, section45, section46, section47, section48
                );
            
        }
    }
}
