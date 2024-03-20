using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Storage.Context;
using UserService.Domain.Abstractions.Repositories;
using UserService.Infrastructure.Storage.Repositories;
namespace UserService.API.Extensions;

/// <summary>
/// Статический класс для регистрации сервисов по работе с базой данных в контейнере DI 
/// </summary>
public static class StoreServices
{
    /// <summary>
    /// Метод регистрации сервисов по работе с базой данных в контейнере DI 
    /// </summary>
    public static void AddStoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        //получаем строку подключения к базе данных
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new Exception("ConnectionStrings:DefaultConnection");
        
        //регистрируем контекст базы данных
        services.AddDbContext<ApplicationDbContext>(config =>
        {
            //указываем провайдера базы данных со строкой подключения
            config.UseNpgsql(connectionString);
            config.EnableSensitiveDataLogging();
        });

        //регистрируем репозиторий для модели пользователя
        services.AddScoped<IUserRepository, UserRepository>();
        
        //регистрируем репозиторий для модели организации
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    }
}