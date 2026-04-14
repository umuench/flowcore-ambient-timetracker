# Rollback Strategy

## Ziel
Schneller und sicherer Rückweg auf eine stabile Version ohne Datenverlust.

## Vorgehen
1. Incident klassifizieren und Rollback-Entscheidung freigeben.
2. Letzte stabile API-Version aktivieren.
3. SignalR-Komponente auf passende Version zurücksetzen.
4. Health- und Smoke-Checks durchführen.
5. Reconciliation-Lauf triggern, um Offline-Events nachzuziehen.

## Datenintegrität
- Idempotency-Key-Strategie verhindert Doppelschreiben.
- Approval/Audit-Einträge werden nicht gelöscht, nur ergänzt.

## Kommunikationsregeln
- Rollback-Zeitpunkt, Scope und erwarteter Impact transparent kommunizieren.
- Abschlussbericht mit Ursache, Gegenmaßnahme und Prävention dokumentieren.
