using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Section
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int OccupiedReservationSeats { get; set; }
        public int OccupiedSubscriptionSeats { get; set; }
        public double PriceFactor { get; set; }
        public int Ring { get; set; }
        public string StadiumId { get; set; }

        public Stadium Stadium { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }

    }
}
