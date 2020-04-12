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
    public class MatchDAO : IMatchDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public MatchDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Matches
                    .Include(m => m.Stadium)
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Match>> GetAllByHomeTeam(string homeTeamId)
        {
            try
            {
                return await _dbContext.Matches.Where(m => m.HomeTeamId == homeTeamId)
                    .Include(m => m.Stadium)
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .OrderBy(m => m.MatchDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Match> GetAsync(string id)
        {
            try
            {
                return await _dbContext.Matches.Where(m => m.Id == id)
                    .Include(m => m.Stadium)
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
