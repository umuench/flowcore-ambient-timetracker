# Prompt 02 — Solution Scaffold, SLNX, Repository and Build Baseline

Erzeuge die technische Projektbasis für **FlowCore** in **Visual Studio 2026**, **C# 14**, **.NET 10** und einer **`.slnx`-Solution**.

## Aufgabe
Erzeuge die Solution-Struktur, die Projektdateien, gemeinsame Build-Dateien und die Grundkonfiguration.

## Erwartete Artefakte
- `FlowCore.slnx`
- `Directory.Build.props`
- `Directory.Packages.props`
- `.editorconfig`
- `.gitignore`
- `README.md`
- `src/*`
- `tests/*`

## Projektstruktur
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

## Anforderungen
- Buildbar
- saubere Referenzen
- keine zirkulären Abhängigkeiten
- gemeinsame Package-Versionen
- XML-Dokumentation aktivieren
- Nullable aktivieren
- sinnvolle Analyse-/Warnungsstufe
- testbare Struktur
- Logging- und Konfigurationsbasis

## Zusätzlich
Erzeuge erste ADRs:
- Wahl der Architektur
- Wahl von SignalR
- Wahl des Ambient-Presence-Konzepts
- Offline-first lokale Zustandsmaschine
