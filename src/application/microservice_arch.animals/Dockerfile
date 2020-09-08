#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/application/microservice_arch.animals/microservice_arch.animals.csproj", "src/application/microservice_arch.animals/"]
RUN dotnet restore "src/application/microservice_arch.animals/microservice_arch.animals.csproj"
COPY . .
WORKDIR "/src/src/application/microservice_arch.animals"
RUN dotnet build "microservice_arch.animals.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "microservice_arch.animals.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "microservice_arch.animals.dll"]