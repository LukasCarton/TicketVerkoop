using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public class SectionVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AvailablePlaces { get; set; }
        public double Price { get; set; }
        public int Ring { get; set; }
    }
}
