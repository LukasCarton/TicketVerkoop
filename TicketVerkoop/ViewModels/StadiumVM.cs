using System.ComponentModel.DataAnnotations;

namespace TicketVerkoop.ViewModels
{
    public class StadiumVM
    {
        public string Id { get; set; }
        [Display(Name="Naam")]
        public string Name { get; set; }
        [Display(Name = "Straat")]
        public string Street { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Postcode")]
        public string Zipcode { get; set; }
        [Display(Name = "Land")]
        public string Country { get; set; }
    }
}
