using Microsoft.EntityFrameworkCore;
using muchik.market.infrasctructure.crosscutting.Jwt;
using muchik.market.security.api.Middleware;
using muchik.market.security.application.interfaces;
using muchik.market.security.application.mappings;
using muchik.market.security.application.services;
using muchik.market.security.domain.interfaces;
using muchik.market.security.infraestructure.context;
using muchik.market.security.infraestructure.repositories;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();
// Add services to the container.
var application = builder.Configuration.GetValue<string>("name", "Not found!");
var muchikConnection = builder.Configuration.GetValue<string>("connectionStrings:muchikConnection","Not found!");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));
builder.Services.AddDbContext<SecurityContext>(config =>
{
    config.UseSqlServer(muchikConnection);
});

//Services
builder.Services.AddTransient<IUserService, UserService>();

//Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

////Cross-Cutting
builder.Services.AddTransient<IJwtManager, JwtManager>();

//Context
builder.Services.AddTransient<SecurityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
