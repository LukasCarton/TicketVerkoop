using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class SubscriptionCartVM
    {
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public string TeamName { get; set; }
        public string SectionName { get; set; }
        public double Price { get; set; }
        public string SeasonId { get; set; }
        public string TeamId { get; set; }
        public string SectionId { get; set; }
        public string CustomerId { get; set; }
    }
}
