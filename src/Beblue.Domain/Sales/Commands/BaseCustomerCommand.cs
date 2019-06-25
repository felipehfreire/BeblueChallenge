using Beblue.Domain.Core.Commands;

namespace Beblue.Domain.Sales.Commands
{
    public abstract class BaseCustomerCommand : Command
    {
        public string Name{ get; protected set; }

    }
}
