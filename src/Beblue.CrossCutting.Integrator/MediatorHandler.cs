using Beblue.Domain.Core.Commands;
using Beblue.Domain.Core.Events;
using Beblue.Domain.Interfaces;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Beblue.CrossCutting.Integrator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
