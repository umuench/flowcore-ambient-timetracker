# Non-Functional Requirements

## UX und Akzeptanz
- Windows-first, multi-monitor-fähig
- Kein statisch verdrahteter Hauptmonitor
- Kurze Interaktionswege (max. 2 Klicks für häufige Aktionen)
- Ruhige Mikrointeraktionen (subtile Fade-Transitions)

## Sicherheit und Compliance
- Nachvollziehbare Audit-Trails für Änderungen
- Rollenbasierte Zugriffe für Admin-/HR-Funktionen
- Datenschutzfreundliche Standardeinstellungen

## Qualität und Wartbarkeit
- Klare Schichtentrennung (Domain/Application/Infrastructure/...)
- Deterministische Tests, keine versteckten Zeitabhängigkeiten
- Konfiguration über Options Pattern

## Betrieb
- Offline-Erfassung mit resilienter Synchronisation
- Realtime über SignalR plus API-Fallback
- Strukturierte Logs und korrelierbare Ereignisse

## Performance (MVP-Ziele)
- Statuswechsel aus Client-Sicht < 300 ms lokal
- Sync-Recovery nach Verbindungsrückkehr < 10 s für normale Tageslast
