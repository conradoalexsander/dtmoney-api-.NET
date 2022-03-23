using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace DTMoney.Api.Data
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly DtMoneyDbContext _dbContext;

        public FinancialTransactionRepository(DtMoneyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteFinancialTransaction(int id)
        {
            if (await _dbContext.FinancialTransactions.SingleOrDefaultAsync(transaction => transaction.Id == id) is FinancialTransaction todo)
            {
                _dbContext.FinancialTransactions.Remove(todo);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<FinancialTransaction> GetFinancialTransaction(int id)
        {
            return await GetSingleAsync(id);
        }

        public async Task<bool> UpdateFinancialTransaction(FinancialTransaction inputTransaction)
        {
            var transaction = await _dbContext.FinancialTransactions.SingleOrDefaultAsync(transaction => transaction.Id == inputTransaction.Id);

            if (transaction == null)
                return false;

            transaction.Title = inputTransaction.Title;
            transaction.Amount = inputTransaction.Amount;
            transaction.Type = inputTransaction.Type;
            transaction.Category = inputTransaction.Category;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<FinancialTransaction>> GetAllFinancialTransaction()
        {
            return await _dbContext.FinancialTransactions.ToListAsync();
        }


        public async Task<FinancialTransaction> CreateFinancialTransaction(FinancialTransaction transaction)
        {
            _dbContext.FinancialTransactions.Add(transaction);
            await _dbContext.SaveChangesAsync();

            return await GetSingleAsync(transaction.Id);
        }

        private async Task<FinancialTransaction> GetSingleAsync(int id)
        {
            return await _dbContext.FinancialTransactions.SingleOrDefaultAsync(transaction => transaction.Id == id);
        }

    }
}
