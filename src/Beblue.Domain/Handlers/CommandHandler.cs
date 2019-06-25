using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Beblue.Domain.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnityOfWork _uow;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnityOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotificationValidationErros(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _mediator.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }



        protected async Task<bool> Commit()
        {

            if ( _notifications.HasNotifications()) return false;
            if (await _uow.Commit()) return true;

            await _mediator.RaiseEvent(new DomainNotification(MethodInfo.GetCurrentMethod().Name, "Erro ao salvar dados no banco"));
            return false;

        }
    }
}
