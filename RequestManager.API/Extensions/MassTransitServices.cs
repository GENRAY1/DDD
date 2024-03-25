using MassTransit;
using RabbitMQ.Client;
using RequestManager.Application.Abstractions.Producers;
using RequestManager.Infrastructure.Produce.Producers;
using Shared.Models;

namespace RequestManager.API.Extensions;

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
            x.UsingRabbitMq((context, cfg) =>
            {
                // Fanout Exchange
                cfg.Host(rmq);
                cfg.Publish<UserCreated>(c =>
                {
                    c.ExchangeType = ExchangeType.Fanout;
                });
                cfg.Publish<OrganizationCreated>(c =>
                {
                    c.ExchangeType = ExchangeType.Fanout;
                });
                
                // Direct Exchange
                cfg.Publish<UserCreatedByDirect>( c =>
                {
                    c.ExchangeType = ExchangeType.Direct;
                });
                
                // Topic Exchange 
                cfg.Publish<UserCreatedByTopic>(c =>
                {
                    c.ExchangeType = ExchangeType.Topic;
                });
                
                // Headers Exchange 
                cfg.Publish<UserCreatedByHeaders>(c =>
                {
                    c.ExchangeType = ExchangeType.Headers;
                });
            });
        });
        
        //Метод регистрирует сервис IUserProducers в контейнере DI 
        services.AddTransient<IUserProducers, UserProducers>();

        //Метод регистрирует сервис IOrganizationProducer в контейнере DI 
        services.AddTransient<IOrganizationProducer, OrganizationProducer>();
    }
}