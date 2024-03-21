using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestManager.API.Contracts.User;
using RequestManager.Application.Abstractions.Commands;

namespace RequestManager.API.Controllers;

/// <summary>
/// Контроллер управления пользователем
/// </summary>
/// <param name="mediator">Посредник</param>
/// <param name="validatorAddUserInput">Валидатор для AddUserInputModel</param>
[ApiController]
[Route("api/[controller]")]
public class UserController(ISender mediator)
    : ControllerBase
{
    /// <summary>
    /// Метод добавления пользователя
    /// </summary>
    /// <param name="user">Модель для добавления пользователя</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Ответ 200</returns>
    [HttpPost]
    public async Task<IActionResult> AddUser(UserPostRequest user, CancellationToken token)
    {
        /*
        //получаем результат валидации
        var validationResult = await validatorAddUserInput.ValidateAsync(user, token);

        //если модель невалидна
        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Errors = validationResult.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToArray()
            });
        }
        */
        //Отправляем команду на добавление пользователя
        await mediator.Send(
            new AddUserCommand(user.FirstName!, user.LastName!, user.PhoneNumber!, user.Email!,
                user.Patronymic), token);

        //Отправляем 200
        return Ok();
    }
    
    
}