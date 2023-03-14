#region References
using System;
#endregion

#region Namespace
namespace API.Application.ViewModels
{
    public class FlightViewModel
    {
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset DepartureDateTime { get; set; }
        public DateTimeOffset ArrivalDateTime { get; set; }
        public decimal LowestPrice { get; set; }
    }
}
#endregion
