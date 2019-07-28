FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["EventBriteAssignment/EventCatalog.csproj", "EventBriteAssignment/"]
RUN dotnet restore "EventBriteAssignment/EventBriteAssignment.csproj"
COPY . .
WORKDIR "/src/EventBriteAssignment"
RUN dotnet build "EventCatalog.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventBriteAssignment.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventBriteAssignment.dll"]
