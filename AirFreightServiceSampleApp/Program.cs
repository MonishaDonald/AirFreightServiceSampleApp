namespace AirFreightServiceSampleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var objOrder = new Order();
            var objFlight = new Flight();
            objFlight.GetFlightDetails();
            objOrder.GetOrderDetails();
        }
    }
}
