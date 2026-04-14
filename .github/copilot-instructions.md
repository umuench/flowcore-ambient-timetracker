# Repository-wide custom instructions for GitHub Copilot

This repository contains a production-oriented Windows-first ambient time tracking solution named FlowCore.

## Core product intent
- Treat FlowCore as **one application with multiple densities**, not as separate tray and sidebar apps.
- The UI must feel modern, calm, premium, and non-intrusive.
- The product must avoid “surveillance software” vibes.
- The desktop context may be used for presentation and activation, but human intent must remain explicit.
- AI is assistant-only. It must never pretend to know whether a user was on the toilet, talking to a colleague, or otherwise away from the desk.

## Technical stack
- Visual Studio 2026
- C# 14
- .NET 10
- SLNX solution file format
- Windows-first client
- SignalR for realtime synchronization
- REST API for persistence, querying, reports, and fallback
- Offline-first local state engine

## Architecture rules
- Prefer Clean Architecture boundaries.
- Keep domain logic independent of UI and infrastructure.
- Favor explicit models over primitive obsession.
- Use dependency injection consistently.
- Use Options pattern for configuration.
- Document architecture decisions in ADR files.
- Favor small, composable services over large god classes.

## UI rules
- The client must support multi-monitor environments without assuming one hard-coded primary monitor.
- Use the current interaction context as the display anchor.
- Design three UI densities:
  - Dormant
  - Compact
  - Focus
- Keep text short.
- Avoid clutter.
- Prefer stateful action tiles over traditional menus where sensible.
- Use subtle animations and fade transitions, not noisy motion.

## Domain rules
- Support these explicit user states:
  - Work
  - Sync / colleague exchange
  - Short away
  - Out of office
  - Break
  - End of day
- Respect configurable flex-time models and correction windows.
- Corrections outside the allowed window must require workflow handling.
- Build in auditability and traceability.
- Consider a fixed lunch break at 12:00 PM (Europe/Berlin) in work planning.

## Quality rules
- Generate XML documentation comments for public APIs and important domain types.
- Write unit tests for domain rules, policies, correction windows, and conflict handling.
- Prefer deterministic tests.
- Avoid hidden time dependencies; use abstractions for clock/time providers.
- Favor clear naming and maintainability over cleverness.

## Documentation rules
- Keep docs in the docs folder.
- Provide Mermaid diagrams where useful.
- Maintain:
  - product vision
  - solution architecture
  - deployment guide
  - API overview
  - ADRs
  - diagrams
- Documentation should be understandable by developers, product stakeholders, and a fictional customer acceptance audience.
- Actively consider documentation responsibilities at each milestone and deliver consistent documentation.
- Regularly update central documentation files like README.md to ensure they are not left in an initial state.

## Delivery mindset
- Produce code and documentation as if this repository could be handed to a customer for acceptance and go-live preparation.
- Include pragmatic assumptions when exact requirements are missing.
- Prefer completeness with stated assumptions over stalling for clarification.
