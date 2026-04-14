# Deployment Guide

## Ziel
Reproduzierbare Auslieferung von `FlowCore.Api`, SignalR-Hub-Funktionalität und Client-Binaries.

## Deployment-Strategie
1. Build + automatisierte Tests erfolgreich.
2. Release-Artefakte versionieren (API, Client, Admin).
3. API/HUB in Staging deployen.
4. Smoke Tests (`/health`, zentrale API-Endpunkte, Hub-Verbindung).
5. Freigabe für Produktion.

## Checkpoints vor Go-Live
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
