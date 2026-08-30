FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY TaskManager.API/TaskManager.API.csproj TaskManager.API/
COPY TaskManager.Domain/TaskManager.Domain.csproj TaskManager.Domain/
COPY TaskManager.DTOs/TaskManager.DTOs.csproj TaskManager.DTOs/
COPY TaskManager.Infrastructure/TaskManager.Infrastructure.csproj TaskManager.Infrastructure/
COPY TaskManager.Services/TaskManager.Services.csproj TaskManager.Services/

RUN dotnet restore TaskManager.API/TaskManager.API.csproj

COPY TaskManager.API/ TaskManager.API/
COPY TaskManager.Domain/ TaskManager.Domain/
COPY TaskManager.DTOs/ TaskManager.DTOs/
COPY TaskManager.Infrastructure/ TaskManager.Infrastructure/
COPY TaskManager.Services/ TaskManager.Services/
WORKDIR /src/TaskManager.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskManager.API.dll"]