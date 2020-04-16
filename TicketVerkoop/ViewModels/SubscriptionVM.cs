using System;

namespace TicketVerkoop.ViewModels
{
    public class SubscriptionVM
    {
        public string Id { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public string TeamName { get; set; }
        public string SectionName { get; set; }
        public string CustomerName { get; set; }
    }
}
