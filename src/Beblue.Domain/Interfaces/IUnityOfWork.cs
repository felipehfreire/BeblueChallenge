using System;
using System.Threading.Tasks;

namespace Beblue.Domain.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
