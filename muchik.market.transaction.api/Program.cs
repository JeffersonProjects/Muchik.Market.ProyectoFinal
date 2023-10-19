using muchik.market.transaction.application.interfaces;
using muchik.market.transaction.application.mappings;
using muchik.market.transaction.application.services;
using muchik.market.transaction.domain.entities;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();
// Add services to the container.
var application = builder.Configuration.GetValue<string>("name", "Not found!");
var muchikConnection = builder.Configuration.GetValue<string>("TransacctionsStoreDatabase:ConnectionString", "Not found!");
var muchikConnection1 = builder.Configuration.GetSection("TransacctionsStoreDatabase");
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
