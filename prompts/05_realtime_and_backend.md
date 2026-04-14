# Prompt 05 — API, SignalR and Infrastructure

Erzeuge die serverseitigen und infrastrukturellen Grundlagen.

## Aufgabe
Baue API, Realtime-Kommunikation und Persistenzbasis für FlowCore.

## Muss enthalten
- REST API
- SignalR Hub
- DTOs / Contracts
- Persistenzbasis
- Konfigurationsmodelle
- Logging
- Audit
- Rollenmodell
- Admin-/HR-/Teamleitungsschnitt

## Realtime-Anwendungsfälle
- Live-Statusänderungen
- Policy-Updates
- Korrektur- und Freigabeereignisse
- Konflikthinweise
- Team-/Admin-Live-Sichten

## Qualitätsanforderungen
- SignalR ist Realtime-Rückgrat, aber nicht Single Point of Failure
- REST bleibt Fallback
- Client muss offline-robust sein
- Reconciliation-Ansatz dokumentieren

## Erwartete Artefakte
- `src/FlowCore.Api`
- `src/FlowCore.SignalR`
- `src/FlowCore.Infrastructure`
- `docs/api/api-overview.md`
- `docs/architecture/realtime-and-sync.md`
- `docs/operations/configuration.md`
