using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface ISectionDAO
    {
        Task<IEnumerable<Section>> GetAllAsync();
        Task<IEnumerable<Section>> GetAllByStadiumAsync(string stadiumId);
        Task<Section> FindById(string sectionId);
    }
}
