using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class MatchSectionService: IMatchSectionService
    {
        private IMatchSectionDAO _matchSectionDAO;

        public MatchSectionService(IMatchSectionDAO matchSectionDAO)
        {
            _matchSectionDAO = matchSectionDAO;
        }

        public async Task<IEnumerable<MatchSection>> GetAllByStadiumAsync(string stadiumId)
        {
            return await _matchSectionDAO.GetAllByStadiumAsync(stadiumId);
        }
    }
}
