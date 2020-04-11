using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class SectionService: ISectionService
    {
        private ISectionDAO _sectionDAO;

        public SectionService(ISectionDAO sectionDAO)
        {
            _sectionDAO = sectionDAO;
        }

        public async Task<IEnumerable<Section>> GetAllAsync()
        {
            return await _sectionDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Section>> GetAllByStadiumAsync(string stadiumId)
        {
            return await _sectionDAO.GetAllByStadiumAsync(stadiumId);
        }
    }
}
