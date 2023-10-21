using muchik.market.domain.events;

namespace muchik.market.invoice.application.events
{
    public class UpdateInvoiceEvent : Event
    {
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public int State { get; set; }

        public UpdateInvoiceEvent(int id_Invoice, decimal amount, int state)
        {
            Id_Invoice = id_Invoice;
            Amount = amount;
            State = state;
        }
    }
}
