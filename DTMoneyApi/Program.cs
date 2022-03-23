using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DtMoneyDb>(options => options.UseInMemoryDatabase("DtMoney"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/transactions", async (DtMoneyDb db) => await db.FinancialTransactions.ToListAsync());

app.MapGet("/transactions/{id}", async (int id, DtMoneyDb db) => 
    await db.FinancialTransactions.SingleOrDefaultAsync(transaction => transaction.Id == id)
        is FinancialTransaction transaction
            ? Results.Ok(transaction)
            : Results.NotFound()
);

app.MapPost("/transactions", async (FinancialTransaction transaction, DtMoneyDb db) =>
{
    db.FinancialTransactions.Add(transaction);
    await db.SaveChangesAsync();

    return Results.Created($"/transactions/{transaction.Id}", transaction);
});

app.MapPut("/transactions/{id}", async (int id, FinancialTransaction inputTransaction, DtMoneyDb db) =>
{
    var transaction = await db.FinancialTransactions.SingleOrDefaultAsync(transaction => transaction.Id == id);

    if (transaction is null) return Results.NotFound();

    transaction.Title = inputTransaction.Title;
    transaction.Amount = inputTransaction.Amount;
    transaction.Type = inputTransaction.Type;
    transaction.Category = inputTransaction.Category;   

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/transactions/{id}", async (int id, DtMoneyDb db) =>
{
    if (await db.FinancialTransactions.SingleOrDefaultAsync(transaction => transaction.Id == id) is FinancialTransaction todo)
    {
        db.FinancialTransactions.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});


app.Run();
