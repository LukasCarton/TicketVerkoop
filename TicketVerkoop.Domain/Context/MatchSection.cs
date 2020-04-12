using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class MatchSection
    {
        [Key]
        public string Id { get; set; }
        public int OccupiedReservationSeats { get; set; }
        public string MatchId { get; set; }
        public string SectionId { get; set; }

        public Match Match { get; set; }
        public Section Section { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
