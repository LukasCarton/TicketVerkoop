using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class MatchSectionVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AvailablePlaces { get; set; }
        public double Price { get; set; }
        public int Ring { get; set; }
    }
}
