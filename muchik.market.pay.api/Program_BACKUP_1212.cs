using Microsoft.EntityFrameworkCore;
using muchik.market.domain.bus;
using muchik.market.infrastructure.bus.settings;
using muchik.market.pay.application.eventHandlers;
using muchik.market.pay.application.events;
using muchik.market.pay.application.commandHandlers;
using muchik.market.pay.application.commands;
using muchik.market.pay.application.interfaces;
using muchik.market.pay.application.mappings;
using muchik.market.pay.application.services;
using muchik.market.pay.domain.interfaces;
using muchik.market.pay.infraestructure.context;
using muchik.market.pay.infraestructure.repositories;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

using muchik.market.infrastructure.ioc;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();
// Add services to the container.

var application = builder.Configuration.GetValue<string>("name", "Not found!");
var muchikConnection = builder.Configuration.GetValue<string>("connectionStrings:MuchikMarketConnection", "Not found!");



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<PaymentContext>(config =>
{
    config.UseMySQL(muchikConnection);
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IPaymentService, PaymentService>();

//Repositories
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

//Context
builder.Services.AddTransient<PaymentContext>();

//Commands & Events
//builder.Services.AddTransient<IEventHandler<CreatePaymentEvent>, CreatePaymentEventHandler>();
builder.Services.AddTransient<IRequestHandler<CreatePaymentCommand, bool>, CreatePaymentCommandHandler>();

//Subscriptions
//builder.Services.AddTransient<CreatePaymentEventHandler>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Consul
builder.Services.AddDiscoveryClient();


var app = builder.Build();

////Subscriptions
//var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<CreatePaymentEvent, CreatePaymentEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
