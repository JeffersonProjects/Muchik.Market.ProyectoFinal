namespace muchik.market.pay.application.dto
{
    public class PaymentDto
    {
        public int Id_Operation { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
