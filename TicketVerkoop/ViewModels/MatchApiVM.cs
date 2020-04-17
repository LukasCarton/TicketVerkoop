using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class MatchApiVM
    {
        public DateTime MatchDate { get; set; }
        public double BasePriceTicket { get; set; }
        public string StadiumName { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public string HomeTeamNaam { get; set; }
        public string AwayTeamNaam { get; set; }
    }
}
