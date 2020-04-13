using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.ViewModels
{
    public class MatchSectionInfoVM
    {

        [Required(ErrorMessage = "Gelieve in te geven hoeveel tickets u wilt kopen.")]
        [Display(Name ="Aantal Tickets")]
        public int NumberOfTickets { get; set; }

        public int MaxNumberOfTickets { get; set; }

        public string MatchId { get; set; }

        [Required(ErrorMessage ="Gelieve een vak te selecteren.")]
        public string SelectedMatchSectionId { get; set; }

        public List<MatchSectionVM> MatchSections { get; set; }

    }

    public class MaxTickets : ValidationAttribute
    {
        public int Tickets { get; set; }
        public MaxTickets(ICustomerService customerService, int tickets)
        {
            Tickets = tickets;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToInt16(value) > 0 && Convert.ToInt16(value) <= Tickets)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("U kunt maximum " + Tickets + " tickets kopen per match");
            }
        }

    }
}
