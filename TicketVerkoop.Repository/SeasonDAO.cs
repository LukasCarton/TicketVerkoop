using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class SeasonDAO: ISeasonDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public SeasonDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task<Season> GetNextSeasonAsync()
        {
            return await _dbContext.Seasons
                .Where(s => s.StartDate - DateTime.Now > TimeSpan.Zero)
                .OrderBy(s => s.StartDate)
                .FirstOrDefaultAsync();
        }
    }
}
