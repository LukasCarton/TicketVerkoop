using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class SectionDAO: ISectionDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public SectionDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task<IEnumerable<Section>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Sections.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
