using muchik.market.domain.bus;
using muchik.market.invoice.application.dto.Creates;
using muchik.market.invoice.application.interfaces;
using muchik.market.invoice.application.services;

namespace muchik.market.invoice.application.events
{
    public class UpdateInvoiceEventHandler : IEventHandler<UpdateInvoiceEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IInvoiceService _invoiceService;

        public UpdateInvoiceEventHandler(IEventBus eventBus, IInvoiceService invoiceService) 
        {
            _eventBus = eventBus;
            _invoiceService = invoiceService;
        }
        
        public Task Handle(UpdateInvoiceEvent @event)
        {
            var invoiceDto = new UpdateInvoiceDto
            {               
                Id_Invoice = @event.Id_Invoice,
                Amount = @event.Amount,
                State = 1, //Se actualiza a estado 1 = Pagado. //@event.State,
            };

            _invoiceService.UpdateInvoice(invoiceDto);

            return Task.CompletedTask;
        }
    }
}
