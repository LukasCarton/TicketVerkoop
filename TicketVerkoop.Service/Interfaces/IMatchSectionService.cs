using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Service.Interfaces
{
    public interface IMatchSectionService
    {
        Task<IEnumerable<MatchSection>> GetAllByStadiumAsync(string stadiumId);
        Task<MatchSection> FindById(string Id);
        Task<IEnumerable<MatchSection>> GetAllByMatchAsync(string matchId);

    }
}
