using muchik.market.domain.bus;
using muchik.market.invoice.application.dto.Creates;
using muchik.market.invoice.application.interfaces;
using muchik.market.invoice.application.services;

namespace muchik.market.invoice.application.events
{
    public class CreateInvoiceEventHandler : IEventHandler<CreateInvoiceEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IInvoiceService _invoiceService;

        public CreateInvoiceEventHandler(IEventBus eventBus, IInvoiceService invoiceService) 
        {
            _eventBus = eventBus;
            _invoiceService = invoiceService;
        }
        
        public Task Handle(CreateInvoiceEvent @event)
        {
            var invoiceDto = new CreateInvoiceDto
            {               
                Amount = @event.Amount,
                State = @event.State,
            };

            _invoiceService.CreateInvoice(invoiceDto);

            return Task.CompletedTask;
        }
    }
}
