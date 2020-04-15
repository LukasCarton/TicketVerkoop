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
using TicketVerkoop.ViewModels;

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

        public async Task<IActionResult> ListReservations()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _reservationService.GetAllReservationsFromCustomerAsync(id);
            var reservationVMs = _mapper.Map<List<ReservationVM>>(reservations);
            return View(reservationVMs);
        }
        
        public async Task<IActionResult> DeleteReservation(string id)
        {
            var reservation = await _reservationService.FindById(id);
            await _reservationService.RemoveAsync(reservation);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _reservationService.GetAllReservationsFromCustomerAsync(userId);
            var reservationVMs = _mapper.Map<List<ReservationVM>>(reservations);
            return View("ListReservations",reservationVMs);
        }
    }
}