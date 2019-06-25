using System.Threading.Tasks;

namespace Beblue.Domain.Core.Events
{
    public interface IHandler<T> where T : Message
    {
        Task Handle(T message);
    }
}
