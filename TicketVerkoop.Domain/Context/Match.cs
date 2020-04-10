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
        public string StadiumId { get; set; }
        public string SeasonId { get; set; }
        public string HomeTeamId { get; set; }
        public string AwayTeamId { get; set; }

        public Stadium Stadium { get; set; }
        public Season Season { get; set; }
        public HomeTeam HomeTeam { get; set; }
        public AwayTeam AwayTeam { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
