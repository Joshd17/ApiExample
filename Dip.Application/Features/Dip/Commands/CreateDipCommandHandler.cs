using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dip.Domain.Aggregates;
using Dip.Domain.Repositories;

namespace Dip.Application.Features.Dip.Commands
{
    public class CreateDipCommandHandler : IRequestHandler<CreateDipCommand>
    {
        private readonly IRepository<DecisionInPrinciple> _dipRepository;

        public CreateDipCommandHandler(IRepository<DecisionInPrinciple> dipRepository)
        {
            _dipRepository = dipRepository;
        }

        public async Task<Unit> Handle(CreateDipCommand request, CancellationToken cancellationToken)
        {
            var dip = new DecisionInPrinciple(request.dip.Name);
            await _dipRepository.Add(dip, cancellationToken);
            
            return default;
        }
    }


    public class CreateDipCommand : IRequest
    {
        public DecisionInPrinciple dip { get; set; }
    }

}
