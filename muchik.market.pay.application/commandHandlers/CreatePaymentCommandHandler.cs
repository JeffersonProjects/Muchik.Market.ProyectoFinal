using MediatR;
using muchik.market.domain.bus;
using muchik.market.pay.application.commands;
using muchik.market.pay.application.events;

namespace muchik.market.pay.application.commandHandlers
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
            //Cambia estado a pagado
            int requestState = 1; 

            _eventBus.Publish(new UpdateInvoiceEvent(
                request.Id_Invoice, 
                request.Amount,
                requestState
                ));

            string requestIdTrasantion = Guid.NewGuid().ToString("N");
            string requestIdInvoice = null;
            decimal requestAmount = 0;
            string requestDate = null;

            _eventBus.Publish(new RegisterTransactionEvent(
                requestIdTrasantion,
                requestIdInvoice = request.Id_Invoice.ToString(),
                requestAmount = request.Amount,
                requestDate = DateTime.UtcNow.ToString()
            ));

            return Task.FromResult(true);
        }
    }
}
