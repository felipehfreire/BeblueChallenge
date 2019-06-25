using Beblue.Domain.Interfaces;
using System.Threading.Tasks;

namespace Beblue.Domain.Sales.Repository
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task AddCustomer(Customer customer);
    }
}
