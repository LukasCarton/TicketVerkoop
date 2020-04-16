using System;
using System.Collections.Generic;
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

        public async Task<Reservation> FindById(string Id)
        {
            return await _reservationDAO.FindById(Id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsFromCustomerAsync(string customerId)
        {
            return await _reservationDAO.GetAllReservationsFromCustomerAsync(customerId);
        }

        public async Task<int> GetNumberOfAllReservationsForMatchFromCustomerAsync(string customerId, string matchId)
        {
            return await _reservationDAO.GetNumberOfAllReservationsForMatchFromCustomerAsync(customerId, matchId);
        }

        public async Task<bool> HasNoOtherMatchOnDay(string customerId, DateTime matchDate,string matchId)
        {
            return await _reservationDAO.HasNoOtherMatchOnDay(customerId, matchDate, matchId);
        }

        public async Task RemoveAsync(Reservation reservation)
        {
            await _reservationDAO.RemoveAsync(reservation);
        }
    }
}
