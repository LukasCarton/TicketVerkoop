using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Team
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<HomeTeam> HomeTeams { get; set; }
        public ICollection<AwayTeam> AwayTeams { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
