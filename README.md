# FlowCore

FlowCore ist eine Windows-first Ambient-Arbeitszeiterfassung für moderne IT-Teams.

Das Produkt wird als **eine Anwendung mit mehreren Erscheinungsformen** umgesetzt:
- `Dormant`
- `Compact`
- `Focus`

## Aktueller Stand
Projektbasis bis inkl. Meilenstein `01` bis `07` ist umgesetzt:
- Produkt-/Scrum-Artefakte
- Clean-Architecture-Solution mit `FlowCore.slnx`
- Domain- und Application-Kernlogik
- API + SignalR + Realtime-Events + REST-Fallback
- Client-UI-State-Machine-Grundgerüst
- Qualitäts-, Test- und Betriebsdokumentation
- GitHub Delivery-Basis (PR-/Issue-Templates, CI-Workflow, Copilot-Instructions)

## Technischer Stack
- Visual Studio 2026
- C# 14
- .NET 10
- `.slnx` als Solution-Format
- SignalR + REST
- Offline-first Reconciliation-Ansatz
- Persistenzmodus: `InMemory` oder `PostgreSql`

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

## Schnellstart
### API lokal starten
```bash
dotnet build FlowCore.slnx
dotnet run --project src/FlowCore.Api/FlowCore.Api.csproj
```

### Lokale Prüfungen
```bash
dotnet test FlowCore.slnx --no-build
```

### PostgreSQL aktivieren
1. PostgreSQL bereitstellen.
2. `src/FlowCore.Api/appsettings.json` anpassen:
   - `Persistence:Provider = PostgreSql`
   - `ConnectionStrings:FlowCore` auf deine Instanz setzen
3. API starten. Bei `EnsureCreatedOnStartup=true` wird das Schema automatisch erstellt.

### Wichtige Endpunkte
- `GET /health`
- `GET /api/statuses`
- `POST /api/presence/*`
- `POST /api/workdays/correct`
- `GET /api/admin/live-status`
- `GET /api/admin/audit`
- SignalR Hub: `/hubs/presence`

## Dokumentationsindex
- Produkt: `docs/product/`
- Architektur: `docs/architecture/`
- API: `docs/api/api-overview.md`
- Betrieb: `docs/operations/`
- PostgreSQL Setup: `docs/operations/postgresql-setup.md`
- Projektreview: `docs/operations/project-review.md`
- ADRs: `docs/adr/`
- Diagramme: `docs/diagrams/`

## Qualität
- XML-Dokumentationskommentare für öffentliche APIs
- Unit-, API- und Architekturtests
- Deterministische Zeitabhängigkeiten über `IClock`/Abstraktionen

## Delivery / GitHub
- CI: `.github/workflows/ci.yml`
- PR-Template: `.github/PULL_REQUEST_TEMPLATE.md`
- Issue-Templates: `.github/ISSUE_TEMPLATE/`
- Copilot Instructions: `.github/copilot-instructions.md` und `.github/instructions/`

## Hinweise zum Reifegrad
Aktuell liegt eine **abnahmefähige Projektbasis** mit Baseline-Implementierungen vor. Für produktiven Rollout sind insbesondere persistente Speicherung, vollständige Authentifizierung/Autorisierung und Last-/Resilienz-Härtung als nächste Schritte vorgesehen (siehe `docs/product/residual-risks-and-followup.md`).
