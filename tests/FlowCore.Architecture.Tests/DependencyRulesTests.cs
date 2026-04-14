using Xunit;
using System.Reflection;

namespace FlowCore.Architecture.Tests;

public sealed class DependencyRulesTests
{
    [Fact]
    public void Domain_DoesNotReferenceInfrastructureOrApi()
    {
        var references = typeof(FlowCore.Domain.WorkStatus).Assembly.GetReferencedAssemblies()
            .Select(a => a.Name)
            .Where(name => name is not null)
            .ToHashSet(StringComparer.Ordinal);

        Assert.DoesNotContain("FlowCore.Infrastructure", references);
        Assert.DoesNotContain("FlowCore.Api", references);
    }

    [Fact]
    public void Application_ReferencesDomain()
    {
        var references = typeof(FlowCore.Application.Commands.StartWorkCommand).Assembly.GetReferencedAssemblies()
            .Select(a => a.Name)
            .Where(name => name is not null)
            .ToHashSet(StringComparer.Ordinal);

        Assert.Contains("FlowCore.Domain", references);
    }
}
