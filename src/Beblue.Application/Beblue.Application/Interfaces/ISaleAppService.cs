using Beblue.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beblue.Application.Interfaces
{
    public interface ISaleAppService : IDisposable
    {
        Task Add(SaleViewModel entity);
        Task<SaleViewModel> GetById(int id);
        Task<List<SaleViewModel>> GetSalesPagedAsync(DateTime initialDate, DateTime finalDate, int page, int size);
        Task AddCustomer(CustomerViewModel customerViewModel);
    }
}
