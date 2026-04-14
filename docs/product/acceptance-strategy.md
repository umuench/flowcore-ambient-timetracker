# Acceptance Strategy

## Abnahmeansatz
Die Abnahme erfolgt inkrementell pro Epic mit End-to-End-Nachweis für kritische Flüsse.

## Kritische Abnahmeszenarien
1. Arbeitsbeginn, Statuswechsel, Pause, Arbeitsende
2. Offline-Erfassung über Verbindungsverlust und spätere Synchronisation
3. Korrektur innerhalb/außerhalb Korrekturfenster
4. Konflikthinweis und Auflösung
5. Audit-Nachvollziehbarkeit für manuelle Änderungen

## Qualitätsnachweise
- Testprotokolle (Unit, API, Integrationsnah)
- Dokumentationsstand (Produkt, Architektur, Betrieb, API)
- Releaseliste inkl. bekannter Restrisiken

## Ausschlusskriterien
- Unklare Verantwortlichkeit im Freigabefluss
- Fehlende Auditierbarkeit kritischer Buchungen
- UX-Verhalten, das als überwachend wahrgenommen wird
