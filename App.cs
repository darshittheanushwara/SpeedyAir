using SpeedyAir.Interface;
using System;

namespace SpeedyAir
{
    public class App
    {
        private readonly IFlightSchedulesRepository _flightSchedulesRepository;

        public App(IFlightSchedulesRepository flightSchedulesRepository)
        {
            _flightSchedulesRepository = flightSchedulesRepository;
        }

        public void Run()
        {
            // Fetching flight schedules
            var flights = _flightSchedulesRepository.GetSchedules();

            // Displaying header for the flight schedules
            Console.WriteLine("Displaying Flight Schedule");
            HorizontalLine();
            // Delegating the display logic to the repository
            _flightSchedulesRepository.DisplaySchedules(flights);
            HorizontalLine();
            ExitCode();
        }
        public void HorizontalLine()
        {
            Console.WriteLine("==============================================");
        }
        public void ExitCode()
        {
            Console.WriteLine("Press any key to exit!");
            // Waiting for user input to exit
            Console.ReadKey();
        }
    }
}
