using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Team
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string StadiumId { get; set; }
        public double SubscriptionPrice { get; set; }

        public Stadium Stadium { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
