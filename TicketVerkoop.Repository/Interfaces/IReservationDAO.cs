using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface IReservationDAO
    {
        Task CreateAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservationsFromCustomerAsync(string customerId);
        Task<int> GetNumberOfAllReservationsForMatchFromCustomerAsync(string customerId, string matchId);
        Task<bool> HasNoMatchOnDay(string customerId, DateTime matchDate);
        Task RemoveAsync(Reservation reservation);
        Task<Reservation> FindById(string Id);

    }
}
