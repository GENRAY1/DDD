using RequestManager.Application.Services.CommandsHandlers;

namespace RequestManager.API.Extensions;

/// <summary>
/// Статический класс для регистрации сервиса MediatR в контейнере DI 
/// </summary>
public static class MediatorServices
{
    /// <summary>
    /// Метод регистрирует сервис MediatR в контейнере DI 
    /// </summary>
    /// <param name="services">Абстракция, которая представляет коллекцию сервисов (зависимостей),
    /// используемых в приложении.</param>
    public static void AddMediatorServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(AddUserCommandHandler).Assembly);
        });
    }
}