using DTMoney.Api.Data;

namespace DTMoney.Api.Model
{
    public class FinancialTransaction : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public FinancialTransactionType Type { get; set; }

    }
}
