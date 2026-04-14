using FlowCore.Contracts.Security;

namespace FlowCore.Api.Admin;

/// <summary>
/// Einfache Rollenprüfung für Baseline-Endpunkte.
/// </summary>
public static class RoleGuards
{
    public static bool CanAccessAdmin(string? role)
    {
        return Enum.TryParse<RoleScope>(role, ignoreCase: true, out var parsed)
            && (parsed == RoleScope.Admin || parsed == RoleScope.Hr || parsed == RoleScope.TeamLead);
    }
}
