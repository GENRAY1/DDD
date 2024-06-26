using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Contracts.Organization.Validators;
using UserService.API.Contracts.Organization;
using UserService.API.Contracts.User;
using UserService.Application.Abstractions.Commands;
using UserService.Application.Abstractions.Queries;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/Users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator <OrganizationUpdateRequest> _validatorOrganizationUpdateRequest;
    public UserController(IMediator mediator, IValidator <OrganizationUpdateRequest> validatorOrganizationUpdateRequest)
    {
        _mediator = mediator;
        _validatorOrganizationUpdateRequest = validatorOrganizationUpdateRequest;
    }
    [Route("WithoutOrganization")]
    [HttpGet]
    public async Task<IActionResult> GetUsersWithoutOrganization(int page = 1, int countPerPage = 15, CancellationToken token = default)
    {
        var skip = (page - 1) * countPerPage;
        var users = await _mediator.Send(new GetUsersWithoutOrganizationQuery(skip, countPerPage), token);
        var usersResponse = users.Select(u => new UserGetResponse(
            Id: u.Id,
            FirstName: u.FirstName,
            LastName: u.LastName,
            Patronymic: u.Patronymic,
            PhoneNumber: u.PhoneNumber,
            Email: u.Email)).ToArray();
        return Ok(usersResponse);
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
        var usersResponse = users.Select(u => new UserGetResponse(
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
    public async Task<IActionResult> AddToOrganization(OrganizationUpdateRequest model, CancellationToken token)
    {
        
        var validationResult = await _validatorOrganizationUpdateRequest.ValidateAsync(model, token);

        if (!validationResult.IsValid)
        {
            //если данные не валидны, отправляем BadRequest
            return BadRequest(new
            {
                Errors = validationResult.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToArray()
            });
        }
        
        
        //отправляем запрос на связывание пользователя с организацией
        await _mediator.Send(new AddUserToOrganizationCommand(model.Userid!.Value, model.OrganizationId!.Value), token);
        
        //возвращаем 200
        return Ok();
    }
    
}