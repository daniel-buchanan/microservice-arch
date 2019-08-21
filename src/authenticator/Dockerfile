FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["authenticator/authenticator.csproj", "authenticator/"]
COPY ["core/core.csproj", "core/"]
RUN dotnet restore "authenticator/authenticator.csproj"
COPY . .
WORKDIR "/src/authenticator"
RUN dotnet build "authenticator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "authenticator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "authenticator.dll"]