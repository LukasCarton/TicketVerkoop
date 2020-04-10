using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class TeamService: ITeamService
    {
        private ITeamDAO _teamDAO;

        public TeamService(ITeamDAO teamDAO)
        {
            _teamDAO = teamDAO;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _teamDAO.GetAllAsync();
        }
    }
}
