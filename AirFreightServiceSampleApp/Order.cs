using System;
using System.Collections.Generic;
using System.Linq;

namespace AirFreightServiceSampleApp
{
    public class Order:IOrder
    {
        public string Destination { get; set; }
        public bool IsScheduled { get; set; }
        public int Day {  get; set; }
        public int FlightNumber { get; set; }
        public string Departure { get; set; }

        public Dictionary<string, Order> ScheduleOrder(Dictionary<string,Order> activeOrdersList)
        {
            int fromOrder = 0;
            int toOrder = 0;
            Console.WriteLine("User Story #2");
            Console.WriteLine("Schedule Batch Orders");
            Console.Write("From Order Number:");
            fromOrder = Convert.ToInt32(Console.ReadLine());
            Console.Write("To Order Number:");
            toOrder = Convert.ToInt32(Console.ReadLine());
            foreach (var activeItem in activeOrdersList)
            {
                if (int.Parse(activeItem.Key.Substring(6, 3)) >= fromOrder
                     && int.Parse(activeItem.Key.Substring(6, 3)) <= toOrder)
                {
                    activeItem.Value.IsScheduled = true;
                }
            }
            return activeOrdersList;
        }

        /// <summary>
        /// Scheduled and unscheduled orders 
        /// </summary>
        public void GetOrderDetails()
        {
            var objRepo = new Repository();
            var activeOrdersList = objRepo.LoadJson();
            
            activeOrdersList = ScheduleOrder(activeOrdersList);

            if (activeOrdersList != null)
            {
                var TorontoOrders = activeOrdersList.Where(x => x.Value.Destination == "YYZ" && x.Value.IsScheduled == true).ToList().OrderBy(x => x.Key).ToList();
                var CalgaryOrders = activeOrdersList.Where(x => x.Value.Destination == "YYC" && x.Value.IsScheduled == true).ToList().OrderBy(x => x.Key).ToList();
                var VancouverOrders = activeOrdersList.Where(x => x.Value.Destination == "YVR" && x.Value.IsScheduled == true).ToList().OrderBy(x => x.Key).ToList(); ;

                var ScheduledOrderListDay = new List<KeyValuePair<string, Order>>();
                int torontoDay = 1;
                for (int i = 0; i < TorontoOrders.Count; i += 20)
                {
                    var torontoDayList = TorontoOrders.Skip(i).Take(20).ToList();
                    foreach (var item in torontoDayList)
                    {
                        item.Value.Day = torontoDay;
                        item.Value.Departure = "YUL";
                        item.Value.FlightNumber = torontoDay == 1 ? 1 : 4;
                    }
                    ScheduledOrderListDay.AddRange(torontoDayList);
                    torontoDay++;
                }

                int calgaryDay = 1;
                for (int i = 0; i < CalgaryOrders.Count; i += 20)
                {
                    var calgaryDayList = CalgaryOrders.Skip(i).Take(20).ToList();
                    foreach (var item in calgaryDayList)
                    {
                        item.Value.Day = calgaryDay;
                        item.Value.Departure = "YUL";
                        item.Value.FlightNumber = calgaryDay == 1 ? 2 : 5;
                    }
                    ScheduledOrderListDay.AddRange(calgaryDayList);
                    calgaryDay++;
                }

                int vancouverDay = 1;
                for (int i = 0; i < VancouverOrders.Count; i += 20)
                {
                    var vancouverDayList = VancouverOrders.Skip(i).Take(20).ToList();
                    foreach (var item in vancouverDayList)
                    {
                        item.Value.Day = vancouverDay;
                        item.Value.Departure = "YUL";
                        item.Value.FlightNumber = vancouverDay == 1 ? 3 : 6;
                    }
                    ScheduledOrderListDay.AddRange(vancouverDayList);
                    vancouverDay++;
                }

                Console.WriteLine("Flight itineraries");
                Console.WriteLine("------------------");
                foreach (var item in ScheduledOrderListDay)
                {
                    Console.WriteLine("order:" + item.Key + "," + " flightNumber:" + item.Value.FlightNumber + "," + " departure:" + item.Value.Departure + "," + " arrival:" + item.Value.Destination + "," + " day:" + item.Value.Day);
                }

                Console.WriteLine("------------------");
                Console.WriteLine("Not Scheduled Orders");
                Console.WriteLine("------------------");
                foreach (var activeItem in activeOrdersList)
                {
                    if (!activeItem.Value.IsScheduled)
                    {
                        Console.WriteLine(activeItem.Key + "," + "FlightNumber: Not Scheduled");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
