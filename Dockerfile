#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
ENV ASPNETCORE_ENVIRONMENT="Production"
ENV ENVIRONMENT="Production"

WORKDIR /src
COPY ["RoBHo-GameEngine.csproj", "."]
RUN dotnet restore "./RoBHo-GameEngine.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RoBHo-GameEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoBHo-GameEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoBHo-GameEngine.dll"]