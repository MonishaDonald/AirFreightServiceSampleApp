using System.Collections.Generic;

namespace AirFreightServiceSampleApp
{
    internal interface IOrder
    {
        Dictionary<string, Order> ScheduleOrder(Dictionary<string, Order> activeOrdersList);
        void GetOrderDetails();
    }
}
