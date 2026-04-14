using FlowCore.Api.Admin;
using FlowCore.Api.Realtime;
using FlowCore.Application.Abstractions;
using FlowCore.Application.Commands;
using FlowCore.Application.Queries;
using FlowCore.Application.Services;
using FlowCore.Contracts.Realtime;
using FlowCore.Contracts.Workdays;
using FlowCore.Domain;
using FlowCore.Infrastructure;
using FlowCore.Infrastructure.Persistence;
using FlowCore.Infrastructure.Services;
using FlowCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddFlowCoreInfrastructure(builder.Configuration);
builder.Services.AddSingleton<StatusCatalog>();
builder.Services.AddScoped<WorkdayApplicationService>();
builder.Services.AddScoped<IDomainEventPublisher, SignalRDomainEventPublisher>();

var app = builder.Build();

await FlowCoreDatabaseInitializer.InitializeAsync(app.Services);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/statuses", (StatusCatalog catalog) => Results.Ok(catalog.GetAll()));

app.MapPost("/api/presence/change", async (BookTimeRequestDto request, WorkdayApplicationService service, CancellationToken ct) =>
{
    if (!Enum.TryParse<PresenceState>(request.PresenceState, true, out var state))
    {
        return Results.BadRequest("Invalid presence state.");
    }

    var entry = await service.ChangePresenceAsync(new ChangePresenceStateCommand(request.UserId, state, request.Note), ct);
    return Results.Ok(entry);
});

app.MapPost("/api/presence/start-day", async (BookTimeRequestDto request, WorkdayApplicationService service, CancellationToken ct) =>
{
    var entry = await service.StartWorkAsync(new StartWorkCommand(request.UserId, request.Note), ct);
    return Results.Ok(entry);
});

app.MapPost("/api/presence/end-day", async (BookTimeRequestDto request, WorkdayApplicationService service, CancellationToken ct) =>
{
    var entry = await service.EndWorkAsync(new EndWorkdayCommand(request.UserId, request.Note), ct);
    return Results.Ok(entry);
});

app.MapPost("/api/presence/start-break", async (BookTimeRequestDto request, WorkdayApplicationService service, CancellationToken ct) =>
{
    var entry = await service.StartBreakAsync(new StartBreakCommand(request.UserId, request.Note), ct);
    return Results.Ok(entry);
});

app.MapPost("/api/presence/end-break", async (BookTimeRequestDto request, WorkdayApplicationService service, CancellationToken ct) =>
{
    var entry = await service.EndBreakAsync(new EndBreakCommand(request.UserId, request.Note), ct);
    return Results.Ok(entry);
});

app.MapPost("/api/workdays/correct", async (CorrectTimeEntryRequestDto request, WorkdayApplicationService service, CancellationToken ct) =>
{
    var result = await service.CorrectTimeEntryAsync(
        new CorrectTimeEntryCommand(request.UserId, request.TimeEntryId, request.CorrectedTimestamp, request.Reason),
        ct);

    return Results.Ok(result);
});

app.MapGet("/api/workdays/{userId:guid}/{date}", async (Guid userId, DateOnly date, IWorkdayRepository repository, CancellationToken ct) =>
{
    var workday = await repository.GetOrCreateAsync(userId, date, ct);
    return Results.Ok(workday);
});

app.MapGet("/api/workdays/{userId:guid}/{date}/conflicts", async (Guid userId, DateOnly date, WorkdayApplicationService service, CancellationToken ct) =>
{
    var conflicts = await service.DetectConflictsAsync(userId, date, ct);
    return Results.Ok(conflicts);
});

app.MapGet("/api/admin/live-status", (string? role, LiveStatusStore store) =>
{
    return RoleGuards.CanAccessAdmin(role) ? Results.Ok(store.GetAll()) : Results.StatusCode(StatusCodes.Status403Forbidden);
});

app.MapGet("/api/admin/audit", (string? role, AuditTrailStore store) =>
{
    return RoleGuards.CanAccessAdmin(role) ? Results.Ok(store.GetLatest()) : Results.StatusCode(StatusCodes.Status403Forbidden);
});

app.MapPost("/api/admin/policies/broadcast", async (string? role, string policyKey, IDomainEventPublisher publisher, CancellationToken ct) =>
{
    if (!RoleGuards.CanAccessAdmin(role))
    {
        return Results.StatusCode(StatusCodes.Status403Forbidden);
    }

    await publisher.PublishAsync(new PolicyUpdatedEvent(policyKey, role ?? "unknown", DateTimeOffset.UtcNow), ct);
    return Results.Accepted();
});

app.MapHub<PresenceHub>("/hubs/presence");

app.Run();

public partial class Program;
