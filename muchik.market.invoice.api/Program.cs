using Microsoft.EntityFrameworkCore;
using muchik.market.invoice.application.interfaces;
using muchik.market.invoice.application.mappings;
using muchik.market.invoice.application.services;
using muchik.market.invoice.domain.interfaces;
using muchik.market.invoice.infraestructure.context;
using muchik.market.invoice.infraestructure.repositories;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();
// Add services to the container.
var application = builder.Configuration.GetValue<string>("name", "Not found!");
var muchikConnection = builder.Configuration.GetValue<string>("connectionStrings:muchikConnection", "Not found!");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<InvoiceContext>(config =>
{
    config.UseNpgsql(muchikConnection);
});

////RabbitMQ Settings
//builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

////IoC
//builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

//Repositories
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();

//Context
builder.Services.AddTransient<InvoiceContext>();


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
