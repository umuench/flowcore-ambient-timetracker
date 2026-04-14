# FlowCore

FlowCore ist eine Windows-first Ambient-Arbeitszeiterfassung für moderne IT-Teams.

## Technischer Stand (Meilenstein 02)
- `.slnx`-Solution: `FlowCore.slnx`
- Schichten: `Domain`, `Application`, `Infrastructure`, `Contracts`, `Api`, `SignalR`, `Client`, `Admin`
- Testprojekte: Domain, Application, Infrastructure, API, Architektur
- Zentrale Build- und Package-Konfiguration vorhanden

## Projektstruktur
```text
FlowCore.slnx
src/
  FlowCore.Domain/
  FlowCore.Application/
  FlowCore.Infrastructure/
  FlowCore.Contracts/
  FlowCore.Api/
  FlowCore.SignalR/
  FlowCore.Client/
  FlowCore.Admin/
tests/
  FlowCore.Domain.Tests/
  FlowCore.Application.Tests/
  FlowCore.Infrastructure.Tests/
  FlowCore.Api.Tests/
  FlowCore.Architecture.Tests/
docs/
  architecture/
  diagrams/
  adr/
  api/
  product/
  operations/
```

## Architekturprinzipien
- Clean Architecture mit klaren Abhängigkeitsgrenzen
- Explizite Modelle für Zeitbuchung und Status
- Realtime via SignalR, Persistenz/Abfragen via API
- Offline-first als lokale Zustandsmaschine (ADR)

## Build und Test
In Visual Studio die `FlowCore.slnx` öffnen und Build/Test ausführen.

## Nächste Schritte
- Meilenstein 03: Domain- und Application-Logik vertiefen
- Meilenstein 04: Ambient-Presence-UX im Client aufbauen
- Meilenstein 05: Persistenz, Auth, Realtime-Details und Admin vertiefen
