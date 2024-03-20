using System.Net;
using UserService.Application.Abstractions.Exceptions;

namespace UserService.API.Middlewares;

/// <summary>
/// Middleware обработки ошибок
/// </summary>
/// <param name="next">Функция, которая может обрабатывать HTTP-запрос.</param>
public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    /// <summary>
    /// Метод выполнения 
    /// </summary>
    /// <param name="context">HttpContext</param>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            //сообщение об ошибке
            string? message;
            
            //код ошибки
            var statusCode = (int)HttpStatusCode.BadRequest;
            
            switch (exception)
            {
                
                //исключения использующийся в случае отсутствию пользователя с искомым Id
                case UserNotFoundException ex:
                    message = $"Пользователь {ex.Id} не найден";
                    break;
                
                //исключения для ситуации когда не найдена организации по id
                case OrganizationNotFoundException ex:
                    message = $"Организация {ex.Id} не найдена";
                    break;
                
                //исключения для ситуации если в организации пользователь с указанным id уже существует
                case UserAlreadyInOrganizationException ex:
                    message = $"Пользователь {ex.IdUser} уже находится в организации \"{ex.Name}\"";
                    break;
                
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = $"Ошибка при выполнении запроса: {exception.Message}";
                    logger.LogError(exception, "Возникла ошибка при обработке запроса");
                    break;
            }

            //устанавливаем код ошибки
            context.Response.StatusCode = statusCode;
            
            //Запишет указанное значение в формате JSON в тело ответа
            await context.Response.WriteAsJsonAsync(new { Errors = new[] { message } });
        }
    }
}