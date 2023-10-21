using muchik.market.domain.commands;

namespace muchik.market.invoice.application.commands
{
    public class PaymentCommand : Command
    {
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
    }
}
