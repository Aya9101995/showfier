namespace MWCore.Areas.MWCore.Models.Modules.Dashboard
{
    public class DashboardCOM
    {
        public DashboardModel LoadDashboard(DashboardModel oDashboardModel)
        {
            //using (MWCoreEntity db = new MWCoreEntity())
            //{
            //    DriversCOM oDrivers = new DriversCOM();
            //    //&& x.UpdatedDate >= DateTime.Now.AddMinutes(-5)
            //    DriversCurrentLocationsCOM oDriversCurrentLocationsCOM = new DriversCurrentLocationsCOM();
            //    List<DriversCurrentLocationsModel> lstDriversCurrentLocations = oDriversCurrentLocationsCOM.GetDriversCurrentLocations(oDashboardModel.CompanyID, oDashboardModel.ShopID, oDashboardModel.ShopBranchID).Where(x => x != null).ToList();
            //    List<DriverLocation> lstLocations = (from location in lstDriversCurrentLocations
            //                                         select new DriverLocation()
            //                                         {
            //                                             id = location.DriverID,
            //                                             name = location.DriverName,
            //                                             driverstatus = location.CurrentAvailabilityStatus == 1 && (DateTime.Now - location.UpdatedDate).TotalMinutes <= 2 ? 1 : location.CurrentAvailabilityStatus == 1 && (DateTime.Now - location.UpdatedDate).TotalMinutes > 2 ? 2 : 3,
            //                                             drivertype = location.IsMaintenanceDriver ? 2 : 1,
            //                                             locationname = "NONE",
            //                                             updateddate = location.UpdatedDate,
            //                                             position = new Position()
            //                                             { Lat = location.Latitude, Long = location.Longitude },
            //                                             TotalWorkingHourse = location.TotalWorkingHourse,
            //                                             FirstCheckInTime = location.FirstCheckInTime,
            //                                             LastCheckInTime = location.LastCheckInTime,
            //                                             LastCheckOutTime = location.LastCheckOutTime,
            //                                             EmployeeCode = location.EmployeeCode,
            //                                             IsMaintenanceDriver = location.IsMaintenanceDriver,
            //                                             PlateNumber = location.PlateNumber,
            //                                             PerformanceIndex = location.PerformanceIndex,
            //                                             TotalCompletedTasks = location.TotalNumberOfCompletedTasks
            //                                         }).ToList();
            //    oDashboardModel.oCoordinates = new Coordinates();
            //    oDashboardModel.oCoordinates.lstLocations = new List<DriverLocation>();
            //    if (oDashboardModel.IsAvailable)
            //    {
            //        if (oDashboardModel.IsDriver)
            //        {
            //            oDashboardModel.oCoordinates.lstLocations.AddRange(lstLocations.Where(x => x.driverstatus == 1 && x.drivertype == 2).ToList());
            //        }
            //        if (oDashboardModel.IsRider)
            //        {
            //            oDashboardModel.oCoordinates.lstLocations.AddRange(lstLocations.Where(x => x.driverstatus == 1 && x.drivertype == 1).ToList());
            //        }

            //    }
            //    if (oDashboardModel.IsAway)
            //    {
            //        if (oDashboardModel.IsDriver)
            //        {
            //            oDashboardModel.oCoordinates.lstLocations.AddRange(lstLocations.Where(x => x.driverstatus == 2 && x.drivertype == 2).ToList());
            //        }
            //        if (oDashboardModel.IsRider)
            //        {
            //            oDashboardModel.oCoordinates.lstLocations.AddRange(lstLocations.Where(x => x.driverstatus == 2 && x.drivertype == 1).ToList());
            //        }

            //    }
            //    if (oDashboardModel.IsOffline)
            //    {
            //        if (oDashboardModel.IsDriver)
            //        {
            //            oDashboardModel.oCoordinates.lstLocations.AddRange(lstLocations.Where(x => x.driverstatus == 3 && x.drivertype == 2).ToList());
            //        }
            //        if (oDashboardModel.IsRider)
            //        {
            //            oDashboardModel.oCoordinates.lstLocations.AddRange(lstLocations.Where(x => x.driverstatus == 3 && x.drivertype == 1).ToList());
            //        }

            //    }
            //    List<string> lstCoordinates = oDashboardModel.oCoordinates.lstLocations.Select(X => X.position.Lat + "," + X.position.Long).ToList();
            //    if (lstCoordinates != null)
            //    {
            //        List<double> lstLats = new List<double>();
            //        List<double> lstLongs = new List<double>();
            //        foreach (var item in lstCoordinates)
            //        {
            //            string[] sArrCoordinates = item.Split(',');
            //            lstLats.Add(double.Parse(sArrCoordinates[0]));
            //            lstLongs.Add(double.Parse(sArrCoordinates[1]));
            //        }
            //        if (lstLats != null && lstLats.Count > 0)
            //        {
            //            oDashboardModel.oCoordinates.MinLat = lstLats.Min();
            //            oDashboardModel.oCoordinates.MaxLat = lstLats.Max();
            //        }

            //        if (lstLongs != null && lstLongs.Count > 0)
            //        {
            //            oDashboardModel.oCoordinates.minLong = lstLongs.Min();
            //            oDashboardModel.oCoordinates.MaxLong = lstLongs.Max();
            //        }
            //    }
            //    else
            //    {
            //        oDashboardModel.oCoordinates = new Coordinates();
            //    }
            //    List<MaintenanceRequestsTasksModel> lstTasks = (from task in db.MW_MaintenanceRequestsTasks
            //                                                    join branch in db.MW_ShopsBranches on task.ShopBranchID equals branch.ID
            //                                                    join shop in db.MW_Shops on branch.ShopID equals shop.ID
            //                                                    join company in db.MW_Companies on shop.CompanyID equals company.ID
            //                                                    where task.RequestedDate == DateTime.Today
            //                                                    && (oDashboardModel.CompanyID != 0 ? company.ID == oDashboardModel.CompanyID : true)
            //                                                     && (oDashboardModel.CompanyID != 0 && oDashboardModel.ShopID != 0 ? shop.ID == oDashboardModel.ShopID : true)
            //                                                     && (oDashboardModel.CompanyID != 0 && oDashboardModel.ShopID != 0 && oDashboardModel.ShopBranchID != 0 ? branch.ID == oDashboardModel.ShopBranchID : true)
            //                                                    select new MaintenanceRequestsTasksModel()
            //                                                    {
            //                                                        MaintenanceRequestTaskID = task.ID,
            //                                                        ServiceTypeID = task.ServiceTypeID,
            //                                                        Status = task.Status,
            //                                                        IsCanceled = task.IsCanceled,
            //                                                        CurrentTaskStatus = task.CurrentTaskStatus
            //                                                    }).ToList();
            //    List<OrdersModel> lstOrders = (from order in db.MW_Orders
            //                                   join branch in db.MW_ShopsBranches on order.ShopBranchID equals branch.ID
            //                                   join shop in db.MW_Shops on branch.ShopID equals shop.ID
            //                                   join company in db.MW_Companies on shop.CompanyID equals company.ID
            //                                   where order.CreatedDate == DateTime.Today
            //                                   && (oDashboardModel.CompanyID != 0 ? company.ID == oDashboardModel.CompanyID : true)
            //                                    && (oDashboardModel.CompanyID != 0 && oDashboardModel.ShopID != 0 ? shop.ID == oDashboardModel.ShopID : true)
            //                                    && (oDashboardModel.CompanyID != 0 && oDashboardModel.ShopID != 0 && oDashboardModel.ShopBranchID != 0 ? branch.ID == oDashboardModel.ShopBranchID : true)
            //                                   select new OrdersModel()
            //                                   {
            //                                       OrderID = order.ID,
            //                                       OrderStatus = order.OrderStatus,
            //                                   }).ToList();
            //    oDashboardModel.SignedDriversCount = lstLocations.Where(x => x.driverstatus == 1 && x.drivertype == 2).Count() + lstLocations.Where(x => x.driverstatus == 2 && x.drivertype == 2).Count();
            //    oDashboardModel.SignedOffDriversCount = lstLocations.Where(x => x.driverstatus == 3 && x.drivertype == 2).Count();
            //    oDashboardModel.SignedRidersCount = lstLocations.Where(x => x.driverstatus == 1 && x.drivertype == 1).Count() + lstLocations.Where(x => x.driverstatus == 2 && x.drivertype == 1).Count();
            //    oDashboardModel.SignedOffRidersCount = lstLocations.Where(x => x.driverstatus == 3 && x.drivertype == 1).Count();
            //    oDashboardModel.TasksCount = lstTasks.Count();
            //    oDashboardModel.StandardTasksCount = lstTasks.Where(x => x.ServiceTypeID == (int)enumTaskServicesTypes.Standard).Count();
            //    oDashboardModel.UrgentTasksCount = lstTasks.Where(x => (x.ServiceTypeID == (int)enumTaskServicesTypes.Urgent)).Count();
            //    oDashboardModel.CompletedTasksCount = lstTasks.Where(x => x.Status == false && x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Finished && !x.IsCanceled).Count();
            //    oDashboardModel.CompletedStandardsTasksCount = lstTasks.Where(x => x.Status == false && x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Finished && !x.IsCanceled && x.ServiceTypeID == (int)enumTaskServicesTypes.Standard).Count();
            //    oDashboardModel.CompletedUrgentTasksCount = lstTasks.Where(x => x.Status == false && x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Finished && !x.IsCanceled && (x.ServiceTypeID == (int)enumTaskServicesTypes.Urgent)).Count();
            //    oDashboardModel.CanceledTasksCount = lstTasks.Where(x => x.Status == false && x.IsCanceled).Count();
            //    oDashboardModel.CanceledStandardsTasksCount = lstTasks.Where(x => x.Status == false && x.IsCanceled && x.ServiceTypeID == (int)enumTaskServicesTypes.Standard).Count();
            //    oDashboardModel.CanceledUrgentTasksCount = lstTasks.Where(x => x.Status == false && x.IsCanceled && (x.ServiceTypeID == (int)enumTaskServicesTypes.Urgent)).Count();
            //    oDashboardModel.InProgressTasksCount = lstTasks.Where(x => x.Status == true && (x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Pending || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.InProgress || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.On_The_Way || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Arrived || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Started)).Count();
            //    oDashboardModel.InProgressStandardsTasksCount = lstTasks.Where(x => x.Status == true && (x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Pending || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.InProgress || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.On_The_Way || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Arrived || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Started) && x.ServiceTypeID == (int)enumTaskServicesTypes.Standard).Count();
            //    oDashboardModel.InProgressUrgentTasksCount = lstTasks.Where(x => x.Status == true && (x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Pending || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.InProgress || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.On_The_Way || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Arrived || x.CurrentTaskStatus == (int)enumCurrentTaskStatus.Started) && (x.ServiceTypeID == (int)enumTaskServicesTypes.Urgent)).Count();
            //    oDashboardModel.OrdersCount = lstOrders.Count();
            //    oDashboardModel.InProgressOrdersCount = lstOrders.Where(x => x.OrderStatus != (int)enumOrderStatus.Delivered && x.OrderStatus != (int)enumOrderStatus.Canceled).Count();
            //    oDashboardModel.CanceledOrdersCount = lstOrders.Where(x => x.OrderStatus == (int)enumOrderStatus.Canceled).Count();
            //    oDashboardModel.CompletedOrdersCount = lstOrders.Where(x => x.OrderStatus == (int)enumOrderStatus.Delivered).Count();
            //    oDashboardModel.TotalWorkingHourseForRiders = Math.Round(lstLocations.Where(x => x.drivertype == 1).Sum(x => x.TotalWorkingHourse), 2);
            //    oDashboardModel.TotalWorkingHoursForDrivers = Math.Round(lstLocations.Where(x => x.drivertype == 2).Sum(x => x.TotalWorkingHourse), 2);
            //    oDashboardModel.TotalPerformanceIndexForRiders = oDashboardModel.CompletedOrdersCount > 0 && oDashboardModel.TotalWorkingHourseForRiders > 0 ? Math.Round(Convert.ToDouble(oDashboardModel.CompletedOrdersCount / oDashboardModel.TotalWorkingHourseForRiders), 2) : 0;
            //    oDashboardModel.TotalPerformanceIndexForDrivers = oDashboardModel.CompletedTasksCount > 0 && oDashboardModel.TotalWorkingHoursForDrivers > 0 ? Math.Round(Convert.ToDouble(oDashboardModel.CompletedTasksCount / oDashboardModel.TotalWorkingHoursForDrivers), 2) : 0;
            //    return oDashboardModel;
            //}
            return new DashboardModel();
        }

        
    }
}