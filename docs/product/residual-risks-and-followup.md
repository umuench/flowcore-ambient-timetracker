# Residual Risks, Technical Debt and Follow-up Sprints

## Bekannte Restrisiken
1. Persistenz ist aktuell als In-Memory-Baseline umgesetzt.
2. Rollenprüfung ist funktional, aber ohne vollwertige AuthN/AuthZ-Integration.
3. Reconciliation ist konzeptionell vorhanden, aber noch nicht mit echter langlebiger Queue getestet.
4. UI ist als Gerüst vorhanden, noch ohne finale WinUI-Mikrointeraktionen.

## Technische Schulden
- Fehlende produktive Datenbank und Migrationsstrategie
- Fehlendes dauerhaftes Event-/Message-Outbox-Muster
- Begrenzte Last- und Resilienztests unter Realtime-Spitzen
- Noch kein vollständiges End-to-End Monitoring-Dashboard

## Empfohlene Folge-Sprints

### Sprint 2
- Persistenzschicht (DB + Migrationen)
- AuthN/AuthZ (z. B. Entra ID) für Admin-Endpunkte
- Idempotency-Key-Pfad serverseitig hart validieren

### Sprint 3
- Erweiterte Reconciliation-Workflows + Konfliktauflösung UI
- Approval-Workflow Ende-zu-Ende im Admin-Client
- Lasttests für SignalR + REST-Fallback

### Sprint 4
- Reporting/Export und Audit-Explorer
- Hardening für Betrieb (Dashboards, Alert-Tuning, Runbooks finalisieren)
- Pilot-Rollout mit Abnahmeprotokoll
