using muchik.market.domain.bus;
using muchik.market.pay.application.dto.Creates;
using muchik.market.pay.application.events;
using muchik.market.pay.application.interfaces;

namespace muchik.market.pay.application.eventHandlers
{
    public class CreatePaymentEventHandler : IEventHandler<CreatePaymentEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IPaymentService _paymentService;

        public CreatePaymentEventHandler(IEventBus eventBus, IPaymentService paymentService) 
        {
            _eventBus = eventBus;
            _paymentService = paymentService;
        }
        
        public Task Handle(CreatePaymentEvent @event)
        {
            var paymentDto = new CreatePaymentDto
            {               
                Id_Invoice = @event.Id_Invoice,
                Amount = @event.Amount,
            };

            //var successPayment = _paymentService.CreatePayment(paymentDto);
            _paymentService.CreatePayment(paymentDto);

            return Task.CompletedTask;
        }
    }
}
