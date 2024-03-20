using FluentValidation;
using UserService.API.Contracts.Organization;
using UserService.API.Contracts.Organization.Validators;

//using UserService.InputModels;

namespace UserService.API.Extensions;



/// <summary>
/// Статический класс для регистрации сервиса FluentValidation в контейнере DI 
/// </summary>
public static class ValidationServices
{
    /// <summary>
    /// Метод регистрирует сервис FluentValidation в контейнере DI 
    /// </summary>
    /// <param name="services">Абстракция, которая представляет коллекцию сервисов (зависимостей),
    /// используемых в приложении.</param>
    public static void AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<OrganizationUpdateRequest>, OrganizationUpdateRequestValidator>();
    }
}