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
            var team1 = new Team { Id = "1", Name = "Club Brugge" };
            var team2 = new Team { Id = "2", Name = "Oostende" };
            var team3 = new Team { Id = "3", Name = "RSC Anderlecht" };
            var team4 = new Team { Id = "4", Name = "Zulte Waregem" };
            var team5 = new Team { Id = "5", Name = "Genk" };
            var team6 = new Team { Id = "6", Name = "AA Gent" };

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

            // Add section
            var section1 = new Section { Id = "1", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "1" };
            var section2 = new Section { Id = "2", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "1" };
            var section3 = new Section { Id = "3", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "1" };
            var section4 = new Section { Id = "4", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "1" };
            var section5 = new Section { Id = "5", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "1" };
            var section6 = new Section { Id = "6", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "1" };
            var section7 = new Section { Id = "7", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "1" };
            var section8 = new Section { Id = "8", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "1" };

            var section9 = new Section { Id = "9", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "2" };
            var section10 = new Section { Id = "10", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "2" };
            var section11 = new Section { Id = "11", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "2" };
            var section12 = new Section { Id = "12", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "2" };
            var section13 = new Section { Id = "13", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "2" };
            var section14 = new Section { Id = "14", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "2" };
            var section15 = new Section { Id = "15", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "2" };
            var section16 = new Section { Id = "16", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "2" };

            var section17 = new Section { Id = "17", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "3" };
            var section18 = new Section { Id = "18", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "3" };
            var section19 = new Section { Id = "19", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "3" };
            var section20 = new Section { Id = "20", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "3" };
            var section21 = new Section { Id = "21", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "3" };
            var section22 = new Section { Id = "22", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "3" };
            var section23 = new Section { Id = "23", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "3" };
            var section24 = new Section { Id = "24", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "3" };

            var section25 = new Section { Id = "25", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "4" };
            var section26 = new Section { Id = "26", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "4" };
            var section27 = new Section { Id = "27", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "4" };
            var section28 = new Section { Id = "28", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "4" };
            var section29 = new Section { Id = "29", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "4" };
            var section30 = new Section { Id = "30", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "4" };
            var section31 = new Section { Id = "31", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "4" };
            var section32 = new Section { Id = "32", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "4" };

            var section33 = new Section { Id = "33", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "5" };
            var section34 = new Section { Id = "34", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "5" };
            var section35 = new Section { Id = "35", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "5" };
            var section36 = new Section { Id = "36", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "5" };
            var section37 = new Section { Id = "37", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "5" };
            var section38 = new Section { Id = "38", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "5" };
            var section39 = new Section { Id = "39", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "5" };
            var section40 = new Section { Id = "40", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "5" };

            var section41 = new Section { Id = "41", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "6" };
            var section42 = new Section { Id = "42", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "6" };
            var section43 = new Section { Id = "43", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 0.8, Ring = 0, StadiumId = "6" };
            var section44 = new Section { Id = "44", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.2, Ring = 0, StadiumId = "6" };
            var section45 = new Section { Id = "45", Name = "North", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "6" };
            var section46 = new Section { Id = "46", Name = "East", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "6" };
            var section47 = new Section { Id = "47", Name = "South", Capacity = 1000, OccupiedSeats = 0, PriceFactor = 1.1, Ring = 1, StadiumId = "6" };
            var section48 = new Section { Id = "48", Name = "West", Capacity = 3000, OccupiedSeats = 0, PriceFactor = 1.5, Ring = 1, StadiumId = "6" };

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
