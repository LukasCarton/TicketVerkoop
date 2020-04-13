using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.ViewModels
{
    public class MatchSectionInfoVM
    {
        public int NumberOfTickets { get; set; }
        public List<MatchSectionVM> MatchSections { get; set; }

    }
}
