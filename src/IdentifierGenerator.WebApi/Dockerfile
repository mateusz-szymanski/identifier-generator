FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["src/IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj", "IdentifierGenerator.WebApi/"]
COPY ["src/IdentifierGenerator.Infrastructure/IdentifierGenerator.Infrastructure.csproj", "IdentifierGenerator.Infrastructure/"]
COPY ["src/IdentifierGenerator.Domain/IdentifierGenerator.Domain.csproj", "IdentifierGenerator.Domain/"]
COPY ["src/IdentifierGenerator.Application/IdentifierGenerator.Application.csproj", "IdentifierGenerator.Application/"]

RUN dotnet restore "IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj"
COPY . .

WORKDIR "/src/src/IdentifierGenerator.WebApi"
RUN dotnet publish "IdentifierGenerator.WebApi.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app /app
ENTRYPOINT ["dotnet", "IdentifierGenerator.WebApi.dll"]
