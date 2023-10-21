using muchik.market.domain.bus;
using muchik.market.transaction.application.dto;
using muchik.market.transaction.application.events;
using muchik.market.transaction.application.interfaces;

namespace muchik.market.transaction.application.eventHandlers
{
    public class RegisterTransactionEventHandler : IEventHandler<RegisterTransactionEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly ITransactionsService _transactionsService;

        public RegisterTransactionEventHandler(IEventBus eventBus, ITransactionsService transactionsService) 
        {
            _eventBus = eventBus;
            _transactionsService = transactionsService;
        }
        
        public Task Handle(RegisterTransactionEvent @event)
        {
            var transactionDto = new TransactionsDto
            {               
                Id_Transaction = @event.Id_Transaction,
                Id_Invoice = @event.Id_Invoice,
                Amount = @event.Amount,
                Date = @event.Date,
            };

            _transactionsService.CreateTransactionsAsync(transactionDto);

            return Task.CompletedTask;
        }
    }
}
