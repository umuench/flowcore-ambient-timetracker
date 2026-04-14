using FlowCore.Client.Ui;
using FlowCore.Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FlowCore.Client;

/// <summary>
/// Einstiegspunkt für die Windows-Client-Komposition.
/// </summary>
public static class ClientModule
{
    public static IServiceCollection AddFlowCoreClient(this IServiceCollection services)
    {
        services.AddSingleton<ClientUiStateMachine>();
        services.AddTransient<ClientShellViewModel>();
        return services;
    }
}
