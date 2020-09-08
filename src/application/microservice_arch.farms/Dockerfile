#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["microservice_arch.farms/microservice_arch.farms.csproj", "microservice_arch.farms/"]
RUN dotnet restore "microservice_arch.farms/microservice_arch.farms.csproj"
COPY . .
WORKDIR "/src/microservice_arch.farms"
RUN dotnet build "microservice_arch.farms.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "microservice_arch.farms.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "microservice_arch.farms.dll"]