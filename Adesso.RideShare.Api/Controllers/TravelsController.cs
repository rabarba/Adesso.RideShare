using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Adesso.RideShare.Api.Application.Travel.Commands.TravelCreate;
using Adesso.RideShare.Api.Application.Travel.Commands.TravelDropPublish;
using Adesso.RideShare.Api.Application.Travel.Commands.TravelJoin;
using Adesso.RideShare.Api.Application.Travel.Commands.TravelPublish;
using Adesso.RideShare.Api.Application.Travel.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.RideShare.Api.Controllers
{
    [Route("api/travels")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TravelCreateDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]TravelCreateCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPut]
        [Route("publish")]
        [ProducesResponseType(typeof(TravelPublishDto), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody]TravelPublishCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPut]
        [Route("drop")]
        [ProducesResponseType(typeof(TravelDropPublishDto), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody]TravelDropPublishCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPut]
        [Route("join")]
        [ProducesResponseType(typeof(TravelJoinDto), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody]TravelJoinCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TravelSearchDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery]TravelSearchQuery command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }
    }
}