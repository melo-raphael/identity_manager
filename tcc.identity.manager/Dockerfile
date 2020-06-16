FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["tcc.identity.manager/tcc.identity.manager.csproj", "tcc.identity.manager/"]
COPY ["tcc.identity.crosscutting.ioc/tcc.identity.crosscutting.ioc.csproj", "tcc.identity.crosscutting.ioc/"]
COPY ["tcc.identity.manager.domain/tcc.identity.manager.domain.csproj", "tcc.identity.manager.domain/"]
COPY ["tcc.identity.manager.infra/tcc.identity.manager.infra.csproj", "tcc.identity.manager.infra/"]
COPY ["tcc.identity.manager.application/tcc.identity.manager.application.csproj", "tcc.identity.manager.application/"]
RUN dotnet restore "tcc.identity.manager/tcc.identity.manager.csproj"
COPY . .
WORKDIR "/src/tcc.identity.manager"
RUN dotnet build "tcc.identity.manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tcc.identity.manager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tcc.identity.manager.dll"]