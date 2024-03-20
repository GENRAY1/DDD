using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Contracts.Organization;
using UserService.Application.Abstractions.Queries;

namespace UserService.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Метод отдает данные по организациям разбитым по страницам
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="countPerPage">Количество записей на странице</param>
    /// <param name="token">Токен для отмены операции</param>
    /// <returns>Отдает данные по организациям разбитым по страницам</returns>
    [HttpGet]
    public async Task<IActionResult> GetOrganizations(int page = 1, int countPerPage = 15,
        CancellationToken token = default)
    {
        //получаем количество записей для пропуска
        var skip = (page - 1) * countPerPage;
        
        //отправляем запрос для получения организаций
        var organizations = await _mediator.Send(new GetOrganizationsQuery(skip, countPerPage), token);
        
        //получаем список ViewModel организаций
        var organizationsModels = organizations.Select(o => new OrganizationGetResponse(
            Id: o.Id,
            Name: o.Name)).ToArray();
        
        //Возвращаем результат запроса
        return Ok(organizationsModels);
    }
}