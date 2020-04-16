using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class StadiumService: IStadiumService
    {
        private IStadiumDAO _stadiumDAO;

        public StadiumService(IStadiumDAO stadiumDAO)
        {
            _stadiumDAO = stadiumDAO;
        }

        public async Task<IEnumerable<Stadium>> GetAllAsync()
        {
            return await _stadiumDAO.GetAllAsync();
        }
    }
}
