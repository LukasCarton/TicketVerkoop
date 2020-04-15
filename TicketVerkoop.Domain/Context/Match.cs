using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Match
    {
        [Key]
        public string Id { get; set; }
        public DateTime MatchDate { get; set; }
        public double BasePriceTicket { get; set; }
        public string SeasonId { get; set; }
        public string HomeTeamId { get; set; }
        public string AwayTeamId { get; set; }

        public Season Season { get; set; }
        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }
        [ForeignKey("AwayTeamId")]
        public Team AwayTeam { get; set; }

        public ICollection<MatchSection> MatchSections { get; set; }
    }
}
