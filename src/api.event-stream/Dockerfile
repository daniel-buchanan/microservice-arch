FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["api.event-stream/api.event-stream.csproj", "api.event-stream/"]
COPY ["core/core.csproj", "core/"]
RUN dotnet restore "api.event-stream/api.event-stream.csproj"
COPY . .
WORKDIR "/src/api.event-stream"
RUN dotnet build "api.event-stream.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api.event-stream.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.event-stream.dll"]