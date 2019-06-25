namespace Beblue.Domain.Sales.Commands
{
    public class CreateCustomerCommand : BaseCustomerCommand
    {
        public CreateCustomerCommand(string name)
        {
            this.Name = name;
        }
    }
}
