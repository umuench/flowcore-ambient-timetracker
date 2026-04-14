# Deployment Diagram (Mermaid)

```mermaid
flowchart TB
    UserPC[User Windows Device<br/>FlowCore.Client] --> Internet[(Corporate Network)]
    AdminPC[HR/Admin Device<br/>FlowCore.Admin] --> Internet

    Internet --> ApiHost[App Host<br/>FlowCore.Api + SignalR Hub]

    ApiHost --> Config[Configuration<br/>appsettings + env vars]
    ApiHost --> LogSink[Central Logging / SIEM]
    ApiHost --> AuditStore[AuditTrailStore<br/>In-memory baseline, later persistent]
    ApiHost --> Repo[Workday and Approval Repository<br/>In-memory baseline, later database]
