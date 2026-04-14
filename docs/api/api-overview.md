# API Overview

## Technische Basis
- REST API für Persistenz, Queries, Admin-Abläufe und Realtime-Fallback
- SignalR Hub `/hubs/presence` als Realtime-Rückgrat
- Reconciliation über Offline-Queue-Replay (siehe `docs/architecture/realtime-and-sync.md`)
- Persistenzmodus über Konfiguration wählbar (`InMemory` oder `PostgreSql`)

## Core Endpoints
| Methode | Route | Zweck | Erwarteter Erfolg |
|---|---|---|---|
| GET | `/health` | technische Verfügbarkeit | `200 OK` |
| GET | `/api/statuses` | verfügbare Arbeitsstatus | `200 OK` |
| POST | `/api/presence/start-day` | Arbeitsbeginn buchen | `200 OK` |
| POST | `/api/presence/end-day` | Arbeitsende buchen | `200 OK` |
| POST | `/api/presence/start-break` | Pause starten | `200 OK` |
| POST | `/api/presence/end-break` | Pause beenden | `200 OK` |
| POST | `/api/presence/change` | beliebigen Präsenzstatus setzen | `200 OK`, bei ungültigem Status `400` |
| POST | `/api/workdays/correct` | Zeitbuchung korrigieren | `200 OK` |
| GET | `/api/workdays/{userId}/{date}` | Tagesdaten abrufen | `200 OK` |
| GET | `/api/workdays/{userId}/{date}/conflicts` | Konflikte/Lücken abrufen | `200 OK` |

## Admin-/HR-/Teamlead-Schnitt
| Methode | Route | Rolle | Ergebnis |
|---|---|---|---|
| GET | `/api/admin/live-status` | `Admin`, `Hr`, `TeamLead` | Live-Statusliste |
| GET | `/api/admin/audit` | `Admin`, `Hr`, `TeamLead` | Audit-Übersicht |
| POST | `/api/admin/policies/broadcast` | `Admin`, `Hr`, `TeamLead` | Policy-Update Ereignis |

Ohne ausreichende Rolle liefern die Endpunkte `403 Forbidden`.

## Realtime-Events
- `PresenceChangedEvent`
- `PolicyUpdatedEvent`
- `ApprovalRequestedEvent`
- `ConflictHintEvent`

## Rollenmodell
`RoleScope`:
- `Employee`
- `TeamLead`
- `Hr`
- `Admin`

## Designgrundsätze
- SignalR ist primärer Live-Kanal, aber kein Single Point of Failure.
- REST bleibt verfügbar als robuster Fallback.
- Domainlogik bleibt unabhängig von API- und Transportmodellen.
- Audit- und Live-Status-Daten werden serverseitig parallel gepflegt.
