using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationService _reservationService;

        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Reservation r = new Reservation
            {
                Id = "e0fcc3a5-dc32-4753-87ac-7956db6a517f",
                ReservationDate = DateTime.Today,
                NumberOfTickets = 5,
                CustomerId = id,
                MatchSectionId = "1"
            };
            await _reservationService.CreateAsync(r);
            return View(r);
        }

        public async Task<IActionResult> ListReservations()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _reservationService.GetAllReservationsFromCustomerAsync(id);
            return View(reservations);
        }
    }
}