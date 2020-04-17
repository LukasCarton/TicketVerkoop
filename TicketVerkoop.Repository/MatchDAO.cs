using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    .Where(m => m.MatchDate >= DateTime.Now)
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.HomeTeam.Stadium)
                    .Include(m => m.AwayTeam)
                    .OrderBy(m => m.MatchDate)
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
                    .Where(m => m.MatchDate >= DateTime.Now && m.MatchDate <= DateTime.Now.AddMonths(1))
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.HomeTeam.Stadium)
                    .Include(m => m.AwayTeam)
                    .OrderBy(m => m.MatchDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Match>> GetAllByTeamOneMonth(string teamId)
        {
            try
            {
                return await _dbContext.Matches.Where(m => m.HomeTeamId == teamId || m.AwayTeamId == teamId)
                    .Where(m => m.MatchDate >= DateTime.Now && m.MatchDate <= DateTime.Now.AddMonths(1))
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.HomeTeam.Stadium)
                    .Include(m => m.AwayTeam)
                    .OrderBy(m => m.MatchDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Match>> GetAllByTeam(string teamId)
        {
            try
            {
                return await _dbContext.Matches.Where(m => m.HomeTeamId == teamId || m.AwayTeamId == teamId)
                    .Where(m => m.MatchDate >= DateTime.Now)
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.HomeTeam.Stadium)
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
                    .Include(m => m.Season)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.HomeTeam.Stadium)
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
