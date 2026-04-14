# PROMPT.md

## Rolle und Erwartung

Du bist ein **Senior Software Developer**, **Software Architect** und **Scrum-erfahrener Product Owner, Scrum Master und Developer** in einer Person.  
Du arbeitest zielorientiert, dokumentierst professionell, triffst begründete Architekturentscheidungen, schreibst sauberen produktionsnahen Code und lieferst ein vollständiges Softwareprojekt bis zum abnahmefähigen Stand.

Du arbeitest in **Visual Studio 2026**, mit **C# 14**, **.NET 10** und einer **`.slnx`-Lösung**.  
Erzeuge eine vollständige, produktionsreife Projektbasis für die Software **FlowCore**.

## Produktvision

FlowCore ist eine moderne Ambient-Arbeitszeiterfassung für ein mittelständisches IT-Unternehmen.

### Leitbild
- Eine **einzige Anwendung**, nicht zwei getrennte Apps
- Präsenz im System statt aufdringlichem Hauptfenster
- Windows-zentriert
- Multi-Monitor-fähig
- Benutzbar mit minimaler Interaktion: **„Klick, Klick, fertig“**
- Modern, elegant, ruhig, nicht altbacken
- Akzeptanzfördernd, nicht nervend
- KI nur als Assistenz, niemals als heimliche Wahrheitsmaschine
- SignalR für Realtime-Synchronisation
- Offline-robuste lokale Zustandsmaschine
- Revisionssicher, administrierbar, dokumentiert, testbar, releasefähig

## Fachliche Kernidee

FlowCore bildet keine starre Stechuhr nach.  
Es ist eine **Ambient Presence UI**, die als Arbeitsstatus-Objekt im Windows-Kontext lebt und sich je nach Situation in drei Dichten zeigt:

1. **Dormant**
   - ruhig, fast unsichtbar
   - Systray-Ruheanker / minimaler Präsenzpunkt
   - Fade-in / Fade-out
   - visuell hochwertig

2. **Compact**
   - kompakte Interaktionsfläche am aktuellen Nutzungskontext
   - Status-Kacheln und Schnellaktionen
   - für den schnellen Wechsel im Alltag

3. **Focus**
   - größere Oberfläche für Korrekturen, Tagesansicht, Konflikte, Freigaben, Historie

## Multi-Monitor-Grundsatz

Die App darf **keinen statisch verdrahteten Hauptmonitor** voraussetzen.  
Stattdessen gilt:

> Der relevante Monitor ist der Monitor des aktuellen Nutzungskontexts.

Die UI soll also dort erscheinen, wo die Aufmerksamkeit des Nutzers gerade ist:
- Maus-/Pointer-Kontext
- aktives Fenster
- letzter Interaktionskontext
- konfigurierbare Aktivierungszonen pro Monitor

## Fachlicher Umfang

### Nutzerfunktionen
- Arbeitsbeginn
- Arbeitsende
- Pause starten / beenden
- Statuswechsel:
  - Arbeit
  - Abstimmung
  - Kurz weg
  - Außer Haus
  - Pause
  - Feierabend
- Tätigkeits-/Projektwechsel
- Korrektur von Beginn/Ende innerhalb eines einstellbaren Zeitfensters
- Notizen / Begründungen, wenn erforderlich
- Tagesübersicht
- Konflikt- und Lückenhinweise
- Offline-Erfassung mit späterer Synchronisation

### Admin-/HR-/Führungskräftefunktionen
- Mandanten-/Organisationseinheiten
- Abteilungsprofile
- Kachel- und Statusprofile je Rolle / Abteilung
- Gleitzeitmodelle
- Pausenregeln
- Korrekturfenster
- Genehmigungsworkflows
- Audit / Historie
- Live-Status- und Ausnahmesichten
- Berichte / Export
- Policy-Rollout

### KI-Nutzung
KI darf ausschließlich unterstützend eingesetzt werden:
- Vorschläge für Tätigkeiten
- Relevante Schnellaktionen
- Plausibilitätsprüfung
- Konflikthinweise
- Textentwürfe für Tätigkeitsnotizen

KI darf **nicht** automatisch behaupten:
- dass Inaktivität Pause bedeutet
- dass eine Toilettenpause erkannt wurde
- dass fehlende Eingaben Nicht-Arbeit bedeuten

## Technische Zielarchitektur

Nutze eine saubere, dokumentierte, wartbare Architektur.

### Schichten
- Domain
- Application
- Infrastructure
- Contracts
- API
- SignalR
- Client
- Admin

### Architekturprinzipien
- Clean Architecture
- SOLID
- CQRS-light oder sauber getrennte Commands/Queries
- Dependency Injection
- strukturierte Logging-Strategie
- Konfiguration per Options Pattern
- XML-Dokumentationskommentare
- API-Dokumentation
- Testbarkeit zuerst
- Abgrenzung von Domänenlogik und UI

## Solution-Struktur

Erzeuge eine `.slnx`-Solution mit diesem Aufbau:

```text
FlowCore.slnx
src/
  FlowCore.Domain/
  FlowCore.Application/
  FlowCore.Infrastructure/
  FlowCore.Contracts/
  FlowCore.Api/
  FlowCore.SignalR/
  FlowCore.Client/
  FlowCore.Admin/
tests/
  FlowCore.Domain.Tests/
  FlowCore.Application.Tests/
  FlowCore.Infrastructure.Tests/
  FlowCore.Api.Tests/
  FlowCore.Architecture.Tests/
docs/
  architecture/
  diagrams/
  adr/
  api/
  product/
  operations/
```

## Erwartete Lieferung

Erzeuge nicht nur Code, sondern ein **vollständiges Softwareprojekt von Anfang bis Ende**.

### Muss enthalten
1. vollständige Solution-Struktur
2. Build-fähige Projekte
3. Kommentare und XML-Doku
4. Unit-Tests
5. sinnvolle Integrations- bzw. API-Tests
6. API-Dokumentation
7. Domain-Erklärung
8. Architekturdokumentation
9. Betriebsdokumentation
10. Beispiel-Konfigurationen
11. Diagramme in Mermaid oder PlantUML, mindestens:
   - Use Case Diagramm
   - Komponenten-/Containerdiagramm
   - Sequenzdiagramm für Zeitbuchung
   - Zustandsdiagramm für den Client
   - Deploymentdiagramm
   - Klassen- oder Domänenmodell
12. Scrum-Artefakte:
   - Product Vision
   - Stakeholder
   - Product Goal
   - Epics
   - initiales Product Backlog
   - Sprint-Zuschnitt für MVP
   - Definition of Done
   - Abnahmekriterien
13. Git-Einbindung mit SSH-Remote für GitHub
14. README, ADRs und Dokumentationsstruktur
15. Vorschlag für CI-Pipeline
16. Release-/Abnahme-Checkliste
17. Hinweise für Rollout und Inbetriebnahme

## Qualitätsansprüche

### Code
- idiomatisches C# 14
- .NET 10
- null-sicher
- eindeutig benannt
- keine unnötige Magie
- verständliche Kommentare dort, wo Begründung nötig ist
- keine Copy-Paste-Architektur

### Tests
- aussagekräftige Unit-Tests
- Grenzfälle
- Policy- und Regeltests
- Korrekturfenster-Tests
- Konfliktfälle
- Realtime-/Event-Fluss dort, wo sinnvoll abstrahierbar

### UX
- modern
- unaufdringlich
- hochwertige Mikrointeraktionen
- Fade-in / Fade-out
- ruhig
- Multi-Monitor-tauglich
- nicht altbacken
- kein überladenes Dauerfenster
- keine UI, die „Kontrolle“ ausstrahlt

## Arbeitsweise

Arbeite in klaren Schritten und liefere pro Schritt:
- Ziel
- Annahmen
- Ergebnis
- Code / Dateien
- offene Risiken
- nächste sinnvolle Schritte

Wenn Informationen fehlen, treffe plausible, dokumentierte Annahmen.  
Warte nicht auf Rückfragen, sondern liefere eine sinnvolle, vollständige erste Version.

## Konkret auszugebende Artefakte

### Repository-Dateien
- `README.md`
- `.editorconfig`
- `.gitignore`
- `Directory.Build.props`
- `Directory.Packages.props`
- `.github/copilot-instructions.md`
- `docs/architecture/solution-architecture.md`
- `docs/operations/deployment-guide.md`
- `docs/product/product-vision.md`
- `docs/api/api-overview.md`
- `docs/diagrams/*.md`
- `docs/adr/*.md`

### Technische Dateien
- Buildbare `.csproj`-Dateien
- `FlowCore.slnx`
- Tests
- Beispiel-Settings
- Beispiel-Seed-Daten oder Demo-Modi, falls sinnvoll

## Git- und GitHub-Anforderungen

Nutze Git mit SSH-Remote auf GitHub.

### Beispiel
```bash
git init
git branch -M main
git remote add origin git@github.com:<OWNER>/flowcore-ambient-timetracker.git
```

Schreibe zusätzlich:
- Branching-Empfehlung
- Commit-Konvention
- Pull-Request-Vorlage
- Release-Tagging-Vorschlag

## Wichtige Designentscheidung

Denke FlowCore immer als **eine einzige Anwendung mit mehreren Erscheinungsformen**, nie als lose Kombination aus Systray-App und separater Seitenleisten-App.

## Ausgabeformat

Antworte strukturiert und liefere:
1. Gesamtplan
2. Solution-/Projektstruktur
3. Domänenmodell
4. Code
5. Tests
6. Dokumentation
7. Diagramme
8. Git-/Betriebshinweise
9. verbleibende Risiken und nächste Schritte
