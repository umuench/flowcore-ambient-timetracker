# Prompt 03 — Domain and Application Core

Erzeuge die fachliche Kernlogik für **FlowCore**.

## Aufgabe
Modelliere die Domäne und die wichtigsten Use Cases.

## Domänenkonzepte
- Employee
- DepartmentProfile
- Workday
- TimeEntry
- TimeRange
- PresenceState
- ActivityContext
- CorrectionWindowPolicy
- BreakPolicy
- FlexTimeModel
- ApprovalRequest
- Conflict
- AuditEntry

## Erwartete Fähigkeiten
- Arbeitsbeginn erfassen
- Arbeitsende erfassen
- Pause starten / beenden
- Status wechseln
- Projekt / Tätigkeit wechseln
- Korrektur von Start / Ende innerhalb des Fensters
- Konflikte erkennen
- Genehmigungspflicht außerhalb der Policy
- Lücken erkennen
- Tagesabschluss prüfen

## Erwartete Artefakte
- Domain-Modelle
- Value Objects
- Domain Services
- Application Commands / Queries
- Validators
- Interfaces für Clock, Repository, PolicyProvider, EventPublisher
- XML-Dokumentation
- Unit-Tests

## Diagramme
Bitte zusätzlich liefern:
- `docs/diagrams/domain-model.md`
- `docs/diagrams/use-case.md`
- `docs/diagrams/state-machine-client.md`
