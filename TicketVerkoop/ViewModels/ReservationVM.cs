using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class ReservationVM
    {
        public string Id { get; set; }
        [Display(Name ="Matched datum")]
        public DateTime MatchDate { get; set; }
        [Display(Name = "Reservatie datum")]
        public DateTime ReservationDate { get; set; }
        [Display(Name = "Aantal tickets")]
        public int NumberOfTickets { get; set; }
        [Display(Name = "Prijs")]
        public double Price { get; set; }
        [Display(Name = "Vak")]
        public string SectionName { get; set; }
        public string MatchSectionId { get; set; }
        [Display(Name = "Home Team")]
        public string HomeTeam { get; set; }
        [Display(Name = "Away Team")]
        public string AwayTeam { get; set; }
    }
}
