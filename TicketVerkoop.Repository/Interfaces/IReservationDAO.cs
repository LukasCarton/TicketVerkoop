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
        Task RemoveAsync(Reservation reservation);

    }
}
