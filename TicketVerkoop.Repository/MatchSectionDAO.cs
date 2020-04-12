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
    public class MatchSectionDAO: IMatchSectionDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public MatchSectionDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task<IEnumerable<MatchSection>> GetAllByStadiumAsync(string stadiumId)
        {
            try
            {
                return await _dbContext.MatchSections
                    .Where(m => m.Section.Stadium.Id  == stadiumId)
                    .Include(m => m.Section)
                    .Include(m =>m.Match)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
