# Git, SSH and Delivery Workflow

## Git-Initialisierung (Vorschlag)
```bash
git init
git branch -M main
git remote add origin git@github.com:<OWNER>/flowcore-ambient-timetracker.git
```

## Branching-Empfehlung
- `main`: produktionsnahe, geschützte Basis
- `develop`: Integrationsbranch für laufende Arbeiten
- `feature/<scope>-<kurzname>`: Features
- `fix/<scope>-<kurzname>`: Bugfixes
- `hotfix/<scope>-<kurzname>`: dringende Produktionsfixes

## Commit-Konvention (Conventional Commits)
- `feat:` neue Funktion
- `fix:` Fehlerbehebung
- `refactor:` strukturelle Änderung ohne Verhaltensänderung
- `test:` Tests
- `docs:` Dokumentation
- `chore:` Build/Tooling/Meta

Beispiel:
```text
feat(api): add correction endpoint with approval fallback
```

## Release-Tagging
- SemVer: `vMAJOR.MINOR.PATCH`
- Beispiele:
  - `v0.1.0` erster pilotierbarer MVP-Stand
  - `v0.1.1` Hotfix

## Delivery-Gates
1. Build grün
2. Tests grün
3. PR-Review abgeschlossen
4. Checklisten erfüllt (Release + Abnahme)
5. Tag setzen und Release Notes erstellen
