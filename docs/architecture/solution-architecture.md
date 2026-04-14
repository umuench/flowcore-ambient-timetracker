# Solution Architecture

## Überblick
FlowCore wird als **eine Anwendung mit mehreren Erscheinungsformen** umgesetzt:
- `Dormant`
- `Compact`
- `Focus`

## Schichten
- `FlowCore.Domain`: Kernregeln, Zustände, Policies
- `FlowCore.Application`: Use-Cases, Commands/Queries, Orchestrierung
- `FlowCore.Infrastructure`: technische Implementierungen (Storage, Sync, Logging)
- `FlowCore.Contracts`: DTOs und Event-Verträge
- `FlowCore.Api`: HTTP-Schnittstelle, Fallback, Verwaltungszugriffe
- `FlowCore.SignalR`: Realtime-Hub und Event-Push
- `FlowCore.Client`: Windows-first Interaction Layer
- `FlowCore.Admin`: Administration/HR/Führung

## Abhängigkeitsregeln
- Domain kennt keine Infrastruktur/UI.
- Application referenziert Domain + Contracts.
- Infrastructure referenziert Application + Domain + Contracts.
- Api referenziert Application/Infrastructure/Contracts/SignalR.
- Client/Admin referenzieren nur Application + Contracts.

## Qualitätsleitplanken
- Nullable und XML-Doku zentral aktiviert
- Deterministische Tests ohne versteckte Zeitabhängigkeiten
- Relevante Entscheidungen als ADR dokumentiert
