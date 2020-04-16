using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class MatchService : IMatchService
    {

        private IMatchDAO _matchDAO;

        public MatchService(IMatchDAO matchDAO)
        {
            _matchDAO = matchDAO;
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _matchDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Match>> GetAllByHomeTeam(string homeTeamId)
        {
            return await _matchDAO.GetAllByHomeTeam(homeTeamId);
        }

        public async Task<IEnumerable<Match>> GetAllByTeam(string teamId)
        {
            return await _matchDAO.GetAllByTeam(teamId);
        }

        public async Task<Match> GetAsync(string id)
        {
            return await _matchDAO.GetAsync(id);
        }
    }
}
