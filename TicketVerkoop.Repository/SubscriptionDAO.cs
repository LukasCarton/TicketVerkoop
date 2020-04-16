using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class SubscriptionDAO : ISubscriptionDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public SubscriptionDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task CreateAsync(Subscription subscription)
        {
            _dbContext.Entry(subscription).State = EntityState.Added;
            var section = await _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == subscription.SectionId);
            section.OccupiedSubscriptionSeats++;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(Subscription subscription)
        {
            _dbContext.Subscriptions.Remove(subscription);
            var section = await _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == subscription.SectionId);
            section.OccupiedSubscriptionSeats--;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Subscription>> GetAllCustomerSubscriptionAsync(string customerId)
        {
            try
            {
                return await _dbContext.Subscriptions
                .Where(s => s.CustomerId == customerId)
                .Include(s => s.Customer)
                .Include(s => s.Season)
                .Include(s => s.Team)
                .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<Subscription> GetAsync(string customerId, string teamId)
        {
            try
            {
                return await _dbContext.Subscriptions
                .Where(s => s.CustomerId == customerId)
                .Where(s => s.TeamId == teamId)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
