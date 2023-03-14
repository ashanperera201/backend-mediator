#region References
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#endregion


#region Namespace
namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly FlightsContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Flight Add(Flight flight)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Flight> GetAllAvailableFlights()
        {
            return _context.Flights.Include(x => x.Rates).Where(x => x.Arrival <= DateTime.Now);
        }

        public Task<Flight> GetAsync(Guid flightId)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
#endregion
