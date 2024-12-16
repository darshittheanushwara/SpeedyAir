using Newtonsoft.Json;
using SpeedyAir.Interface;
using SpeedyAir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpeedyAir.Services
{
    public class OrderScheduler : IOrderScheduler
    {
        public List<Order> LoadOrders()
        {
            try
            {
                // Get the directory of the executing assembly
                var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var path = GetDirectory + "/coding-assigment-orders.json";
                if (!File.Exists(path))
                {
                    Console.WriteLine("The orders file does not exist.");
                    return null;
                }
                // Read the JSON content from the file
                var json = File.ReadAllText(path);

                // Deserialize JSON to a Dictionary with OrderId as key and Order as value
                var ordersDictionary = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
                return ordersDictionary.Select(Od =>
                {

                    var order = Od.Value;
                    Od.Value.Service = Od.Value.Service == null ? "regular" : Od.Value.Service;
                    order.OrderId = Od.Key;
                    order.Service = Od.Value.Service;
                    order.ServiceID = (int)Enum.Parse<ServiceTypes>(Od.Value.Service.Replace("-", "").ToLower());
                    return order;
                }).ToList();
            }
            catch (Exception ex)
            {
                // Handle errors when loading orders
                Console.WriteLine("Order not found!");
                return null;
            }

        }

        public void AssignOrdersToFlights(List<Order> orders, List<Flights> flights)
        {
            // Create a dictionary to track flight capacity 
            var flightCapacity = flights.ToDictionary(A => A.FlightNumber, A => 20);

            // Iterate over each order to assign it to an available flight
            foreach (var item in orders)
            {
                // Find an available flight based on destination and available capacity
                var assignedFlight = flights.FirstOrDefault(A =>
                    A.Arrival == item.Destination && flightCapacity[A.FlightNumber] > 0);

                if (assignedFlight != null)
                {
                    // Assign the flight details to the order
                    item.FlightNumber = assignedFlight.FlightNumber;
                    item.AssignedFlight = assignedFlight;  // Set the foreign key reference
                    flightCapacity[assignedFlight.FlightNumber]--;
                    assignedFlight.Orders.Add(item);  // add the order to the flight's Orders list
                }
            }
        }

        public void DisplayOrders(List<Order> orders)
        {
            // Order orders by FlightNumber and display details for each order
            foreach (var item in orders.OrderBy(A => A.ServiceID))
            {
                if (item.FlightNumber.HasValue)
                {
                    var flight = item.AssignedFlight;
                    if (flight != null)
                    {
                        Console.WriteLine($"order: {item.OrderId}, flightNumber: {item.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}, Service:{item.Service}");
                    }
                }
                else
                {
                    // Order is not scheduled
                    Console.WriteLine($"order: {item.OrderId}, flightNumber: not scheduled");
                }
            }
        }

        public void DisplayOrders(List<Order> orders, int FlightNumber)
        {
            orders = orders.Where(A => A.FlightNumber == FlightNumber).ToList();
            DisplayOrders(orders);
        }
    }
    public enum ServiceTypes
    {
        sameday,
        nextday,
        regular,
    }
}
