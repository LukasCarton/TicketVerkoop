using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class SubscriptionVM
    {
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public string TeamName { get; set; }
        public string SectionName { get; set; }
        public string CustomerName { get; set; }
    }
}
