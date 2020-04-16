using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Thuis Ploeg")]
        public string HomeTeamNaam { get; set; }
        [Display(Name = "Uit Ploeg")]
        public string AwayTeamNaam { get; set; }
    }
}
