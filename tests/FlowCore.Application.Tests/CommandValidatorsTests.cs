using FlowCore.Application.Commands;
using FlowCore.Application.Validation;
using Xunit;

namespace FlowCore.Application.Tests;

public sealed class CommandValidatorsTests
{
    [Fact]
    public void StartWorkValidator_ReturnsFailure_WhenUserIdIsEmpty()
    {
        var sut = new StartWorkCommandValidator();

        var result = sut.Validate(new StartWorkCommand(Guid.Empty, null));

        Assert.False(result.IsValid);
        Assert.Contains("UserId is required.", result.Errors);
    }

    [Fact]
    public void CorrectTimeEntryValidator_ReturnsMultipleErrors_ForInvalidCommand()
    {
        var sut = new CorrectTimeEntryCommandValidator();

        var result = sut.Validate(new CorrectTimeEntryCommand(Guid.Empty, Guid.Empty, DateTimeOffset.UtcNow, string.Empty));

        Assert.False(result.IsValid);
        Assert.Equal(3, result.Errors.Count);
    }
}
