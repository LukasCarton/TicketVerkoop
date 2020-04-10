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

        public TicketVerkoopDbContext(DbContextOptions<TicketVerkoopDbContext> options): base(options)
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
        }
    }
}
