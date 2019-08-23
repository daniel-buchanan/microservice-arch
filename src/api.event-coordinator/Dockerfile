FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["api.event-coordinator/api.event-coordinator.csproj", "api.event-coordinator/"]
COPY ["core/core.csproj", "core/"]
RUN dotnet restore "api.event-coordinator/api.event-coordinator.csproj"
COPY . .
WORKDIR "/src/api.event-coordinator"
RUN dotnet build "api.event-coordinator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api.event-coordinator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.event-coordinator.dll"]