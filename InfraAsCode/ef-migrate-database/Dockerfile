FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS base
WORKDIR /src
COPY ["IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj", "IdentifierGenerator.WebApi/"]
COPY ["IdentifierGenerator.Bootstrap/IdentifierGenerator.Bootstrap.csproj", "IdentifierGenerator.Bootstrap/"]
COPY ["IdentifierGenerator.Infrastructure/IdentifierGenerator.Infrastructure.csproj", "IdentifierGenerator.Infrastructure/"]
COPY ["IdentifierGenerator.Domain/IdentifierGenerator.Domain.csproj", "IdentifierGenerator.Domain/"]
COPY ["IdentifierGenerator.Application/IdentifierGenerator.Application.csproj", "IdentifierGenerator.Application/"]
RUN dotnet restore "IdentifierGenerator.WebApi/IdentifierGenerator.WebApi.csproj"
COPY . .
WORKDIR "/src/IdentifierGenerator.WebApi"
RUN dotnet build "IdentifierGenerator.WebApi.csproj" -c Debug

RUN dotnet tool install -g dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "ef", "database", "update", "--verbose"]
