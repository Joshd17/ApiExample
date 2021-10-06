using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dip.Application.Features.Dip.Queries
{
    public class DipQueryHandler : IRequestHandler<DipQuery>
    {
        public Task<Unit> Handle(DipQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class DipQuery : IRequest
    {

    }

}
