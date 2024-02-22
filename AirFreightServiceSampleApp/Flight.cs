using System;
using System.Collections.Generic;

namespace AirFreightServiceSampleApp
{
    public class Flight : IFlight
    {
        public int FlightNo { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
        
        public void GetFlightDetails()
        {
            var flights = new List<Flight>();
            var objRepo= new Repository();
            flights = objRepo.LoadFlightDetails();

            Console.WriteLine("User Story #1");
            foreach (var activeFlight in flights)
            {
                Console.WriteLine("Flight: " + activeFlight.FlightNo + "," + " departure: " + activeFlight.Departure + "," + " arrival: " + activeFlight.Arrival + "," + " day: " + activeFlight.Day);
            }
            Console.WriteLine("Please Press Enter Key...");
            Console.ReadLine();
        }
    }
}
