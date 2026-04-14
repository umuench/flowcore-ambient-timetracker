# Deployment Diagram (Mermaid)

```mermaid
flowchart TB
    UserPC[User Windows Device\nFlowCore.Client] --> Internet[(Corporate Network)]
    AdminPC[HR/Admin Device\nFlowCore.Admin] --> Internet

    Internet --> ApiHost[App Host\nFlowCore.Api + SignalR Hub]

    ApiHost --> Config[Configuration\nappsettings + env vars]
    ApiHost --> LogSink[Central Logging / SIEM]
    ApiHost --> AuditStore[AuditTrailStore\n(persistenznah, aktuell in-memory baseline)]

    ApiHost --> Repo[Workday/Approval Repository\n(in-memory baseline, später DB)]
```
