using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Stadium
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
