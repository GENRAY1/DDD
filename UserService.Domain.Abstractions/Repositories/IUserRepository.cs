using UserService.Domain.UserAggregate;
namespace UserService.Domain.Abstractions.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Метод отдает пользователя по id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Отдает пользователя по id</returns>
    Task<User?> GetAsync(Guid id);
    
    /// <summary>
    /// Метод обновляет данные пользователя
    /// </summary>
    /// <param name="user">Объект описывающий пользователя</param>
    Task UpdateAsync(User user);
    
    /// <summary>
    /// Метод добавляет пользователя
    /// </summary>
    /// <param name="user">Объект описывающий пользователя</param>
    Task AddAsync(User user);
    
    /// <summary>
    /// Метод находит пользователей в соответствии с указанной организацией
    /// </summary>
    /// <param name="organizationId">Id организации</param>
    /// <param name="skip">Количество записей которые нужно пропустить</param>
    /// <param name="take">Количество записей которые нужно получить</param>
    /// <returns>Коллекция пользователей удовлетворяющих запросу</returns>
    Task<ICollection<User>> FindAsync(Guid? organizationId, int skip, int take);
}