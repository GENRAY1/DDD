using RequestManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Метод регистрирует сервис Serilog в контейнере DI 
builder.AddLoggingServices();

//Метод регистрирует сервис MediatR в контейнере DI
builder.Services.AddMediatorServices();

//Метод регистрирует сервис MassTransit в контейнере DI 
builder.Services.AddMassTransitServices(builder.Configuration);

//Метод регистрирует сервис FluentValidation в контейнере DI
//builder.Services.AddValidationServices();

//Метод регистрирует сервис Swagger в контейнере DI 
builder.Services.AddSwaggerGen();

//Добавляет службы для контроллеров в указанную коллекцию IServiceCollection.
//Этот метод не регистрирует службы, используемые для представлений или страниц.
builder.Services.AddControllers();

//Сборка
var app = builder.Build();

//Регистрация промежуточного программного обеспечения Swagger с дополнительным
//действием настройки для опций, внедренных DI.
app.UseSwagger();

//Регистрация промежуточного программного обеспечения SwaggerUI с
//дополнительным действием настройки для параметров, внедренных с помощью DI.
app.UseSwaggerUI();

//Middleware обработки ошибок
//app.UseMiddleware<ExceptionMiddleware>();

//методом расширения  используется для настройки маршрутизации, использует
//контроллеры с атрибутами маршрутизации
app.MapControllers();

//Запускает приложение и блокирует вызывающий поток до завершения работы хоста.
app.Run();