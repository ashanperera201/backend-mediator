using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Aggregates.CustomerAggregate;
using Infrastructure;

namespace API.Infrastructure.Seeds
{
    public class CustomerSeeder : FlightsContextSeeder
    {
        public CustomerSeeder(FlightsContext flightsContext) : base(flightsContext)
        {
        }
        public override void Seed()
        {
            if (FlightsContext.Customers.Any())
            {
                Console.WriteLine("Skipping Airports seeder because table is not empty.");
                return;
            }

            var customers = new List<Customer>()
            {
                new Customer("Ashan", "Perera", DateTime.Now),
            };

            FlightsContext.Customers.AddRange(customers);
            FlightsContext.SaveChanges();
        }
    }
}
