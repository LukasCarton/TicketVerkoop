using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class AwayTeam
    {
        [Key]
        public string Id { get; set; }
        public string TeamId { get; set; }

        public Team Team { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
