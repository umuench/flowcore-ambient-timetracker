# MVP Scope

## Ziel des MVP
Ein produktiv pilotierbarer Kern, der tägliche Zeitbuchung zuverlässig und akzeptiert unterstützt.

## In Scope
- Explizite Kernzustände (`Work`, `Sync`, `ShortAway`, `OutOfOffice`, `Break`, `EndOfDay`)
- Arbeitsbeginn/-ende, Pause Start/Ende
- Kontextnahe Compact-Interaktion
- Tagesübersicht mit Lücken-/Konflikthinweisen
- Offline Queue + Reconnect-Synchronisation
- Grundlegende Admin-Policies (Pausen, Korrekturfenster)
- Basis-Audit für Buchungsänderungen

## Out of Scope (MVP)
- Erweiterte BI-Auswertungen
- Komplexe mehrstufige Freigabeprozesse
- KI-gestützte Notizgenerierung mit Organisationswissen

## Hauptrisiken
- Zu komplexe Regeln im MVP verlangsamen Lieferung
- UX-Fehlton (zu kontrollierend) reduziert Akzeptanz
- Offline/Realtime-Randfälle erhöhen Integrationsaufwand

## Gegenmaßnahmen
- Striktes MVP-Cutline-Management
- Frühe Nutzertests mit UX-Feedback
- Ereignisbasierte Testfälle für Sync- und Konfliktflüsse
