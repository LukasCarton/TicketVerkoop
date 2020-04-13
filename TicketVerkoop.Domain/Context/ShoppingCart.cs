using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class ShoppingCart
    {
        [Key]
        public string Id { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
