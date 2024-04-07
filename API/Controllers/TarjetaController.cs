using API.Core.Application.Features.FeatureTarjeta.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static API.Core.Application.Features.FeatureTarjeta.Commands.AddTarjeta;
using static API.Core.Application.Features.FeatureTarjeta.Queries.GetAllTarjetas;
using static API.Core.Application.Features.FeatureTarjeta.Queries.GetTarjetaById;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : Controller
    {
        private readonly IMediator mediator;

        public TarjetaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TarjetasCreditoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<TarjetasCreditoDto>>> Get()
        {
            return Ok(await mediator.Send(new GetAllTarjetasQuery()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TarjetasCreditoDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TarjetasCreditoDto>> GetById(int id, string? NumeroTarjeta)
        {
            return Ok(await mediator.Send(new GetTarjetaByIdQuery(id, NumeroTarjeta)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post(AddTarjetaCommand request)
        {
            return Ok(await mediator.Send(request));
        }

    }
}
