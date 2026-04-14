# ADR 0002: SignalR für Realtime-Synchronisation

## Status
Accepted

## Kontext
Statuswechsel sollen in Team- und Admin-Sichten nahezu in Echtzeit sichtbar sein.

## Entscheidung
SignalR wird als Realtime-Kanal verwendet, ergänzt durch REST als Fallback und Persistenzschnittstelle.

## Konsequenzen
- Schnelle Ereignisverteilung
- Zusätzliche Anforderungen an Verbindungs- und Reconnect-Handling
