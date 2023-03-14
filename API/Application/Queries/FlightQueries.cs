#region References
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
#endregion


#region Namespace
namespace API.Application.Queries
{
    /// <summary>
    /// GetFlightQuery
    /// </summary>
    /// <seealso cref="MediatR.IRequest&lt;System.Collections.Generic.List&lt;API.Application.ViewModels.FlightViewModel&gt;&gt;" />
    /// <seealso cref="MediatR.IBaseRequest" />
    /// <seealso cref="System.IEquatable&lt;API.Application.Queries.GetFlightQuery&gt;" />
    public record GetFlightQuery : IRequest<List<FlightViewModel>>;
    /// <summary>
    /// FlightQueries
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler&lt;API.Application.Queries.GetFlightQuery, System.Collections.Generic.List&lt;API.Application.ViewModels.FlightViewModel&gt;&gt;" />
    public class FlightQueries : IRequestHandler<GetFlightQuery, List<FlightViewModel>>
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The flight repository
        /// </summary>
        private readonly IFlightRepository _flightRepository;
        /// <summary>
        /// The airport repository
        /// </summary>
        private readonly IAirportRepository _airportRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightQueries"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="flightRepository">The flight repository.</param>
        public FlightQueries(IMapper mapper, IFlightRepository flightRepository, IAirportRepository airportRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<FlightViewModel>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flights = _flightRepository.GetAllAvailableFlights();
            var airports = _airportRepository.GetAirports();

            return await (
                            from flight in flights
                            select new FlightViewModel
                            {
                                ArrivalDateTime = flight.Arrival,
                                ArrivalAirportCode = airports.Where(x => x.Id == flight.DestinationAirportId).FirstOrDefault().Code,
                                DepartureDateTime = flight.Departure,
                                DepartureAirportCode = airports.Where(x => x.Id == flight.OriginAirportId).FirstOrDefault().Code,
                                LowestPrice = flight.Rates.OrderBy(x => x.Price.Value).First().Price.Value,
                            }
                         ).ToListAsync(cancellationToken);
        }
    }
}
#endregion
