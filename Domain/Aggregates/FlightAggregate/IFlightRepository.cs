#region References
using Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
#endregion

#region Namespace

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Flight Add(Flight flight);

        void Update(Flight flight);

        Task<Flight> GetAsync(Guid flightId);
        IQueryable<Flight> GetAllAvailableFlights();
    }
}
#endregion