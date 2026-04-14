# Deployment Guide

## Ziel
Reproduzierbare Auslieferung von `FlowCore.Api`, SignalR-Hub-Funktionalität, PostgreSQL-Persistenz und Client-Binaries.

## Deployment-Strategie
1. Build + automatisierte Tests erfolgreich.
2. PostgreSQL-Instanz und Zugangsdaten bereitstellen.
3. `ConnectionStrings:FlowCore` und `Persistence` konfigurieren.
4. API/HUB in Staging deployen.
5. Smoke Tests (`/health`, zentrale API-Endpunkte, Hub-Verbindung).
6. Freigabe für Produktion.

## Checkpoints vor Go-Live
- `Persistence:Provider=PostgreSql` gesetzt.
- Verbindung zur PostgreSQL-Instanz erfolgreich.
- Konfiguration für `OfflineSync`, `RealtimeSync`, `Reconciliation` gesetzt.
- Rollenmodell für Admin-Schnitt verifiziert.
- Logging-Sink und Alarmierung verbunden.
- Backout-Plan dokumentiert und getestet.

## Rollback-Strategie
- Blue/Green oder Slot-basiertes Deployment bevorzugen.
- Bei Incident: sofortiger Rückwechsel auf letzte stabile Version.
- Reconciliation erneut ausführen, um Offline-Queue sauber nachzuziehen.
- Incident + Ursache im Betriebstagebuch dokumentieren.

## Smoke-Test-Mindestset
- `GET /health` => `200`
- `GET /api/statuses` => `200`
- `POST /api/presence/change` mit gültigem Status => `200`
- Admin-Endpunkt ohne Rolle => `403`
- SignalR Hub `/hubs/presence` erreichbar
