# Epics and Initial Backlog

## Epics
1. Ambient Presence Client (Dormant/Compact/Focus)
2. Zeitbuchungs-Domain und Regelwerk
3. API + Realtime Synchronisation
4. Offline-First Zustands- und Sync-Engine
5. Admin/HR Policy- und Freigabe-Management
6. Audit, Reporting und Export

## Initiales Product Backlog (priorisiert)

| Prio | Item | Epic | Ergebnis |
|---|---|---|---|
| P1 | Arbeitsbeginn/-ende und Pause erfassen | 2 | Kernbuchungen Ende-zu-Ende |
| P1 | Statuswechsel via Compact UI | 1 | Alltagstaugliche Schnellaktion |
| P1 | Lokale Zustandsmaschine + Offline Queue | 4 | Keine Datenerfassungsausfälle |
| P1 | API-Endpunkte für Buchungen + Tagesansicht | 3 | Persistenz und Abfrage |
| P1 | SignalR Live-Status Broadcast | 3 | Realtime-Teamansicht |
| P2 | Korrekturfenster-Regeln inkl. Begründungspflicht | 2 | Regelkonforme Korrekturen |
| P2 | Konflikterkennung und Hinweise | 2 | Datenqualität verbessern |
| P2 | Admin Policy-Profile (Abteilung/Rolle) | 5 | Steuerbarkeit |
| P3 | Genehmigungsworkflow für Ausnahmen | 5 | Kontrollierter Sonderfallprozess |
| P3 | Audit-Ansicht und Export | 6 | Revisionssicherheit |

## Sprint-Vorschlag

### Sprint 0 (Setup)
- Solution/Projekte/Build-Pipeline-Grundlage
- Architekturleitplanken, ADR-Start, Basis-Doku
- Test- und Qualitäts-Gates

### Sprint 1 (MVP-Kern)
- Kernzustände und Buchungs-Use-Cases
- Client `Compact` Schnellaktionen
- API + SignalR Basispfad
- Offline Queue + Sync bei Reconnect
