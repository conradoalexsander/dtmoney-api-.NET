using DTMoney.Api.Model;
using FluentValidation;

namespace DTMoney.Api.DTO
{
    public class FinancialTransactionDTO
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
    }

    public class FinancialTransactionValidator : AbstractValidator<FinancialTransactionDTO>
    {
        public FinancialTransactionValidator()
        {
            RuleFor(transaction => transaction.Type)
                .IsEnumName(typeof(FinancialTransactionType), caseSensitive: false)
                .WithMessage((transaction) => $"Invalid type. Provided value: {transaction.Type}, allowed types: {GetTransactionTypesStringMessage()}.");
        }

        private string GetTransactionTypesStringMessage()
        {
            var types = Enum.GetNames(typeof(FinancialTransactionType));

            return string.Join(", ", types);
        }
    }
}
