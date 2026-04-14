# PostgreSQL Setup (Local)

## Ziel
Lokale PostgreSQL-Datenbank für FlowCore bereitstellen.

## Beispiel mit `psql`
```sql
CREATE USER flowcore WITH PASSWORD 'flowcore';
CREATE DATABASE flowcore OWNER flowcore;
GRANT ALL PRIVILEGES ON DATABASE flowcore TO flowcore;
```

## API-Konfiguration
In `src/FlowCore.Api/appsettings.json`:

- `Persistence:Provider` auf `PostgreSql` setzen
- `ConnectionStrings:FlowCore` auf deine Instanz anpassen

Beispiel:
```json
"ConnectionStrings": {
  "FlowCore": "Host=localhost;Port=5432;Database=flowcore;Username=flowcore;Password=flowcore"
},
"Persistence": {
  "Provider": "PostgreSql",
  "ConnectionStringName": "FlowCore",
  "EnsureCreatedOnStartup": true
}
```

## Start
```bash
dotnet run --project src/FlowCore.Api/FlowCore.Api.csproj
```

Beim Start erstellt `EnsureCreatedOnStartup=true` das benötigte Schema automatisch.
