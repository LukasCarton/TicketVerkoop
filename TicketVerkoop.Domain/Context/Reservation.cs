using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Reservation
    {
        [Key]
        public string Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfTickets { get; set; }
        public string CustomerId { get; set; }
        public string MatchSectionId { get; set; }
        public double Price{ get; set; }

        public Customer Customer { get; set; }
        public MatchSection MatchSection { get; set; }
    }
}
