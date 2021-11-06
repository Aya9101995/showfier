using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Models
{
    public class CustomersDevicesModel
    {
        public int CustomerDeviceID { get; set; }
        public int CustomerID { get; set; }
        public string ApiToken { get; set; }
        public string DeviceID { get; set; }
        public string DeviceToken { get; set; }
        /// <summary>
        /// 0 => Android
        /// 1 => IOS
        /// </summary>
        public int DevicePlatform { get; set; }
    }
}