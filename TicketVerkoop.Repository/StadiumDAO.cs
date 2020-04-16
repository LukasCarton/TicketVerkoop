using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class StadiumDAO : IStadiumDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public StadiumDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }


        public async Task<IEnumerable<Stadium>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Stadia.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
