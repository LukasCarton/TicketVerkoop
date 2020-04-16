using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Repository.Interfaces
{
    public interface ISeasonDAO
    {
        Task<Season> GetNextSeasonAsync();
    }
}
