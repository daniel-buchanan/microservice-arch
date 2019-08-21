FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["api.properties/api.properties.csproj", "api.properties/"]
COPY ["auth/auth.csproj", "auth/"]
COPY ["core/core.csproj", "core/"]
COPY ["api.core/api.core.csproj", "api.core/"]
RUN dotnet restore "api.properties/api.properties.csproj"
COPY . .
WORKDIR "/src/api.properties"
RUN dotnet build "api.properties.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api.properties.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.properties.dll"]