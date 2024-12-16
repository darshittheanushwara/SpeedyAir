namespace SpeedyAir.Model
{
    public class Order
    {
        public string OrderId { get; set; }
        public string Destination { get; set; }
        public string Service { get; set; }
        public int ServiceID { get; set; }
        public int? FlightNumber { get; set; }

        public Flights AssignedFlight { get; set; }  // Navigation property
    }
}
