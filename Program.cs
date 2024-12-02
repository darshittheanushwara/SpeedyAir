using Microsoft.Extensions.DependencyInjection;
using SpeedyAir.Interface;
using SpeedyAir.Service;
using SpeedyAir.Services;

namespace SpeedyAir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setting up dependency injection container using ServiceCollection
            var serviceProvider = new ServiceCollection()
            .AddScoped<IFlightSchedulesRepository, FlightSchedulesRepository>()
            .AddScoped<IOrderScheduler, OrderScheduler>()
            .AddScoped<App>()
            .BuildServiceProvider();

            // This retrieves an instance of App and its dependencies   
            var app = serviceProvider.GetService<App>();
            app.Run();
        }
    }
}
