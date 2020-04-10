using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class CustomerDAO : ICustomerDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public CustomerDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task AddAsync(Customer entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            try
            {
                await _dbContext.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> GetAsync(string id)
        {
            try
            {
                return await _dbContext.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
