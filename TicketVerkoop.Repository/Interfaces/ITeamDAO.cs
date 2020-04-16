using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface ITeamDAO
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetAsync(string name);
    }
}
