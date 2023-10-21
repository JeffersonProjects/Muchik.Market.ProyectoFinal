using MediatR;
using muchik.market.domain.bus;
using muchik.market.invoice.application.commands;
using muchik.market.invoice.application.events;

namespace muchik.market.invoice.application.commandHandlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public CreatePaymentCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new CreatePaymentEvent(request.Id_Invoice, request.Amount));
            return Task.FromResult(true);
        }
    }
}
