using System.Collections.Generic;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface IStadiumDAO
    {
        Task<IEnumerable<Stadium>> GetAllAsync();
    }
}
