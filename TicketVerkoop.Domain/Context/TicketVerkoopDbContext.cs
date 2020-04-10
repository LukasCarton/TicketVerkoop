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
    }
}
