using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class TeamDAO: ITeamDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public TeamDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Teams.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
