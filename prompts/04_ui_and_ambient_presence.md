# Prompt 04 — Client UI and Ambient Presence

Erzeuge das konzeptionelle und technische Grundgerüst des Windows-Clients.

## Aufgabe
Bilde FlowCore als **eine einzige Anwendung mit mehreren Erscheinungsformen** ab.

## Kernprinzip
Nicht:
- Tray-App plus getrennte Sidebar-App

Sondern:
- ein einziger Zustandskern
- drei Dichten:
  - Dormant
  - Compact
  - Focus

## UI-Anforderungen
- Windows-first
- modern
- ruhig
- hochwertige Mikrointeraktionen
- Fade-in / Fade-out
- Multi-Monitor-fähig
- keine starre Hauptmonitor-Annahme
- kontextnahe Anzeige am aktuellen Nutzungskontext

## UX-Elemente
- Präsenzpunkt / Dot
- Status-Kacheln
- Tageskarte
- Konfliktkarte
- Korrekturdialog
- Aktivierungszonen pro Monitor
- letzter Nutzungskontext
- Tastenkürzel
- ruhiger Systray-Ruheanker

## Erwartete Artefakte
- UI-Shell / Client-Gerüst
- Status- und ViewModel-Grundstruktur
- UI-State-Machine
- Konfigurationsmodell für Aktivierungszonen
- Dokumentation der UX-Prinzipien
- Diagramme:
  - `docs/diagrams/ui-flow.md`
  - `docs/diagrams/sequence-book-time.md`
