using SpeedyAir.Model;
using System.Collections.Generic;

namespace SpeedyAir.Interface
{
    public interface IFlightSchedulesRepository
    {
        // Returns a List of Flights 
        List<Flights> GetSchedules();
        // Accepts a List of Flights and handles the presentation
        void DisplaySchedules(List<Flights> flights);
    }
}
