using SpeedyAir.Interface;
using System;
using System.Linq;

namespace SpeedyAir
{
    public class App
    {
        private readonly IFlightSchedulesRepository _flightSchedulesRepository;
        private readonly IOrderScheduler _orderScheduler;

        public App(IFlightSchedulesRepository flightSchedulesRepository, IOrderScheduler orderScheduler)
        {
            _flightSchedulesRepository = flightSchedulesRepository;
            _orderScheduler = orderScheduler;
        }

        public void Run()
        {
            // Fetching flight schedules
            var flights = _flightSchedulesRepository.GetSchedules();
            
            HorizontalLine();
            // Delegating the display logic to the repository
            _flightSchedulesRepository.DisplaySchedules(flights);
            HorizontalLine();

            Console.WriteLine("Displaying Order");
            HorizontalLine();
            // Load Orders
            var orders = _orderScheduler.LoadOrders();
            if (orders != null)
            {
                // Assign Orders to Flights and Display Itineraries
                _orderScheduler.AssignOrdersToFlights(orders, flights);
                _orderScheduler.DisplayOrders(orders);
            }
            HorizontalLine();

            ExitCode();
        }
        public void HorizontalLine()
        {
            Console.WriteLine("====================================================" + "\n");
        }
        public void ExitCode()
        {
            Console.WriteLine("Press any key to exit!");
            // Waiting for user input to exit
            Console.ReadKey();
        }
    }
}
