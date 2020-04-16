using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Service.Interfaces
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> GetAllCustomerSubscriptionAsync(string customerId);
        Task<Subscription> GetAsync(string customerId, string teamId);
        Task CreateAsync(Subscription subscription);
        Task RemoveAsync(Subscription subscription);

    }
}
