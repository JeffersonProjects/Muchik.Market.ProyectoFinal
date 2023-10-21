namespace muchik.market.pay.application.commands
{
    public class CreatePaymentCommand : PaymentCommand
    {
        public CreatePaymentCommand(int id_invoice, decimal amount) 
        {
            Id_Invoice = id_invoice;
            Amount = amount;

    }
    }
}
