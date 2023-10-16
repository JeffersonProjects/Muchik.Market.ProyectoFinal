using muchik.market.transaction.application.interfaces;
using muchik.market.transaction.application.mappings;
using muchik.market.transaction.application.services;
using muchik.market.transaction.domain.entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//MongoDB
builder.Services.Configure<TransactionsStoreDatabaseSettings>(
    builder.Configuration.GetSection("TransacctionsStoreDatabase"));

builder.Services.AddSingleton<ITransactionsService, TransactionsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
