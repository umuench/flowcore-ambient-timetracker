using Xunit;
using FlowCore.Application.Abstractions;
using FlowCore.Application.Commands;
using FlowCore.Application.Services;
using FlowCore.Domain.Approvals;
using FlowCore.Domain.Policies;
using FlowCore.Domain.Workdays;

namespace FlowCore.Application.Tests;

public sealed class WorkdayApplicationServiceTests
{
    [Fact]
    public async Task CorrectTimeEntryAsync_CreatesApprovalRequest_WhenOutsideCorrectionWindow()
    {
        var clock = new FakeClock(new DateTimeOffset(2026, 1, 12, 12, 0, 0, TimeSpan.Zero));
        var workdayRepo = new FakeWorkdayRepository();
        var policyProvider = new FakePolicyProvider(new CorrectionWindowPolicy(TimeSpan.FromMinutes(30)), new BreakPolicy(TimeSpan.FromHours(6), TimeSpan.FromMinutes(30)));
        var approvalRepo = new FakeApprovalRequestRepository();
        var publisher = new FakePublisher();

        var workday = await workdayRepo.GetOrCreateAsync(Guid.Parse("5f287f42-8f57-4a2f-8bf2-9955ab2f8f8a"), new DateOnly(2026, 1, 12), CancellationToken.None);
        workday.AddEntry(FlowCore.Domain.PresenceState.Work, clock.UtcNow.AddHours(-2));
        var entryId = workday.Entries.Single().Id;

        var sut = new WorkdayApplicationService(clock, workdayRepo, policyProvider, approvalRepo, publisher);

        var result = await sut.CorrectTimeEntryAsync(
            new CorrectTimeEntryCommand(workday.EmployeeId, entryId, clock.UtcNow.AddHours(-1), "Late correction"),
            CancellationToken.None);

        Assert.False(result.WasCorrected);
        Assert.True(result.RequiresApproval);
        Assert.Single(approvalRepo.Stored);
    }

    private sealed class FakeClock : IClock
    {
        public FakeClock(DateTimeOffset utcNow) => UtcNow = utcNow;
        public DateTimeOffset UtcNow { get; }
    }

    private sealed class FakeWorkdayRepository : IWorkdayRepository
    {
        private readonly Dictionary<string, Workday> _store = new();

        public Task<Workday> GetOrCreateAsync(Guid employeeId, DateOnly date, CancellationToken cancellationToken)
        {
            var key = $"{employeeId:N}:{date:yyyyMMdd}";
            if (!_store.TryGetValue(key, out var workday))
            {
                workday = new Workday(Guid.NewGuid(), employeeId, date);
                _store[key] = workday;
            }

            return Task.FromResult(workday);
        }

        public Task SaveAsync(Workday workday, CancellationToken cancellationToken)
        {
            _store[$"{workday.EmployeeId:N}:{workday.Date:yyyyMMdd}"] = workday;
            return Task.CompletedTask;
        }
    }

    private sealed class FakePolicyProvider : IPolicyProvider
    {
        private readonly CorrectionWindowPolicy _correctionWindowPolicy;
        private readonly BreakPolicy _breakPolicy;

        public FakePolicyProvider(CorrectionWindowPolicy correctionWindowPolicy, BreakPolicy breakPolicy)
        {
            _correctionWindowPolicy = correctionWindowPolicy;
            _breakPolicy = breakPolicy;
        }

        public Task<CorrectionWindowPolicy> GetCorrectionWindowPolicyAsync(Guid employeeId, CancellationToken cancellationToken)
            => Task.FromResult(_correctionWindowPolicy);

        public Task<BreakPolicy> GetBreakPolicyAsync(Guid employeeId, CancellationToken cancellationToken)
            => Task.FromResult(_breakPolicy);
    }

    private sealed class FakeApprovalRequestRepository : IApprovalRequestRepository
    {
        public List<ApprovalRequest> Stored { get; } = new();

        public Task SaveAsync(ApprovalRequest request, CancellationToken cancellationToken)
        {
            Stored.Add(request);
            return Task.CompletedTask;
        }
    }

    private sealed class FakePublisher : IDomainEventPublisher
    {
        public Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
