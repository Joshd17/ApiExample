using Dip.Application.Features.Dip.Commands;
using Dip.Application.Features.Dip.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiExample.Controllers;

[ApiController]
[Route("[controller]")]
public class DipController : ControllerBase
{
    private readonly IMediator _mediator;

    public DipController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<DipsWithAudits>> Get()
    {
        var result = await _mediator.Send(new DipQuery());

        return result;
    }

    [HttpPost]
    public async Task<ActionResult> Post(string? param)
    {
        await _mediator.Send(new CreateDipCommand(){dip = param ?? "A sample name"});
        return default;
    }
}