using System;
using System.ComponentModel.DataAnnotations;

namespace TicketVerkoop.ViewModels
{
    public class SubscriptionCartVM
    {
        [Display(Name="Start Datum")]
        public DateTime SeasonStartDate { get; set; }
        [Display(Name = "Eind Datum")]
        public DateTime SeasonEndDate { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
        [Display(Name = "Sectie")]
        public string SectionName { get; set; }
        [Display(Name = "Prijs")]
        public double Price { get; set; }
        public string SeasonId { get; set; }
        public string TeamId { get; set; }
        public string SectionId { get; set; }
        public string CustomerId { get; set; }
    }
}
