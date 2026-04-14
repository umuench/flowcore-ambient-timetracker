# ADR 0001: Clean Architecture als Strukturprinzip

## Status
Accepted

## Kontext
FlowCore benötigt langlebige Wartbarkeit bei gleichzeitiger Trennung von Domänenlogik und technischen Details.

## Entscheidung
Wir strukturieren in die Schichten `Domain`, `Application`, `Infrastructure`, `Contracts`, `Api`, `SignalR`, `Client`, `Admin`.

## Konsequenzen
- Geringere Kopplung
- Bessere Testbarkeit
- Klare Abhängigkeitsregeln ohne zirkuläre Referenzen
