using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class TeamWithMatchesVM
    {
        public string TeamName { get; set; }
        public IEnumerable<MatchVM> MatchVMs { get; set; }
    }
}
