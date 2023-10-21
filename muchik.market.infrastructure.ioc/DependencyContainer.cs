using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using muchik.market.domain.bus;
using muchik.market.infrastructure.bus;
using muchik.market.infrastructure.bus.settings;
using System.Reflection;

namespace muchik.market.infrastructure.ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Event Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(config =>
            {
                var mediatorFactory = config.GetService<IMediator>();
                var scopeFactory = config.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = config.GetService<IOptions<RabbitMqSettings>>();
                return new RabbitMqBus(mediatorFactory, scopeFactory, optionsFactory);
            });

            return services;
        }
    }
}
