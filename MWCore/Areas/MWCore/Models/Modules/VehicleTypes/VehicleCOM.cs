using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Cars;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Vehicles
{
    public class VehicleCOM
    {
        #region GetVehicleTypes
        public List<VehiclesModel> GetVehicleTypes(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from vehicle in db.MW_VehicleTypes
                        join vehicle_loc in db.MW_VehicleTypes_Loc on vehicle.ID equals vehicle_loc.VehicleTypeID

                        join tax in db.MW_Taxes on vehicle.TaxID equals tax.ID
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID

                        where tax_loc.LanguageID == languageID && !vehicle.IsDeleted && vehicle_loc.LanguageID == languageID && !tax.IsDeleted
                        select new VehiclesModel()
                        {
                            VehicleID = vehicle.ID,
                            Status = vehicle.Status,
                            TaxID = vehicle.TaxID,
                            BaseFare = vehicle.BaseFare,
                            CostPerDelayedMinute = vehicle.CostPerDelayedMinute,
                            CostPerKM = vehicle.CostPerKM,
                            CostPerMinute = vehicle.CostPerMinute,
                            MinimumFare = vehicle.MinimumFare,
                            VehicleName = vehicle_loc.VehicleName,
                            TaxName = tax_loc.TaxName,
                            TaxValue = tax.TaxValue,
                            Logo = vehicle.Logo,
                            LanguageID = languageID
                        }).ToList();
            }
        }
        #endregion

        #region DeleteVehicleType
        public List<VehiclesModel> DeleteVehicleType(int VehicleTypeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_VehicleTypes VehicleType = db.MW_VehicleTypes.Where(x => x.ID == VehicleTypeID).FirstOrDefault();
                if (VehicleType != null)
                {
                    VehicleType.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetVehicleTypes(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<VehiclesModel> ChangeStatus(int VehicleTypeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_VehicleTypes VehicleType = db.MW_VehicleTypes.Where(x => x.ID == VehicleTypeID).FirstOrDefault();
                if (VehicleType != null)
                {
                    VehicleType.Status = VehicleType.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetVehicleTypes(LanguageID);
            }
        }
        #endregion

        #region Method :: GetVehicleDetails
        public VehiclesModel GetVehicleDetails(int VehicleTypeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from vehicle in db.MW_VehicleTypes
                        join vehicle_loc in db.MW_VehicleTypes_Loc on vehicle.ID equals vehicle_loc.VehicleTypeID

                        join tax in db.MW_Taxes on vehicle.TaxID equals tax.ID
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID

                        where tax_loc.LanguageID == LanguageID && !vehicle.IsDeleted && vehicle_loc.LanguageID == LanguageID && !tax.IsDeleted
                        && vehicle.ID == VehicleTypeID
                        select new VehiclesModel()
                        {
                            VehicleID = vehicle.ID,
                            Status = vehicle.Status,
                            TaxID = vehicle.TaxID,
                            BaseFare = vehicle.BaseFare,
                            CostPerDelayedMinute = vehicle.CostPerDelayedMinute,
                            CostPerKM = vehicle.CostPerKM,
                            CostPerMinute = vehicle.CostPerMinute,
                            MinimumFare = vehicle.MinimumFare,
                            VehicleName = vehicle_loc.VehicleName,
                            TaxName = tax_loc.TaxName,
                            TaxValue = tax.TaxValue,
                            Logo = vehicle.Logo,
                            LanguageID = LanguageID
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveVehicleType
        public List<VehiclesModel> SaveVehicleType(VehiclesModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_VehicleTypes oVehicleType = new MW_VehicleTypes();
                MW_VehicleTypes_Loc oVehicleType_Loc = new MW_VehicleTypes_Loc();
                if (oModel.VehicleID > 0)
                {
                    oVehicleType_Loc = db.MW_VehicleTypes_Loc.Single(x => x.VehicleTypeID == oModel.VehicleID && x.LanguageID == oModel.LanguageID);
                    oVehicleType = db.MW_VehicleTypes.FirstOrDefault(x => x.ID == oVehicleType_Loc.VehicleTypeID);
                }

                oVehicleType.IsDeleted = false;
                oVehicleType.Status = oModel.Status;
                oVehicleType.TaxID = oModel.TaxID;
                oVehicleType_Loc.VehicleName = oModel.VehicleName;
                oVehicleType_Loc.LanguageID = oModel.LanguageID;
                oVehicleType.MinimumFare = oModel.MinimumFare;
                oVehicleType.CostPerMinute = oModel.CostPerMinute;
                oVehicleType.CostPerKM = oModel.CostPerKM;
                oVehicleType.CostPerDelayedMinute = oModel.CostPerDelayedMinute;
                oVehicleType.BaseFare = oModel.BaseFare;
                oVehicleType.Logo = oModel.Logo;

                if (oModel.VehicleID == 0)
                {
                    db.MW_VehicleTypes.Add(oVehicleType);
                    db.SaveChanges();
                    oVehicleType_Loc.VehicleTypeID = oVehicleType.ID;
                    db.MW_VehicleTypes_Loc.Add(oVehicleType_Loc);
                    int nCount = lstLanguages.Count - 1;

                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_VehicleTypes_Loc oVehicleTypeLoc = new MW_VehicleTypes_Loc();
                        oVehicleTypeLoc.VehicleTypeID = oVehicleType.ID;
                        oVehicleTypeLoc.VehicleName = oModel.VehicleName;
                        oVehicleTypeLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_VehicleTypes_Loc.Add(oVehicleTypeLoc);
                    }
                }

                db.SaveChanges();
                return GetVehicleTypes(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetVehicleTypesAPI
        public List<VehiclesModel> GetVehicleTypesAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from vehicle in db.MW_VehicleTypes
                        join vehicle_loc in db.MW_VehicleTypes_Loc on vehicle.ID equals vehicle_loc.VehicleTypeID

                        join tax in db.MW_Taxes on vehicle.TaxID equals tax.ID
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID

                        where tax_loc.LanguageID == LanguageID && !vehicle.IsDeleted && vehicle_loc.LanguageID == LanguageID && !tax.IsDeleted
                        && vehicle.Status == true && tax.Status == true
                        select new VehiclesModel()
                        {
                            VehicleID = vehicle.ID,
                            Status = vehicle.Status,
                            TaxID = vehicle.TaxID,
                            BaseFare = vehicle.BaseFare,
                            CostPerDelayedMinute = vehicle.CostPerDelayedMinute,
                            CostPerKM = vehicle.CostPerKM,
                            CostPerMinute = vehicle.CostPerMinute,
                            MinimumFare = vehicle.MinimumFare,
                            VehicleName = vehicle_loc.VehicleName,
                            TaxName = tax_loc.TaxName,
                            TaxValue = tax.TaxValue,
                            Logo = vehicle.Logo,
                            LanguageID = LanguageID
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetVehicleTypesList
        public static List<SelectListItem> GetVehicleTypesList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from vehicle in db.MW_VehicleTypes
                        join vehicle_loc in db.MW_VehicleTypes_Loc on vehicle.ID equals vehicle_loc.VehicleTypeID
                        where vehicle_loc.LanguageID == LanguageID && !vehicle.IsDeleted
                        select new SelectListItem()
                        {
                            Text = vehicle_loc.VehicleName,
                            Value = vehicle_loc.VehicleTypeID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}