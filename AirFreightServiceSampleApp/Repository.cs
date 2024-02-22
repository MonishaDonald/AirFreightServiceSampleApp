using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AirFreightServiceSampleApp
{
    public class Repository
    {
        public List<Flight> LoadFlightDetails()
        {
            List<Flight> flightsList = new List<Flight>();
            flightsList.Add(new Flight { FlightNo = 1, Departure = "YUL", Arrival = "YYZ", Day = 1 });
            flightsList.Add(new Flight { FlightNo = 2, Departure = "YUL", Arrival = "YYC", Day = 1 });
            flightsList.Add(new Flight { FlightNo = 3, Departure = "YUL", Arrival = "YVR", Day = 1 });
            flightsList.Add(new Flight { FlightNo = 4, Departure = "YUL", Arrival = "YYZ", Day = 2 });
            flightsList.Add(new Flight { FlightNo = 5, Departure = "YUL", Arrival = "YYC", Day = 2 });
            flightsList.Add(new Flight { FlightNo = 6, Departure = "YUL", Arrival = "YVR", Day = 2 });
            if (flightsList?.Count > 0)
                return flightsList;
            else
                return null;
        }

        public Dictionary<string, Order> LoadJson()
        {
            try
            {
                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"coding-assigment-orders.json");
                string json = System.IO.File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(json))
                {
                    var ordersList = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
                    if (ordersList?.Count > 0)
                        return ordersList;
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
