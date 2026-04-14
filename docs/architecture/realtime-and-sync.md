# Realtime and Sync Architecture

## Ziel
Realtime-Transparenz ohne Abhängigkeit von einem einzigen Transportpfad.

## Architektur
1. Client sendet fachliche Aktionen per REST (`/api/presence/*`, `/api/workdays/*`).
2. Application-Service persistiert den Zustand.
3. Domänenereignisse werden über `IDomainEventPublisher` publiziert.
4. `SignalRDomainEventPublisher` verteilt Ereignisse an `/hubs/presence`.
5. Live-Status und Audit werden parallel im Server gepflegt.

## Reconciliation-Ansatz
- Client führt lokale Offline-Queue.
- Beim Reconnect werden Events in Batches replayed.
- Idempotency-Key-Strategie verhindert Doppelverarbeitung.
- REST ist Fallback, falls SignalR nicht verfügbar ist.

## Failure-Handling
- SignalR-Ausfall blockiert keine Buchung (REST bleibt aktiv).
- Konflikte/Lücken werden per Query und Event-Hinweis sichtbar gemacht.
- Audit-Store erlaubt Nachvollziehbarkeit nach Reconnect.
