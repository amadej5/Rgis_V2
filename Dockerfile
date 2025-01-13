# Osnova za ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Faza za gradnjo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Rgis_V2.csproj", "./"]
RUN dotnet restore "Rgis_V2.csproj"
COPY . .
RUN dotnet build "Rgis_V2.csproj" -c Release -o /app/build

# Faza za objavo
FROM build AS publish
RUN dotnet publish "Rgis_V2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Končna faza
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rgis_V2.dll"]