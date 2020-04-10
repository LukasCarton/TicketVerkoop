using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Match
    {
        [Key]
        public string Id { get; set; }
        public DateTime MatchDate { get; set; }
        public double BasePriceTicket { get; set; }
        public Stadium Stadium { get; set; }
        public Season Season { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
