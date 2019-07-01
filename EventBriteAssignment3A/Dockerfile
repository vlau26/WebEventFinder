FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["EventBriteCatalog/EventBriteCatalog.csproj", "EventBriteCatalog/"]
RUN dotnet restore "EventBriteCatalog/EventBriteCatalog.csproj"
COPY . .
WORKDIR "/src/EventBriteCatalog"
RUN dotnet build "EventBriteCatalog.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventBriteCatalog.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventBriteCatalog.dll"]