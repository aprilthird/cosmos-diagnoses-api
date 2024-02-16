#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cosmos.Diagnoses.Api.Web/Cosmos.Diagnoses.Api.Web.csproj", "Cosmos.Diagnoses.Api.Web/"]
COPY ["Cosmos.Diagnoses.Api.CrossCutting/Cosmos.Diagnoses.Api.CrossCutting.csproj", "Cosmos.Diagnoses.Api.CrossCutting/"]
COPY ["Cosmos.Diagnoses.Api.Domain/Cosmos.Diagnoses.Api.Domain.csproj", "Cosmos.Diagnoses.Api.Domain/"]
COPY ["Cosmos.Diagnoses.Api.Infrastructure/Cosmos.Diagnoses.Api.Infrastructure.csproj", "Cosmos.Diagnoses.Api.Infrastructure/"]
RUN dotnet restore "./Cosmos.Diagnoses.Api.Web/./Cosmos.Diagnoses.Api.Web.csproj"
COPY . .
WORKDIR "/src/Cosmos.Diagnoses.Api.Web"
RUN dotnet build "./Cosmos.Diagnoses.Api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cosmos.Diagnoses.Api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cosmos.Diagnoses.Api.Web.dll"]