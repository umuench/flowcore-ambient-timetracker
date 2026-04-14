using FlowCore.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FlowCore.Infrastructure.Persistence;

/// <summary>
/// Initialisiert die Datenbank für den konfigurierten Persistenzprovider.
/// </summary>
public static class FlowCoreDatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        var options = scope.ServiceProvider.GetRequiredService<IOptions<PersistenceOptions>>().Value;
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("FlowCoreDatabaseInitializer");

        if (!string.Equals(options.Provider, "PostgreSql", StringComparison.OrdinalIgnoreCase)
            || !options.EnsureCreatedOnStartup)
        {
            logger.LogInformation("Skipping database initialization. Provider: {Provider}", options.Provider);
            return;
        }

        var dbContext = scope.ServiceProvider.GetRequiredService<FlowCoreDbContext>();
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
        logger.LogInformation("Database ensured successfully for PostgreSQL provider.");
    }
}
