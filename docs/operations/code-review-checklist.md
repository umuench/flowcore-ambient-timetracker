# Code Review Checklist

## Architektur
- [ ] Clean-Architecture-Grenzen eingehalten
- [ ] Keine zirkulären Abhängigkeiten eingeführt
- [ ] Domänenlogik bleibt UI-/Infra-unabhängig

## Code-Qualität
- [ ] Benennung klar und konsistent
- [ ] Nullable/Fehlerpfade sauber behandelt
- [ ] Öffentliche Typen sinnvoll XML-dokumentiert
- [ ] Keine unnötige Komplexität oder Copy/Paste

## Tests
- [ ] Relevante Unit-/API-/Architekturtests ergänzt
- [ ] Grenzfälle abgedeckt (Policy, Korrekturfenster, Konflikte)
- [ ] Tests deterministisch (kein versteckter Zeitbezug)

## Betrieb & Security
- [ ] Konfiguration über Options Pattern
- [ ] Logging/Observability ausreichend
- [ ] Rollen-/Zugriffspfad für Admin-Endpunkte geprüft

## Doku
- [ ] API-/Architektur-/Operations-Dokumente aktualisiert
- [ ] Relevante Diagramme/ADRs angepasst
