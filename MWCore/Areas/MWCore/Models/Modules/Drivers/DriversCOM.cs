using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Drivers;
using MWCore.Areas.MWCore.Models.Modules.Account;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Drivers
{
    public class DriversCOM
    {
        #region GetDrivers
        public List<DriversModel> GetDrivers(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from driver in db.MW_Drivers

                        join Car in db.MW_Cars on driver.DefaultCarID equals Car.ID
                        join Car_loc in db.MW_Cars_Loc on Car.ID equals Car_loc.CarID
                        where Car_loc.languageID == languageID && !driver.IsDeleted
                        select new DriversModel()
                        {
                            IsAvailable = driver.IsAvailable,
                            CanAcceptRejectTrips = driver.CanAcceptRejectTrips,
                            CivilID = driver.CivilID,
                            DateOfBirth = driver.DateOfBirth,
                            DefaultCarID = driver.DefaultCarID,
                            DriverID = driver.ID,
                            EmployeeID = driver.EmployeeID,
                            FullName = driver.FullName,
                            Gender = driver.Gender,
                            PhoneCode = driver.PhoneCode,
                            PhoneNumber = driver.PhoneNumber,
                            Picture = driver.Picture,
                            TodaysCarID = driver.TodaysCarID,
                            LanguageID = languageID

                        }).ToList();
            }
        }
        #endregion

        #region DeleteDriver
        public List<DriversModel> DeleteDriver(int DriverID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Drivers driver = db.MW_Drivers.Where(x => x.ID == DriverID).FirstOrDefault();
                if (driver != null)
                {
                    driver.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetDrivers(LanguageID);
            }
        }
        #endregion


        #region Method :: GetDriverDetails
        public DriversModel GetDriverDetails(int DriverID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from driver in db.MW_Drivers

                        join Car in db.MW_Cars on driver.DefaultCarID equals Car.ID
                        join Car_loc in db.MW_Cars_Loc on Car.ID equals Car_loc.CarID
                        where Car_loc.languageID == LanguageID && !driver.IsDeleted && driver.ID == DriverID
                        select new DriversModel()
                        {

                            IsAvailable = driver.IsAvailable,
                            CanAcceptRejectTrips = driver.CanAcceptRejectTrips,
                            CivilID = driver.CivilID,
                            DateOfBirth = driver.DateOfBirth,
                            DefaultCarID = driver.DefaultCarID,
                            DriverID = driver.ID,                    
                            EmployeeID = driver.EmployeeID,
                            FullName = driver.FullName,
                            Gender = driver.Gender,
                            PhoneCode = driver.PhoneCode,
                            PhoneNumber = driver.PhoneNumber,
                            Picture = driver.Picture,
                            TodaysCarID = driver.TodaysCarID

                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveDriver
        public List<DriversModel> SaveDriver(DriversModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Drivers oDriver = new MW_Drivers();

                if (oModel.DriverID > 0)
                {
                    oDriver = db.MW_Drivers.FirstOrDefault(x => x.ID == oModel.DriverID);
                }
                oDriver.IsDeleted = false;
                oDriver.IsAvailable = oModel.IsAvailable;
                oDriver.TodaysCarID = oModel.TodaysCarID;
                oDriver.Picture = oModel.Picture;
                oDriver.PhoneCode = oModel.PhoneCode;
                oDriver.PhoneNumber = oModel.PhoneNumber;
                oDriver.Gender = oModel.Gender;
                oDriver.EmployeeID = oModel.EmployeeID;
                oDriver.CanAcceptRejectTrips = oModel.CanAcceptRejectTrips;
                oDriver.DateOfBirth = oModel.DateOfBirth;
                oDriver.CivilID = oModel.CivilID;
                oDriver.FullName = oModel.FullName;
                oDriver.DefaultCarID = oModel.DefaultCarID;
                oDriver.DefaultLanguageID = oModel.LanguageID;
                if (oModel.DriverID == 0)
                {
                    AccountCOM oAccount = new AccountCOM();
                    string sPassword = oAccount.GetMd5Hash(oModel.Password != null ? oModel.Password : "123456");
                    oDriver.Password = sPassword;
                    db.MW_Drivers.Add(oDriver);
                    db.SaveChanges();
                }
                db.SaveChanges();
                return GetDrivers(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetDriversAPI
        public List<DriversModel> GetDriversAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from driver in db.MW_Drivers

                        join Car in db.MW_Cars on driver.DefaultCarID equals Car.ID
                        join Car_loc in db.MW_Cars_Loc on Car.ID equals Car_loc.CarID
                        where Car_loc.languageID == LanguageID && !driver.IsDeleted && driver.IsAvailable == true
                        select new DriversModel()
                        {
                            IsAvailable = driver.IsAvailable,
                            CanAcceptRejectTrips = driver.CanAcceptRejectTrips,
                            CivilID = driver.CivilID,
                            DateOfBirth = driver.DateOfBirth,
                            DefaultCarID = driver.DefaultCarID,
                            DriverID = driver.ID,                        
                            EmployeeID = driver.EmployeeID,
                            FullName = driver.FullName,
                            Gender = driver.Gender,
                            PhoneCode = driver.PhoneCode,
                            PhoneNumber = driver.PhoneNumber,
                            Picture = driver.Picture,
                            TodaysCarID = driver.TodaysCarID,
                            LanguageID = LanguageID
                        }).ToList();
            }
        }
        #endregion
        public bool CheckPhoneNumber(DriversModel oDriver)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if (oDriver.DriverID == 0)
                {
                    return !db.MW_Drivers.Any(x => x.PhoneCode == oDriver.PhoneCode && x.PhoneNumber == oDriver.PhoneNumber);
                }
                else
                {
                    return !db.MW_Drivers.Any(x => x.PhoneCode == oDriver.PhoneCode && x.PhoneNumber == oDriver.PhoneNumber && x.ID != oDriver.DriverID);
                }
            }
        }


    }
}