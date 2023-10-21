using muchik.market.domain.bus;
using muchik.market.transaction.application.eventHandlers;
using muchik.market.transaction.application.interfaces;
using muchik.market.transaction.application.mappings;
using muchik.market.transaction.application.services;
using muchik.market.transaction.domain.entities;
using Steeltoe.Extensions.Configuration.ConfigServer;
using muchik.market.transaction.application.events;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;
using muchik.market.infrastructure.bus.settings;
using muchik.market.infrastructure.ioc;
using muchik.market.transaction.infraestructure.repositories;
using muchik.market.transaction.domain.interfaces;
using muchik.market.transaction.infraestructure.context;

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

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<ITransactionsService, TransactionsService>();

//Repositories
builder.Services.AddTransient<ITransactionsRepository, TransactionsRepository>();

//Context
builder.Services.AddTransient<TransactionsContext>();

//Commands & Events
builder.Services.AddTransient<IEventHandler<RegisterTransactionEvent>, RegisterTransactionEventHandler>();

//Subscriptions
builder.Services.AddTransient<RegisterTransactionEventHandler>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

//Subscriptions
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<RegisterTransactionEvent, RegisterTransactionEventHandler>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
