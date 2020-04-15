using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class MatchVM
    {
        public string Id { get; set; }
        [Display(Name ="Datum")]
        public DateTime MatchDate { get; set; }
        public double BasePriceTicket { get; set; }
        [Display(Name ="Stadion")]
        public string StadiumNaam { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        [Display(Name = "Home Team")]
        public string HomeTeamNaam { get; set; }
        [Display(Name = "Away Team")]
        public string AwayTeamNaam { get; set; }
    }
}
