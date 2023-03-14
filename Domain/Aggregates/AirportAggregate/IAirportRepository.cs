using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository : IRepository<Airport>
    {
        Airport Add(Airport airport);

        void Update(Airport airport);

        Task<Airport> GetAsync(Guid airportId);
        /// <summary>
        /// Gets the airport query.
        /// </summary>
        /// <returns></returns>
        IQueryable<Airport> GetAirports();
    }
}