using Dip.Domain;
using Dip.Domain.Aggregates;
using Dip.Infrastructure.Contexts;
using MediatR;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dip.Application.Features.Auditing;

public class AuditNotificationHandler<TNotification> : INotificationHandler<TNotification>
    where TNotification : CreatedDomainEvent
{
    private readonly MongoContext _context;

    public AuditNotificationHandler(MongoContext context)
    {
        _context = context;
    }

    public async Task Handle(TNotification notification, CancellationToken cancellationToken)
    {

        var audit = new Audit
        {
            CreationDate = DateTime.UtcNow,
            Item = notification,
            ObjectId = notification.ObjectId
        };

        await _context.AuditCollection.InsertOneAsync(audit, new InsertOneOptions(), cancellationToken);
    }
}