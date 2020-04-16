using System.Collections.Generic;


namespace TicketVerkoop.ViewModels
{
    public class ShoppingCartVM
    {
        public List<ReservationVM> Reservations { get; set; }
        public List<SubscriptionCartVM> Subscriptions { get; set; }
    }
}
