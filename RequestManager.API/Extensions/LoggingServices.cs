using Serilog;

namespace RequestManager.API.Extensions;

/// <summary>
/// Статический класс для регистрации сервиса Serilog в контейнере DI 
/// </summary>
public static class LoggingServices
{
    /// <summary>
    /// Метод регистрирует сервис Serilog в контейнере DI 
    /// </summary>
    /// <param name="builder">Построитель веб-приложений и сервисов.</param>
    public static void AddLoggingServices(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}