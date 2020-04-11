using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface ISubscriptionDAO
    {
        Task<IEnumerable<Subscription>> GetAllCustomerSubscriptionAsync(string customerId);
        Task<Subscription> GetAsync(string customerId,string teamId);
        Task CreateAsync(Subscription subscription);
        Task RemoveAsync(Subscription subscription);
    }
}
