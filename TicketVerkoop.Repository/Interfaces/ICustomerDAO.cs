using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface ICustomerDAO
    {
        Task<Customer> GetAsync(string id);
        Task AddAsync(Customer entity);
    }
}
