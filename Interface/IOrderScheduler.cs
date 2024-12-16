using SpeedyAir.Model;
using System.Collections.Generic;

namespace SpeedyAir.Interface
{
    public interface IOrderScheduler
    {
        // load orders from json file
        List<Order> LoadOrders();
        // assign orders to available flights based on destination and flight capacity
        void AssignOrdersToFlights(List<Order> orders, List<Flights> flights);
        // display orders along with their associated flight information
        void DisplayOrders(List<Order> orders);
        void DisplayOrders(List<Order> orders, int FlightNumber);

    }
}
