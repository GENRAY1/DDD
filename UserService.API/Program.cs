using UserService.API.Extensions;
using UserService.API.Middlewares;
using UserService.API.Seed;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Метод регистрирует сервис Serilog в контейнере DI 
builder.AddLoggingServices();

//Метод регистрирует сервис MassTransit в контейнере DI 
builder.Services.AddMassTransitServices(builder.Configuration);

//Метод регистрирует сервис MediatR в контейнере DI
builder.Services.AddMediatorServices();

//Метод регистрирует сервис FluentValidation в контейнере DI
//builder.Services.AddValidationServices();

//Метод регистрации сервисов по работе с базой данных в контейнере DI
builder.Services.AddStoreServices(builder.Configuration);

//Добавляет службы для контроллеров в указанную коллекцию IServiceCollection.
//Этот метод не регистрирует службы, используемые для представлений или страниц.
builder.Services.AddControllers();

//Метод регистрирует сервис Swagger в контейнере DI
builder.Services.AddSwaggerGen();

var app = builder.Build();
//app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();

await app.SeedDatabaseAsync();

app.Run();