using Serilog;
using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Storage.Context;
using UserService.Infrastructure.Storage.Models;
namespace UserService.API.Seed;

/// <summary>
/// Класс добавляющий начальные данные в базу данных
/// </summary>
public static class SeedDatabase
{
    /// <summary>
    /// Метод добавляющий начальные данные в базу данных
    /// </summary>
    /// <param name="builder">интерфейс в ASP.NET Core, который используется для настройки
    /// конвейера обработки запросов для веб-приложения</param>
    public static async Task SeedDatabaseAsync(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        
        
        if (!await context.Organizations.AnyAsync())
        {
            await context.Organizations.AddRangeAsync(Organizations);
        }

        if (!await context.Users.AnyAsync())
        {
            var rnd = new Random();
            foreach (var userModel in Users)
            {
                var orgId = Organizations[rnd.Next(0, Organizations.Count)].Id;
                userModel.OrganizationId = orgId;
            }

            await context.Users.AddRangeAsync(Users);
        }

        await context.SaveChangesAsync();
        Log.Information("Произведена первичная инициализация базы данных");
    }

    private static readonly List<OrganizationModel> Organizations =
    [
        new OrganizationModel { Id = Guid.NewGuid(), Name = "Техносервис Групп" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "ИнфоСофт" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "ПрогрессИТ" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "АвангардТех" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "СпектрСистем" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "ЭкспертСолюшнс" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "Инновационные Технологии" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "БизнесПартнер" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "СмартСолюшнс" },
        new OrganizationModel { Id = Guid.NewGuid(), Name = "МегаКорпорация" }
    ];

    private static readonly List<UserModel> Users =
    [
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович",
            PhoneNumber = "+79012345678", Email = "ivan.ivanov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Екатерина", LastName = "Смирнова", Patronymic = "Александровна",
            PhoneNumber = "+79123456789", Email = "ekaterina.smirnova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Алексей", LastName = "Петров",
            PhoneNumber = "+79234567890", Email = "aleksey.petrov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Ольга", LastName = "Соколова", Patronymic = "Николаевна",
            PhoneNumber = "+79345678901", Email = "olga.sokolova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Дмитрий", LastName = "Кузнецов", Patronymic = "Дмитриевич",
            PhoneNumber = "+79456789012", Email = "dmitriy.kuznetsov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Елена", LastName = "Васильева", Patronymic = "Алексеевна",
            PhoneNumber = "+79567890123", Email = "elena.vasilieva@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Александр", LastName = "Морозов", Patronymic = "Сергеевич",
            PhoneNumber = "+79678901234", Email = "aleksandr.morozov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Светлана", LastName = "Новикова", Patronymic = "Андреевна",
            PhoneNumber = "+79789012345", Email = "svetlana.novikova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Михаил", LastName = "Федоров", Patronymic = "Михайлович",
            PhoneNumber = "+79890123456", Email = "mikhail.fedorov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Анна", LastName = "Морозова", Patronymic = "Игоревна",
            PhoneNumber = "+79901234567", Email = "anna.morozova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Сергей", LastName = "Волков", PhoneNumber = "+78011234567",
            Email = "sergey.volkov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Мария", LastName = "Козлова", Patronymic = "Андреевна",
            PhoneNumber = "+78121234567", Email = "maria.kozlova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Андрей", LastName = "Лебедев", Patronymic = "Александрович",
            PhoneNumber = "+78231234567", Email = "andrey.lebedev@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Наталья", LastName = "Семенова", Patronymic = "Ивановна",
            PhoneNumber = "+78341234567", Email = "natalya.semenova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Игорь", LastName = "Егоров", PhoneNumber = "+78451234567",
            Email = "igor.egorov@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Евгения", LastName = "Павлова", Patronymic = "Анатольевна",
            PhoneNumber = "+78561234567", Email = "evgeniya.pavlova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Алексей", LastName = "Сергеев", Patronymic = "Андреевич",
            PhoneNumber = "+78671234567", Email = "aleksey.sergeev@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Татьяна", LastName = "Волкова",
            PhoneNumber = "+78781234567", Email = "tatiana.volkova@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Владимир", LastName = "Кузьмин", Patronymic = "Владимирович",
            PhoneNumber = "+78891234567", Email = "vladimir.kuzmin@example.com"
        },
        new UserModel
        {
            Id = Guid.NewGuid(), FirstName = "Елена", LastName = "Макарова", Patronymic = "Александровна",
            PhoneNumber = "+78991234567", Email = "elena.makarova@example.com"
        }
    ];
}