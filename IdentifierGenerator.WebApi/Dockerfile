FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj", "IdentifierGenerator.WebApi/"]
COPY ["IdentifierGenerator.Bootstrap/IdentifierGenerator.Bootstrap.csproj", "IdentifierGenerator.Bootstrap/"]
COPY ["IdentifierGenerator.Infrastructure/IdentifierGenerator.Infrastructure.csproj", "IdentifierGenerator.Infrastructure/"]
COPY ["IdentifierGenerator.Domain/IdentifierGenerator.Domain.csproj", "IdentifierGenerator.Domain/"]
COPY ["IdentifierGenerator.Application/IdentifierGenerator.Application.csproj", "IdentifierGenerator.Application/"]
RUN dotnet restore "IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj"
COPY . .
WORKDIR "/src/IdentifierGenerator.WebApi"
RUN dotnet publish "IdentifierGenerator.WebApi.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app /app
ENTRYPOINT ["dotnet", "IdentifierGenerator.WebApi.dll"]
