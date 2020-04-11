using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly ISubscriptionDAO _subscriptionDAO;

        public SubscriptionService(ISubscriptionDAO subscriptionDAO)
        {
            _subscriptionDAO = subscriptionDAO;
        }

        public async Task CreateAsync(Subscription subscription)
        {
            await _subscriptionDAO.CreateAsync(subscription);
        }

        public async Task<IEnumerable<Subscription>> GetAllCustomerSubscriptionAsync(string customerId)
        {
            return await _subscriptionDAO.GetAllCustomerSubscriptionAsync(customerId);
        }

        public async Task<Subscription> GetAsync(string customerId, string teamId)
        {
            return await _subscriptionDAO.GetAsync(customerId, teamId);
        }

        public async Task RemoveAsync(Subscription subscription)
        {
            await _subscriptionDAO.RemoveAsync(subscription);
        }
    }
}
