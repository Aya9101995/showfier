using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Dashboard
{
    public class MapDriversModel
    {
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public string VehiclePlateNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string DriverImage { get; set; }
        public int CurrentStatus { get; set; }
        public bool HasTask { get; set; }
        public long CurrentTaskID { get; set; }
        public string CurrentTaskStatus { get; set; }
        public int Bikes { get; set; }
        public TimeSpan CurrentEstimation { get; set; }

    }
}