using SpeedyAir.Interface;
using SpeedyAir.Model;
using System;
using System.Collections.Generic;

namespace SpeedyAir.Service
{
    public class FlightSchedulesRepository : IFlightSchedulesRepository
    {
        public List<Flights> GetSchedules()
        {
            // Returning a hardcoded list of flights
            return new List<Flights>
            {
                new Flights { FlightNumber = 1, Departure = "YUL", Arrival = "YYZ", Day = 1 },
                new Flights { FlightNumber = 2, Departure = "YUL", Arrival = "YYC", Day = 1 },
                new Flights { FlightNumber = 3, Departure = "YUL", Arrival = "YVR", Day = 1 },
                new Flights { FlightNumber = 4, Departure = "YUL", Arrival = "YYZ", Day = 2 },
                new Flights { FlightNumber = 5, Departure = "YUL", Arrival = "YYC", Day = 2 },
                new Flights { FlightNumber = 6, Departure = "YUL", Arrival = "YVR", Day = 2 }
            };
        }
        // Method to display the flight schedules
        public void DisplaySchedules(List<Flights> flights)
        {
            foreach (var items in flights)
            {
                Console.WriteLine(items); // This calls the overridden ToString method
            }
        }
    }
}
