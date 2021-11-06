using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Dashboard
{
    public class DashboardModel
    {
        //public int CountryID { get; set; }
        //public int CityID { get; set; }
        //public int AreaID { get; set; }
        public int CompanyID { get; set; }
        public int ShopID { get; set; }
        public int ShopBranchID { get; set; }
        public int SignedDriversCount { get; set; }
        public int SignedOffDriversCount { get; set; }
        public int SignedRidersCount { get; set; }
        public int SignedOffRidersCount { get; set; }
        public int TasksCount { get; set; }
        public int StandardTasksCount { get; set; }
        public int UrgentTasksCount { get; set; }
        public int InProgressTasksCount { get; set; }
        public int InProgressStandardsTasksCount { get; set; }
        public int InProgressUrgentTasksCount { get; set; }
        public int CanceledTasksCount { get; set; }
        public int CanceledStandardsTasksCount { get; set; }
        public int CanceledUrgentTasksCount { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedStandardsTasksCount { get; set; }
        public int CompletedUrgentTasksCount { get; set; }
        public int OrdersCount { get; set; }
        public int InProgressOrdersCount { get; set; }
        public int CanceledOrdersCount { get; set; }
        public int CompletedOrdersCount { get; set; }
        public bool IsRider { get; set; }
        public bool IsDriver { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsAway { get; set; }
        public bool IsOffline { get; set; }
        public double TotalWorkingHourseForRiders { get; set; }
        public double TotalWorkingHoursForDrivers { get; set; }
        public double TotalPerformanceIndexForRiders { get; set; }
        public double TotalPerformanceIndexForDrivers { get; set; }
        public Coordinates oCoordinates { get; set; }
    }
    public class DriversDetails
    {
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public string CurrentStatus { get; set; }
        public string CheckInTime { get; set; }
        public bool IsMaintenanceDriver { get; set; }
        public string EmployeeCode { get; set; }
        public string PlateNumber { get; set; }
        public double TotalWorkingHourse { get; set; }
        public int TotalNumberOfCompletedTasks { get; set; }
        public double PerformanceIndex { get; set; }
    }
    public class Coordinates
    {
        public Coordinates()
        {
            lstLocations = new List<DriverLocation>();
        }
        public double MinLat { get; set; }
        public double MaxLat { get; set; }
        public double minLong { get; set; }
        public double MaxLong { get; set; }
        public List<DriverLocation> lstLocations { get; set; }
    }

    public class DriverLocation
    {
        public DriverLocation()
        {
            position = new Position();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string locationname { get; set; }
        /// <summary>
        /// 1 => Bike Rider
        /// 2 => Car Driver
        /// </summary>
        public int drivertype { get; set; }
        /// <summary>
        /// 1 => Available
        /// 2 => Away
        /// 3 => Offline
        /// </summary>
        public int driverstatus { get; set; }
        public DateTime updateddate { get; set; }
        public Position position { get; set; }
        public double TotalWorkingHourse { get; set; }
        public int TotalCompletedTasks { get; set; }
        public double PerformanceIndex { get; set; }
        public string FirstCheckInTime { get; set; }
        public string LastCheckInTime { get; set; }
        public string LastCheckOutTime { get; set; }
        public bool IsMaintenanceDriver { get; set; }
        public string EmployeeCode { get; set; }
        public string PlateNumber { get; set; }
    }
    public class Position
    {
        public double Lat { get; set; }
        public double Long
        {
            get; set;
        }
    }
}