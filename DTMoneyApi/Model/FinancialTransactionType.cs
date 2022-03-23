using System.Runtime.Serialization;

namespace DTMoney.Api.Model
{
    public enum FinancialTransactionType
    {
        [EnumMember(Value="deposit")]
        DEPOSIT,

        [EnumMember(Value = "withdraw")]
        WITHDRAW
    }
}