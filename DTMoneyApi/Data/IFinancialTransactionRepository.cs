using DTMoney.Api.Model;

namespace DTMoney.Api.Data
{
    public interface IFinancialTransactionRepository
    {
        Task<FinancialTransaction> GetFinancialTransaction(int id);
        Task<FinancialTransaction> CreateFinancialTransaction(FinancialTransaction transaction);
        Task<IEnumerable<FinancialTransaction>> GetAllFinancialTransaction();
        Task<bool> UpdateFinancialTransaction(FinancialTransaction transaction);
        Task<bool> DeleteFinancialTransaction(int id);
    }
}
