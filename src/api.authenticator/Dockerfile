FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["api.authenticator/api.authenticator.csproj", "api.authenticator/"]
COPY ["core/core.csproj", "core/"]
RUN dotnet restore "api.authenticator/api.authenticator.csproj"
COPY . .
WORKDIR "/src/api.authenticator"
RUN dotnet build "api.authenticator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api.authenticator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.authenticator.dll"]