using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface IMatchDAO
    {
        Task<IEnumerable<Match>> GetAllAsync();
        Task<Match> GetAsync(string id);
        Task<IEnumerable<Match>> GetAllByHomeTeam(string homeTeamId);
    }
}
