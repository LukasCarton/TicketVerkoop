using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class ReservationVM
    {
        public string Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfTickets { get; set; }
        public string CustomerName { get; set; }
        public double Price { get; set; }
        public string SectionName { get; set; }
        public string MatchSectionId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
    }
}
