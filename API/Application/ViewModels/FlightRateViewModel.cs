#region References
using Domain.Common;
using System;
#endregion

#region Namespace
namespace API.Application.ViewModels
{
    public class FlightRateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public int Available { get; set; }
        public Guid FlightId { get; set; }
    }
}
#endregion