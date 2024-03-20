using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Contracts;
using UserService.Application.Abstractions.Commands;
using UserService.Application.Abstractions.Queries;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/Users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsers(Guid? organizationId, int page = 1, int countPerPage = 15,
        CancellationToken token = default)
    {
        //получаем число пропущенных записей
        var skip = (page - 1) * countPerPage;
        
        //отправляем запрос на получение пользователей у указанной организации
        var users = await _mediator.Send(new GetUsersQuery(organizationId, skip, countPerPage), token);
        
        //получаем записи пользователей в виде UserViewModel
        var usersResponse = users.Select(u => new UserResponseModel(
            Id: u.Id,
            FirstName: u.FirstName,
            LastName: u.LastName,
            Patronymic: u.Patronymic,
            PhoneNumber: u.PhoneNumber,
            Email: u.Email)).ToArray();
        
        //Отдаем результат запроса
        return Ok(usersResponse);
    }
    /// <summary>
    /// Метод позволяет связать пользователя с организацией 
    /// </summary>
    /// <param name="model">Модель запроса на связывание пользователя с организацией</param>
    /// <param name="token">Токен для отмены операции</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> AddToOrganization(OrganizationRequestModel model, CancellationToken token)
    {
        /*
        //получаем результат валидации
        var validationResult = await _validatorAddToOrganizationInput.ValidateAsync(model, token);

        if (!validationResult.IsValid)
        {
            //если данные не валидны, отправляем BadRequest
            return BadRequest(new
            {
                Errors = validationResult.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToArray()
            });
        }
        */
        
        //отправляем запрос на связывание пользователя с организацией
        await _mediator.Send(new AddUserToOrganizationCommand(model.Userid!.Value, model.OrganizationId!.Value), token);
        
        //возвращаем 200
        return Ok();
    }
    
}