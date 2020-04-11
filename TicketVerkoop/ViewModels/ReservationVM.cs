using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class ReservationVM
    {
        public DateTime ReservationDate { get; set; }
        public int NumberOfTickets { get; set; }
        public string CustomerName { get; set; }
        public string Price { get; set; }
        public string SectionName { get; set; }
    }
}
