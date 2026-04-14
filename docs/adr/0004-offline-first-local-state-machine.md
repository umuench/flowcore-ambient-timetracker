# ADR 0004: Offline-first lokale Zustandsmaschine

## Status
Accepted

## Kontext
Zeitbuchung muss auch bei Netzunterbrechung zuverlässig funktionieren.

## Entscheidung
Der Client führt eine lokale Zustands- und Queue-Logik und synchronisiert bei Reconnect deterministisch.

## Konsequenzen
- Hohe Verfügbarkeit für Nutzende
- Zusätzliche Komplexität für Konfliktauflösung und Idempotenz
