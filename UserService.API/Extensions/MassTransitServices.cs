using System.Configuration;
using MassTransit;
using RabbitMQ.Client;
using Shared.Models;
using UserService.Infrastructure.Bus.Consumers;
using UserService.Infrastructure.Bus.Consumers.User;

namespace UserService.API.Extensions;

/// <summary>
/// Статический класс для регистрации сервиса MassTransit в контейнере DI 
/// </summary>
public static class MassTransitServices
{
    /// <summary>
    /// Метод регистрирует сервис MassTransit в контейнере DI 
    /// </summary>
    /// <param name="services">Абстракция, которая представляет коллекцию сервисов (зависимостей),
    /// используемых в приложении.</param>
    /// <param name="configuration">Интерфейс, предоставляющий доступ к конфигурации приложения.</param>
    /// <exception cref="ConfigurationErrorsException">Исключение, которое выдается при возникновении
    /// ошибки конфигурации.</exception>
    public static void AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Получаем строку подключения к RabbitMq
        var rmq = configuration.GetConnectionString("RabbitMq") ??
                  throw new Exception("ConnectionStrings:RabbitMq");
        
        //конфигурируем MassTransit
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserCreatedConsumer>();
            x.AddConsumer<UserCreatedByDirectConsumer>();
            x.AddConsumer<UserCreatedByHeadersConsumer>();
            x.AddConsumer<UserCreatedByTopicConsumer>();
            
            x.AddConsumer<OrganizationCreatedConsumer>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rmq);
                
                //fanout - type exchange
                cfg.ReceiveEndpoint("AddUserByFanout", e =>{
                    e.Consumer<UserCreatedConsumer>(context);
                    e.ConfigureConsumeTopology = false;
                    e.Bind<UserCreated>(c =>
                    {
                        c.ExchangeType = ExchangeType.Fanout;
                    });
                });
                cfg.ReceiveEndpoint("AddOrganizationByFanout", e =>{
                    e.Consumer<OrganizationCreatedConsumer>(context);
                    e.ConfigureConsumeTopology = false;
                    e.Bind<OrganizationCreated>(c =>
                    {
                        c.ExchangeType = ExchangeType.Fanout;
                    });
                });
                
                //direct - type exchange
                cfg.ReceiveEndpoint("AddUserByDirect", e =>{
                    e.Consumer<UserCreatedByDirectConsumer>(context);
                    e.ConfigureConsumeTopology = false;
                    e.Bind<UserCreatedByDirect>(c =>
                    {
                        c.ExchangeType = ExchangeType.Direct;
                        c.RoutingKey = "user-created";
                    });
                });
                //topic - type exchange
                cfg.ReceiveEndpoint(("AddUserByTopic"), e =>
                {
                    e.Consumer<UserCreatedByTopicConsumer>(context);
                    e.ConfigureConsumeTopology = false;
                    e.Bind<UserCreatedByTopic>(c =>
                    {
                        c.ExchangeType = ExchangeType.Topic;
                        c.RoutingKey = "user.*";
                    });
                });
                //headers - type exchange
                cfg.ReceiveEndpoint(("AddUserByHeader"), e =>
                {
                    e.Consumer<UserCreatedByHeadersConsumer>(context);
                    e.ConfigureConsumeTopology = false;
                    e.Bind<UserCreatedByHeaders>(c =>
                    {
                        c.ExchangeType = ExchangeType.Headers;
                        c.SetBindingArgument("x-match", "all");
                        c.SetBindingArgument("action", "create" );
                        c.SetBindingArgument("entity", "user");
                    });
                });
                
            });
        });
    }
}