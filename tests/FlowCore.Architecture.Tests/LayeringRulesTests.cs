using Xunit;

namespace FlowCore.Architecture.Tests;

public sealed class LayeringRulesTests
{
    [Fact]
    public void Client_DoesNotReferenceInfrastructureOrApi()
    {
        var references = typeof(FlowCore.Client.ClientModule).Assembly.GetReferencedAssemblies()
            .Select(a => a.Name)
            .Where(name => name is not null)
            .ToHashSet(StringComparer.Ordinal);

        Assert.DoesNotContain("FlowCore.Infrastructure", references);
        Assert.DoesNotContain("FlowCore.Api", references);
    }

    [Fact]
    public void Api_ReferencesApplicationAndInfrastructure()
    {
        var references = typeof(Program).Assembly.GetReferencedAssemblies()
            .Select(a => a.Name)
            .Where(name => name is not null)
            .ToHashSet(StringComparer.Ordinal);

        Assert.Contains("FlowCore.Application", references);
        Assert.Contains("FlowCore.Infrastructure", references);
    }
}
