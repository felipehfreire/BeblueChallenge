using System.Threading.Tasks;
using Beblue.Data.Context;
using Beblue.Domain.Interfaces;
namespace Beblue.Data.UOW
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly BeblueContext _context;

        public UnitOfWork(BeblueContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
