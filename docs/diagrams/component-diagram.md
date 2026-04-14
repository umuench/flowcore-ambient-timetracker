# Component Diagram (Mermaid)

```mermaid
flowchart LR
    subgraph ClientSide[Windows Client]
        ClientShell[FlowCore.Client<br/>Dormant/Compact/Focus]
        LocalState[Local State Machine<br/>Offline Queue]
    end

    subgraph Backend[FlowCore Backend]
        Api[FlowCore.Api<br/>REST Fallback + Admin]
        Hub[FlowCore.SignalR<br/>PresenceHub]
        App[FlowCore.Application<br/>Use Cases]
        Domain[FlowCore.Domain<br/>Policies + Workday]
        Infra[FlowCore.Infrastructure<br/>Repos, Options, Audit Store]
    end

    subgraph AdminViews[Admin/HR]
        AdminUI[FlowCore.Admin]
    end

    ClientShell -->|Commands/Queries| Api
    ClientShell -->|Realtime subscribe| Hub
    LocalState -->|Replay on reconnect| Api
    Api --> App --> Domain
    App --> Infra
    Api --> Hub
    Hub --> ClientShell
    Hub --> AdminUI
    Api --> AdminUI
