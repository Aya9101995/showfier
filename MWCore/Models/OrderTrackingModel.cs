using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Models
{
    public class OrderTrackingModel
    {
        public long OrderID { get; set; }
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public double DriverLatitude { get; set; }
        public double DriverLongitude { get; set; }
        public double OrderLatitude { get; set; }
        public double OrderLongitude { get; set; }
    }
}