using System;
using System.Collections.Generic;

namespace TicketVerkoop.ViewModels
{
    public class SubscriptionSectionVM
    {
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<SectionVM> SectionVMs { get; set; }

    }
}
