using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface IReservationDAO
    {
        Task CreateAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservationsFromCustomerAsync(string customerId);
        Task<int> GetNumberOfAllReservationsForMatchFromCustomerAsync(string customerId, string matchId);
        Task<bool> HasNoOtherMatchOnDay(string customerId, DateTime matchDate,string matchId);
        Task RemoveAsync(Reservation reservation);
        Task<Reservation> FindById(string Id);

    }
}
