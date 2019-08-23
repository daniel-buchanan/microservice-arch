FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["api.snapshot/api.snapshot.csproj", "api.snapshot/"]
COPY ["core/core.csproj", "core/"]
RUN dotnet restore "api.snapshot/api.snapshot.csproj"
COPY . .
WORKDIR "/src/api.snapshot"
RUN dotnet build "api.snapshot.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api.snapshot.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.snapshot.dll"]