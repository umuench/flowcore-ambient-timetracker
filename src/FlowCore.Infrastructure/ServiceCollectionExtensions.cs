using FlowCore.Application.Abstractions;
using FlowCore.Infrastructure.Options;
using FlowCore.Infrastructure.Persistence;
using FlowCore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowCore.Infrastructure;

/// <summary>
/// Registriert Infrastructure-Services für API und Worker.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowCoreInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OfflineSyncOptions>(configuration.GetSection(OfflineSyncOptions.SectionName));
        services.Configure<RealtimeSyncOptions>(configuration.GetSection(RealtimeSyncOptions.SectionName));
        services.Configure<ReconciliationOptions>(configuration.GetSection(ReconciliationOptions.SectionName));
        services.Configure<PersistenceOptions>(configuration.GetSection(PersistenceOptions.SectionName));

        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<ISystemClock>(sp => (ISystemClock)sp.GetRequiredService<IClock>());

        var persistenceOptions = configuration.GetSection(PersistenceOptions.SectionName).Get<PersistenceOptions>() ?? new PersistenceOptions();

        if (string.Equals(persistenceOptions.Provider, "PostgreSql", StringComparison.OrdinalIgnoreCase))
        {
            var connectionString = configuration.GetConnectionString(persistenceOptions.ConnectionStringName)
                ?? throw new InvalidOperationException($"Missing connection string '{persistenceOptions.ConnectionStringName}' for PostgreSql provider.");

            services.AddDbContext<FlowCoreDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IWorkdayRepository, PostgreSqlWorkdayRepository>();
            services.AddScoped<IApprovalRequestRepository, PostgreSqlApprovalRequestRepository>();
        }
        else
        {
            services.AddSingleton<IWorkdayRepository, InMemoryWorkdayRepository>();
            services.AddSingleton<IApprovalRequestRepository, InMemoryApprovalRequestRepository>();
        }

        services.AddSingleton<IPolicyProvider, StaticPolicyProvider>();

        services.AddSingleton<LiveStatusStore>();
        services.AddSingleton<AuditTrailStore>();

        return services;
    }
}
