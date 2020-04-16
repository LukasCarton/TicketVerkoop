using System;
using System.ComponentModel.DataAnnotations;


namespace TicketVerkoop.ViewModels
{
    public class ReservationVM
    {
        public string Id { get; set; }
        [Display(Name ="Match datum")]
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
        [Display(Name = "Thuis Ploeg")]
        public string HomeTeam { get; set; }
        [Display(Name = "Uit Ploeg")]
        public string AwayTeam { get; set; }
        public string MatchId { get; set; }
    }
}
