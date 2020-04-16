using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerDAO _customerDAO;

        public CustomerService(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        public async Task AddAsync(Customer entity)
        {
            await _customerDAO.AddAsync(entity);
        }

        public async Task<Customer> GetAsync(string id)
        {
            return await _customerDAO.GetAsync(id);
        }
    }
}
