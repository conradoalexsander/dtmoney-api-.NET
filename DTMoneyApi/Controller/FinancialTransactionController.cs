using AutoMapper;
using DTMoney.Api.Data;
using DTMoney.Api.DTO;
using DTMoney.Api.Extensions;
using DTMoney.Api.Model;
using FluentValidation;

namespace DTMoney.Api.Controller
{
    public static class FinancialTransactionController
    {
        public static void RegisterFinancialTransactionController(this WebApplication app)
        {

            app.MapGet("/transactions", GetAllTransactions);

            app.MapGet("/transactions/{id}", GetTransactionById);

            app.MapGet("/transactions/types", GetTransactionTypes);

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

        private static async Task<IResult> CreateTransaction(
            FinancialTransactionDTO inputTransaction,
            IFinancialTransactionRepository repository,
            IMapper mapper,
            IValidator<FinancialTransactionDTO> validator)
        {
            var validationResult = validator.Validate(inputTransaction);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToValidationProblems());
            }

            var mappedTransaction = mapper.Map<FinancialTransaction>(inputTransaction);

            var transaction = await repository.CreateFinancialTransaction(mappedTransaction);

            return Results.Created($"/transactions/{transaction.Id}", transaction);
        }

        private static async Task<IResult> UpdateTransaction(int id, FinancialTransactionDTO inputTransaction, IFinancialTransactionRepository repository, IMapper mapper)
        {
            var mappedTransaction = mapper.Map<FinancialTransaction>(inputTransaction);
            mappedTransaction.Id = id;

            return await repository.UpdateFinancialTransaction(mappedTransaction)
                ? Results.NoContent()
                : Results.NotFound();
        }

        private static async Task<IResult> GetTransactionTypes()
        {
            return Results.Ok(Enum.GetNames(typeof(FinancialTransactionType)));
        }

        private static async Task<IResult> DeleteTransactionById(int id, IFinancialTransactionRepository repository)
        {
            return await repository.DeleteFinancialTransaction(id)
                ? Results.NoContent()
                : Results.NotFound();
        }

    }
}
