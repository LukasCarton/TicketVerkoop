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
        public Customer Customer { get; set; }
        public Match Match { get; set; }
        public Section Section { get; set; }
    }
}
