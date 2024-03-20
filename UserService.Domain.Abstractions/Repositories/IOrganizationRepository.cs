using UserService.Domain.OrganizationAggregate;

namespace UserService.Domain.Abstractions.Repositories;

public interface IOrganizationRepository
{
    // <summary>
    /// Метод отдает организацию по Id
    /// </summary>
    /// <param name="id">Id организации</param>
    /// <returns>Отдает организацию по Id</returns>
    Task<Organization?> GetAsync(Guid id);
    
    /// <summary>
    /// Метод обновляет данные организации
    /// </summary>
    /// <param name="organization">Объект описывающий организацию</param>
    Task UpdateAsync(Organization organization);
    
    /// <summary>
    /// Метод добавляет организацию
    /// </summary>
    /// <param name="organization">Объект описывающий организацию</param>
    /// <returns></returns>
    Task AddAsync(Organization organization);
    
    /// <summary>
    /// Метод находит организации
    /// </summary>
    /// <param name="skip">Количество записей которые нужно пропустить</param>
    /// <param name="take">Количество записей которые нужно получить</param>
    /// <returns>Коллекция организаций удовлетворяющих запросу</returns>
    Task<ICollection<Organization>> FindAsync(int skip, int take);
}