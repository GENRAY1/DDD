using System.Configuration;
using MassTransit;
using UserService.Infrastructure.MassTransit.Consumers;

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
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rmq);
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}