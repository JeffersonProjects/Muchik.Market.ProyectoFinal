using muchik.market.domain.events;

namespace muchik.market.transaction.application.events
{
    public class RegisterTransactionEvent : Event
    {
        public string? Id_Transaction { get; set; }
        public string? Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string? Date { get; set; }

        public RegisterTransactionEvent(string id_transaction, string id_Invoice, decimal amount, string date)
        {
            Id_Transaction = id_transaction;
            Id_Invoice = id_Invoice;
            Amount = amount;
            Date = date;
        }
    }
}
