using DTMoney.Api.Data;
using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace DTMoney.Api.Controller
{
    public static class FinancialTransactionController
    {
        public static void RegisterFinancialTransactionController(this WebApplication app)
        {

            app.MapGet("/transactions", GetAllTransactions);

            app.MapGet("/transactions/{id}", GetTransactionById);

            app.MapPost("/transactions", CreateTransaction);

            app.MapPut("/transactions/{id}", UpdateTransaction);

            app.MapDelete("/transactions/{id}", DeleteTransactionById);

        }

        private static async Task<IResult> GetAllTransactions(IFinancialTransactionRepository repository)
        {
            return Results.Ok(await repository.GetAllFinancialTransaction());
        }

        private static async Task<IResult> GetTransactionById(int id, IFinancialTransactionRepository repository)
        {
            return await repository.GetFinancialTransaction(id)
                                is FinancialTransaction transaction
                                    ? Results.Ok(transaction)
                                    : Results.NotFound();
        }

        private static async Task<IResult> CreateTransaction(FinancialTransaction inputTransaction, IFinancialTransactionRepository repository)
        {
            var transaction = await repository.CreateFinancialTransaction(inputTransaction);

            return Results.Created($"/transactions/{inputTransaction.Id}", transaction);
        }

        private static async Task<IResult> UpdateTransaction(FinancialTransaction inputTransaction, IFinancialTransactionRepository repository)
        {
            return await repository.UpdateFinancialTransaction(inputTransaction)
                ? Results.NoContent()
                : Results.NotFound();
        }

        private static async Task<IResult> DeleteTransactionById(int id, IFinancialTransactionRepository repository)
        {
            return await repository.DeleteFinancialTransaction(id)
                ? Results.NoContent()
                : Results.NotFound();
        }

    }
}
