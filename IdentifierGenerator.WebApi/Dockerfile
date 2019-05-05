FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj", "IdentifierGenerator.WebApi/"]
COPY ["IdentifierGenerator.Bootstrap/IdentifierGenerator.Bootstrap.csproj", "IdentifierGenerator.Bootstrap/"]
COPY ["IdentifierGenerator.Infrastructure/IdentifierGenerator.Infrastructure.csproj", "IdentifierGenerator.Infrastructure/"]
COPY ["IdentifierGenerator.Domain/IdentifierGenerator.Domain.csproj", "IdentifierGenerator.Domain/"]
COPY ["IdentifierGenerator.Application/IdentifierGenerator.Application.csproj", "IdentifierGenerator.Application/"]
RUN dotnet restore "IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj"
COPY . .
WORKDIR "/src/IdentifierGenerator.WebApi"
RUN dotnet build "IdentifierGenerator.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IdentifierGenerator.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IdentifierGenerator.WebApi.dll"]
