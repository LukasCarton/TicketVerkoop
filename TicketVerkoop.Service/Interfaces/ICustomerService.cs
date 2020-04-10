using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetAsync(string id);
        Task AddAsync(Customer entity);
    }
}
