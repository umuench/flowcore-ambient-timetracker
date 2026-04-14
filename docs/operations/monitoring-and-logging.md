# Monitoring and Logging

## Logging-Grundsätze
- Strukturierte Logs mit Event-Typ, UserId (pseudonymisiert), CorrelationId.
- Keine sensiblen Freitextinhalte ungefiltert loggen.
- Audit-Events getrennt von technischen Logs halten.

## Metriken (MVP)
- API Request Rate / Error Rate / Latency
- SignalR Connected Clients
- Reconnect Count
- Offline-Replay Queue Length
- ApprovalRequest Creation Rate
- ConflictHint Count

## Alerting-Empfehlung
- Error Rate > 2% über 5 Minuten
- `/health` != 200
- Reconnect Count ungewöhnlich hoch
- Replay Queue Length über Schwellwert

## Tracing-Hinweise
- CorrelationId von Client bis API/Event-Publisher durchreichen.
- REST-Fallback-Aufrufe explizit markieren.
- Reconciliation-Läufe als zusammenhängende Operation protokollieren.
