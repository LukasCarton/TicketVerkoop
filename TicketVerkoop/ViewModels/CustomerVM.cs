using System;
using System.ComponentModel.DataAnnotations;

namespace TicketVerkoop.ViewModels
{
    public class CustomerVM
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
