using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.ViewModels
{
    public class ShoppingCartVM
    {
        public List<ReservationVM> Reservations { get; set; }
        public List<SubscriptionVM> Subscriptions { get; set; }
    }
}
