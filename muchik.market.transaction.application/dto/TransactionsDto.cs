namespace muchik.market.transaction.application.dto
{
    public class TransactionsDto
    {
        public string? Id_Transaction { get; set; }
        public string? Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string? Date { get; set; }
    }
}
