using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using muchik.market.api.gateway.Middlewares;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Stelltoe Config Server
builder.AddConfigServer();

//Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddPolly();

//Consul
builder.Services.AddDiscoveryClient();
var ValidIssuer = builder.Configuration["jwtSettings:issuer"];
var ValidAudience = builder.Configuration["jwtSettings:audience"];
var IssuerSigningKey = builder.Configuration["jwtSettings:secretKey"];

// Add services to the container.
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["jwtSettings:issuer"],
            ValidAudience = builder.Configuration["jwtSettings:audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtSettings:secretKey"]))
        };
    }
);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<AuthorizationMiddleware>();

app.UseOcelot().Wait();

app.Run();

