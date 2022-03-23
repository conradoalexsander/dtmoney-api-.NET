namespace DTMoney.Api.Model
{
    public class FinancialTransaction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public FinancialTransactionType Type { get; set; }
    }
}
