using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketVerkoop.Domain.Context
{
    public class Subscription
    {
        [Key]
        public string Id { get; set; }
        public Season Season { get; set; }
        public Team Team { get; set; }
        public Section Section { get; set; }
    }
}
