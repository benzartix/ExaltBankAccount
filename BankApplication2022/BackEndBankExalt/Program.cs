using Application.AccountServices.CRUD;
using Application.AccountServices.Operations;
using Application.TransactionsServices.CRUD;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Persistance;
using Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlite(connectionString));

// Add dependencies
builder.Services.AddScoped<GetByIdAccount>();
builder.Services.AddScoped<AddAccount>();
builder.Services.AddScoped<AddTransaction>();
builder.Services.AddScoped<DepositFund>();
builder.Services.AddScoped<RetraitFunds>();
builder.Services.AddScoped<UpdateAccount>();
builder.Services.AddScoped<DeleteAccount>();
builder.Services.AddScoped<ListAllAccount>();
builder.Services.AddScoped<ListAllTransactionByAccount>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
