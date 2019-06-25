using Beblue.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beblue.Application.Interfaces
{
    public interface IDiscAppService : IDisposable
    {
        Task Add(DiscViewModel entity);
        Task<DiscViewModel> GetById(int id);
        Task<List<DiscViewModel>> GetAll();
        Task Remove(int id);
        Task<List<DiscViewModel>> GetDiscPagedAsync(string genre,int page, int size);
    }
}
