using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Service.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetAsync(string name);
    }
}
