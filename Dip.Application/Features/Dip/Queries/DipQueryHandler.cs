using Dip.Domain;
using Dip.Domain.Aggregates;
using Dip.Infrastructure.Contexts;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dip.Application.Features.Dip.Queries;

public class DipQueryHandler : IRequestHandler<DipQuery,IEnumerable<DipsWithAudits>>
{
    private readonly MongoContext _mongoContext;

    public DipQueryHandler(MongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }
    public async Task<IEnumerable<DipsWithAudits>> Handle(DipQuery request, CancellationToken cancellationToken)
    {
        var pipeline = new EmptyPipelineDefinition<DecisionInPrinciple>();

        var test = await _mongoContext.DipCollection.Aggregate().Lookup<DecisionInPrinciple, Audit, DipsWithAudits>(_mongoContext.AuditCollection,
            dip => dip.Id,
            lookupValue => lookupValue.ObjectId,
            test => test.Audits).ToListAsync(cancellationToken);

        return test;
    }
}

public class DipsWithAudits
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Question> Questions { get; private set; }
    public IEnumerable<Audit> Audits { get; set; }
}

public class DipQuery : IRequest<IEnumerable<DipsWithAudits>>
{
    public bool IncludeAudits { get; set; } = false;
}