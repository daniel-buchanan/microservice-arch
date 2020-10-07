#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/application/microservice_arch.processing/microservice_arch.processing.csproj", "src/application/microservice_arch.processing/"]
RUN dotnet restore "src/application/microservice_arch.processing/microservice_arch.processing.csproj"
COPY . .
WORKDIR "/src/src/application/microservice_arch.processing"
RUN dotnet build "microservice_arch.processing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "microservice_arch.processing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "microservice_arch.processing.dll"]