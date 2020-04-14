using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class SeasonService: ISeasonService
    {
        private ISeasonDAO _seasonDAO;

        public SeasonService(ISeasonDAO seasonDAO)
        {
            _seasonDAO = seasonDAO;
        }

        public Task<Season> GetNextSeasonAsync()
        {
            return _seasonDAO.GetNextSeasonAsync();
        }
    }
}
