using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Discs.Repository;
using Beblue.Domain.Handlers;
using Beblue.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beblue.Domain.Discs.Commands
{
    public class DiscCommandHandler : CommandHandler,
        IRequestHandler<CreateDiscCommand, bool>
    {
        private readonly IMediatorHandler mediator;
        private readonly IDiscRepository discRepository;

        public DiscCommandHandler(IUnityOfWork uow, IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IDiscRepository discRepository) : base(uow, mediator, notifications)
        {
            this.mediator = mediator;
            this.discRepository = discRepository;
        }

        public async Task<bool> Handle(CreateDiscCommand message, CancellationToken cancellationToken)
        {

            var disc = Disc.DiscFactory.NewDisc(message.Name, message.Genre);

            if (!IsValid(disc)) return false;
            await discRepository.Add(disc);

            return await Commit();
        }

        private bool IsValid(Disc disc)
        {
            if (disc.IsValid()) return true;

            NotificationValidationErros(disc.ValidationResult);
            return false;
        }
    }
}
