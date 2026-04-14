using FlowCore.Application.Abstractions;
using FlowCore.Infrastructure.Options;
using FlowCore.Infrastructure.Services;
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

        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<ISystemClock>(sp => (ISystemClock)sp.GetRequiredService<IClock>());

        services.AddSingleton<IWorkdayRepository, InMemoryWorkdayRepository>();
        services.AddSingleton<IPolicyProvider, StaticPolicyProvider>();
        services.AddSingleton<IApprovalRequestRepository, InMemoryApprovalRequestRepository>();

        services.AddSingleton<LiveStatusStore>();
        services.AddSingleton<AuditTrailStore>();

        return services;
    }
}
