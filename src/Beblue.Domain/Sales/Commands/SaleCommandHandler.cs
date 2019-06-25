using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Discs.Repository;
using Beblue.Domain.Handlers;
using Beblue.Domain.Interfaces;
using Beblue.Domain.Sales.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beblue.Domain.Sales.Commands
{
    public class SaleCommandHandler : CommandHandler,
        IRequestHandler<CreateSaleCommand, bool>,
        IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IMediatorHandler mediator;
        private readonly ISaleRepository saleRepository;
        private readonly IDiscRepository discRepository;

        public SaleCommandHandler(IUnityOfWork uow, IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            ISaleRepository saleRepository, IDiscRepository discRepository) : base(uow, mediator, notifications)
        {
            this.mediator = mediator;
            this.saleRepository = saleRepository;
            this.discRepository = discRepository;
        }

        public async Task<bool> Handle(CreateSaleCommand message, CancellationToken cancellationToken)
        {
            var sale = Sale.SaleFactory.NewSale(message.CustomerId);
            var customer =await  saleRepository.GetCustomerByIdAsync(sale.CustomerId);
            if (customer == null)
            {
                await mediator.RaiseEvent(new DomainNotification(message.MessageType, $"Não existe Cliente cadastrado como o id: {message.CustomerId}"));
                return false;
            }
            sale.SetCustomer(customer);
            sale.SetSaleItems(message.Items);

            foreach (var item in sale.Items)
            {
                var disc = await discRepository.GetById(item.DiscId);
                if (disc == null)
                {
                    await mediator.RaiseEvent(new DomainNotification(message.MessageType, $"Não existe nenhum Disco cadastrado como o id: {item.DiscId}"));
                    return false;
                }
                if (!IsValid(item)) return false;
                item.SetDependencies(sale, disc.Id);
                item.ComputeCashBack(disc);
            }

            if (!IsValid(sale)) return false;
            await saleRepository.Add(sale);

            return await Commit();
        }

        public async Task<bool> Handle(CreateCustomerCommand message, CancellationToken cancellationToken)
        {
            var customer = Customer.CustomerFactory.NewCustomer(message.Name);

            if (!IsValid(customer)) return false;
            await saleRepository.AddCustomer(customer);

            return await Commit();
        }

        private bool IsValid(Sale sale)
        {
            if (sale.IsValid()) return true;

            NotificationValidationErros(sale.ValidationResult);
            return false;
        }

        private bool IsValid(Customer customer)
        {
            if (customer.IsValid()) return true;

            NotificationValidationErros(customer.ValidationResult);
            return false;
        }

        private bool IsValid(OrderItem orderItem)
        {
            if (orderItem.IsValid()) return true;

            NotificationValidationErros(orderItem.ValidationResult);
            return false;
        }
    }
}
