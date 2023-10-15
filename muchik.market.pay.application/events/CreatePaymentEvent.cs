using muchik.market.domain.events;

namespace muchik.market.pay.application.events
{
    public class CreatePaymentEvent : Event
    {
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }

        public CreatePaymentEvent(int id_Invoice, decimal amount)
        {
            Id_Invoice = id_Invoice;
            Amount = amount;
        }
    }
}
