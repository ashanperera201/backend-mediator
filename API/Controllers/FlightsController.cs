#region References
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
#endregion


#region Namespace
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<FlightsController> _logger;
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightsController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mediator">The mediator.</param>
        public FlightsController(
            ILogger<FlightsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        /// <summary>
        /// Gets the available flights.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> GetAvailableFlights(CancellationToken cancellationToken)
        {
            try
            {
                var availableFlights = await _mediator.Send(new GetFlightQuery(), cancellationToken);
                return StatusCode(availableFlights != null && availableFlights.Count > 0 ? StatusCodes.Status200OK : StatusCodes.Status204NoContent, availableFlights);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }

}
#endregion
