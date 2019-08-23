FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["api.command-handler/api.command-handler.csproj", "api.command-handler/"]
COPY ["core/core.csproj", "core/"]
RUN dotnet restore "api.command-handler/api.command-handler.csproj"
COPY . .
WORKDIR "/src/api.command-handler"
RUN dotnet build "api.command-handler.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api.command-handler.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.command-handler.dll"]