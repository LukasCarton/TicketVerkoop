using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;

namespace TicketVerkoop.Service.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<Match>> GetAllAsync();
        Task<Match> GetAsync(string id);

    }
}
