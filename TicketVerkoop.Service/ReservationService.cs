using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class ReservationService : IReservationService
    {

        private IReservationDAO _reservationDAO;

        public ReservationService(IReservationDAO reservationDAO)
        {
            _reservationDAO = reservationDAO;
        }
        public async Task CreateAsync(Reservation reservation)
        {
            await _reservationDAO.CreateAsync(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsFromCustomerAsync(string customerId)
        {
            return await _reservationDAO.GetAllReservationsFromCustomerAsync(customerId);
        }

        public async Task RemoveAsync(Reservation reservation)
        {
            await _reservationDAO.RemoveAsync(reservation);
        }
    }
}
