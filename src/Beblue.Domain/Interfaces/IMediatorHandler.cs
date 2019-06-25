using Beblue.Domain.Core.Commands;
using Beblue.Domain.Core.Events;
using System.Threading.Tasks;

namespace Beblue.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T Command) where T : Command;

        Task RaiseEvent<T>(T Event) where T : Event;
    }
}
