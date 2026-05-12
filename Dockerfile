# syntax=docker/dockerfile:1.7

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

WORKDIR /src

# BuildKit SSH mount
RUN --mount=type=ssh echo "SSH mount działa"

COPY WeatherApp/*.csproj ./WeatherApp/

WORKDIR /src/WeatherApp

RUN dotnet restore

COPY WeatherApp/. .

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine

WORKDIR /app

RUN apk add --no-cache curl

LABEL org.opencontainers.image.authors="Alicja Gil"
LABEL org.opencontainers.image.source="https://github.com/Fallfinch/weatherapp"

COPY --from=build /app/publish .

EXPOSE 8080

HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
  CMD curl -f http://localhost:8080/ || exit 1

ENTRYPOINT ["dotnet", "WeatherApp.dll"]