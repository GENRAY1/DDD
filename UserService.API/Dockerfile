FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserService.API/UserService.API.csproj", "UserService.API/"]
COPY ["UserService.Application.Services/UserService.Application.Services.csproj", "UserService.Application.Services/"]
COPY ["UserService.Application.Abstractions/UserService.Application.Abstractions.csproj", "UserService.Application.Abstractions/"]
COPY ["UserService.Domain/UserService.Domain.csproj", "UserService.Domain/"]
COPY ["UserService.Domain.Abstractions/UserService.Domain.Abstractions.csproj", "UserService.Domain.Abstractions/"]
COPY ["UserService.Infrastructure.MassTransit/UserService.Infrastructure.MassTransit.csproj", "UserService.Infrastructure.MassTransit/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["UserService.Infrastructure.Storage/UserService.Infrastructure.Storage.csproj", "UserService.Infrastructure.Storage/"]
RUN dotnet restore "UserService.API/UserService.API.csproj"
COPY . .
WORKDIR "/src/UserService.API"
RUN dotnet build "UserService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UserService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.API.dll"]
