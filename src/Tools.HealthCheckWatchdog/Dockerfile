FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["src/Tools.HealthCheckWatchdog/Tools.HealthCheckWatchdog.csproj", "Tools.HealthCheckWatchdog/"]

RUN dotnet restore "Tools.HealthCheckWatchdog/Tools.HealthCheckWatchdog.csproj"
COPY . .

WORKDIR "/src/src/Tools.HealthCheckWatchdog"
RUN dotnet publish "Tools.HealthCheckWatchdog.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app /app
ENTRYPOINT ["dotnet", "Tools.HealthCheckWatchdog.dll"]
