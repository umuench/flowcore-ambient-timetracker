# Operations Runbook

## Betriebsziele
- Hohe Verfügbarkeit der Buchungs-API
- Realtime-Transparenz ohne SPOF
- Nachvollziehbarkeit über Audit und Logs

## Daily Checks
1. Health-Endpoint prüfen.
2. Fehlerquote API-Requests überwachen.
3. Reconnect-/Fallback-Häufigkeit analysieren.
4. Anzahl offener ApprovalRequests beobachten.

## Incident-Klassen
- P1: Buchungen nicht möglich (REST + Hub beeinträchtigt)
- P2: Realtime gestört, REST verfügbar
- P3: Einzelne Admin-Sichten inkonsistent

## Standardmaßnahmen
- P1: Sofort Rollback + Kommunikationsmeldung
- P2: Realtime-Komponente neu starten, REST-Fallback aktiv lassen
- P3: Audit/LiveStatus prüfen, betroffene User gezielt informieren

## Reconciliation bei Störung
1. Eingangsstörung identifizieren.
2. Reconnect stabilisieren.
3. Replay in Batches (`Reconciliation:MaxReplayBatchSize`).
4. Konfliktliste erzeugen und ggf. Approval anstoßen.

## Kommunikationspflicht
- Incident-Beginn, Impact, Workaround und Abschluss dokumentieren.
- Für Kundenabnahme: Lessons Learned pro Störung erfassen.
