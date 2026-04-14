using FlowCore.Application.Abstractions;
using FlowCore.Domain.Approvals;
using FlowCore.Infrastructure.Persistence;
using FlowCore.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// PostgreSQL-Repository für Genehmigungsanfragen.
/// </summary>
public sealed class PostgreSqlApprovalRequestRepository : IApprovalRequestRepository
{
    private readonly FlowCoreDbContext _dbContext;

    /// <summary>
    /// Initialisiert das Repository mit DbContext.
    /// </summary>
    /// <param name="dbContext">Der DbContext, der für den Zugriff auf die Datenbank verwendet wird.</param>
    public PostgreSqlApprovalRequestRepository(FlowCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Speichert oder aktualisiert eine Genehmigungsanfrage.
    /// </summary>
    public async Task SaveAsync(ApprovalRequest request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ApprovalRequests.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
        {
            _dbContext.ApprovalRequests.Add(new ApprovalRequestEntity
            {
                Id = request.Id,
                EmployeeId = request.EmployeeId,
                Reason = request.Reason,
                RequestedAt = request.RequestedAt,
            });
        }
        else
        {
            entity.EmployeeId = request.EmployeeId;
            entity.Reason = request.Reason;
            entity.RequestedAt = request.RequestedAt;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
