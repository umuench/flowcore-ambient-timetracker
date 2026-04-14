# Configuration

## appsettings Sections

### `ConnectionStrings`
- `FlowCore`: PostgreSQL-Verbindungszeichenfolge (wenn `Persistence:Provider=PostgreSql`).

### `Persistence`
- `Provider`: `InMemory` oder `PostgreSql`
- `ConnectionStringName`: Name aus `ConnectionStrings`
- `EnsureCreatedOnStartup`: erstellt Schema beim Start automatisch (PostgreSql)

### `OfflineSync`
- `MaxQueueLength`: Maximale lokale Queue-Länge im Client-Sync-Pfad.

### `RealtimeSync`
- `ReconnectDelaySeconds`: Initiale Reconnect-Verzögerung.
- `MaxReconnectDelaySeconds`: Obergrenze der Verzögerung.
- `EnableRestFallback`: Aktiviert REST als Fallbackpfad.

### `Reconciliation`
- `MaxReplayBatchSize`: Größe der Replay-Batches nach Offline-Phase.
- `UseIdempotencyKeys`: Doppelverarbeitungsschutz im Replay.

## Logging
- `Logging:LogLevel:Default`
- `Logging:LogLevel:Microsoft.AspNetCore`

## Rollen für Admin-Endpunkte
- `Admin`
- `Hr`
- `TeamLead`
