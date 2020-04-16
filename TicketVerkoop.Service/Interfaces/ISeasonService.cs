using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Service.Interfaces
{
    public interface ISeasonService
    {
        Task<Season> GetNextSeasonAsync();
    }
}
