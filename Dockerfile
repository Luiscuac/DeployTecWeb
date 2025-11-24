# Etapa base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Etapa de build: compila la app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Security.Api/Security.Api.csproj", "Security.Api/"]
RUN dotnet restore "Security.Api/Security.Api.csproj"
COPY . .
WORKDIR "/src/Security.Api"
RUN dotnet build "Security.Api.csproj" -c Release -o /app/build
RUN dotnet publish "Security.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final: ejecuta la app compilada
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Security.Api.dll"]