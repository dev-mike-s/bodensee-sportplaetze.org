# Backend Image API

ASP.NET-Core-API für den Upload und die Verwaltung von Bildern.

## Voraussetzungen

- .NET 10 SDK

## Starten

Im Projektverzeichnis:

```bash
dotnet run --project image-api/image-api.csproj
```

Lokal erreichbar unter `http://localhost:5086`.

## Hinweise

- Bilder werden unter `image-api/wwwroot/uploads` gespeichert.
- Metadaten liegen derzeit nur im Arbeitsspeicher und gehen beim Neustart verloren.
- Die API befindet sich in Entwicklung; Endpunkte und Funktionen sind teilweise noch unvollständig.
