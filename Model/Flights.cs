using System.Collections.Generic;

namespace SpeedyAir.Model
{
    public class Flights
    {
        public int FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, Departure: {Departure}, Arrival: {Arrival}, Day: {Day}";
        }
    }
}
