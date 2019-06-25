using Beblue.Data.Context;
using Beblue.Domain.Sales;
using Beblue.Domain.Sales.Repository;
using System.Threading.Tasks;

namespace Beblue.Data.Repositorys
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(BeblueContext context) : base(context)
        {
        }

        public async Task AddCustomer(Customer customer)
        {
            await Db.Customers.AddAsync(customer);
        }

        public async  Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await Db.Customers.FindAsync(customerId);
        }
    }
}
