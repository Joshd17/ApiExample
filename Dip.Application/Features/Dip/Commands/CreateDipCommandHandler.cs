using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dip.Domain.Aggregates;
using Dip.Domain.Repositories;
using Dip.Infrastructure.Contexts;
using MongoDB.Driver;

namespace Dip.Application.Features.Dip.Commands;

public class CreateDipCommandHandler : IRequestHandler<CreateDipCommand>
{
    private readonly IRepository<DecisionInPrinciple> _dipRepository;
    private readonly MongoContext _mongoContext;
    private readonly IMediator _mediator;

    public CreateDipCommandHandler(MongoContext mongoContext, IMediator mediator)
    {
        _mongoContext = mongoContext;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(CreateDipCommand request, CancellationToken cancellationToken)
    {
        var dip = new DecisionInPrinciple(request.dip);
        await _mongoContext.DipCollection.InsertOneAsync(dip, new InsertOneOptions(), cancellationToken);
        //await _dipRepository.Add(dip, cancellationToken);

        foreach (var dipDomainEvent in dip.DomainEvents)
        {
            await _mediator.Publish(dipDomainEvent, cancellationToken);
        }

        return default;
    }
}


public class CreateDipCommand : IRequest
{
    public string dip { get; set; }
}