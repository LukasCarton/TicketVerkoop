using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface IMatchSectionDAO
    {
        Task<IEnumerable<MatchSection>> GetAllByStadiumAsync(string stadiumId);
        Task<MatchSection> FindById(string Id);
        Task<IEnumerable<MatchSection>> GetAllByMatchAsync(string matchId);

    }
}
