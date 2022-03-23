namespace DTMoney.Api.DTO
{
    public class FinancialTransactionDTO
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
    }
}
