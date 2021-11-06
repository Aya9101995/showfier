using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.AdditionalServices;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.AdditionalServices
{
    public class AdditionalServicesCOM
    {
        #region GetAdditionalServices
        public List<AdditionalServicesModel> GetAdditionalServices(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from service in db.MW_AdditionalServices
                        join service_loc in db.MW_AdditionalServices_Loc on service.ID equals service_loc.ServiceID
                        where service_loc.LanguageID == languageID && !service.IsDeleted
                        select new AdditionalServicesModel()
                        {
                            AdditionalServiceDescription = service_loc.Description,
                            AdditionalServiceID = service.ID,
                            AdditionalServiceImage = service.Image,
                            AdditionalServiceName = service_loc.Name,
                            AdditionalServicePrice = service.Price,
                            AdditionalServiceStock = (int)service.Stock,
                            Status = service.Status,
                            LanguageID = languageID
                        }).ToList();
            }
        }
        #endregion

        #region DeleteAdditionalService
        public List<AdditionalServicesModel> DeleteAdditionalService(int ServiceID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_AdditionalServices service = db.MW_AdditionalServices.Where(x => x.ID == ServiceID).FirstOrDefault();
                if (service != null)
                {
                    service.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetAdditionalServices(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<AdditionalServicesModel> ChangeStatus(int ServiceID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_AdditionalServices service = db.MW_AdditionalServices.Where(x => x.ID == ServiceID).FirstOrDefault();
                if (service != null)
                {

                    service.Status = service.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetAdditionalServices(LanguageID);
            }
        }
        #endregion

        #region Method :: GetAdditionalServiceDetails
        public AdditionalServicesModel GetAdditionalServiceDetails(int CarServiceID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from service in db.MW_AdditionalServices
                        join service_loc in db.MW_AdditionalServices_Loc on service.ID equals service_loc.ServiceID
                        where service_loc.LanguageID == LanguageID && !service.IsDeleted && service.ID == CarServiceID
                        select new AdditionalServicesModel()
                        {
                            AdditionalServiceDescription = service_loc.Description,
                            AdditionalServiceID = service.ID,
                            AdditionalServiceImage = service.Image,
                            AdditionalServiceName = service_loc.Name,
                            AdditionalServicePrice = service.Price,
                            AdditionalServiceStock = (int)service.Stock,
                            Status = service.Status,
                            LanguageID = LanguageID
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveAdditionalService
        public List<AdditionalServicesModel> SaveAdditionalService(AdditionalServicesModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_AdditionalServices oService = new MW_AdditionalServices();
                MW_AdditionalServices_Loc oService_Loc = new MW_AdditionalServices_Loc();
                if (oModel.AdditionalServiceID > 0)
                {
                    oService_Loc = db.MW_AdditionalServices_Loc.Single(x => x.ServiceID == oModel.AdditionalServiceID && x.LanguageID == oModel.LanguageID);
                    oService = db.MW_AdditionalServices.FirstOrDefault(x => x.ID == oService_Loc.ServiceID);
                }

                oService.IsDeleted = false;
                oService.Status = oModel.Status;
                oService.Image = oModel.AdditionalServiceImage;
                oService_Loc.Name = oModel.AdditionalServiceName;
                oService_Loc.Description = oModel.AdditionalServiceDescription;
                oService_Loc.LanguageID = oModel.LanguageID;
                if (oModel.AdditionalServiceID == 0)
                {
                    db.MW_AdditionalServices.Add(oService);
                    db.SaveChanges();
                    oService_Loc.ServiceID = oService.ID;
                    db.MW_AdditionalServices_Loc.Add(oService_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_AdditionalServices_Loc oAdditionalServiceLoc = new MW_AdditionalServices_Loc();
                        oAdditionalServiceLoc.ServiceID = oService.ID;
                        oAdditionalServiceLoc.Name = oModel.AdditionalServiceName;
                        oAdditionalServiceLoc.Description = oModel.AdditionalServiceDescription;
                        oAdditionalServiceLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_AdditionalServices_Loc.Add(oAdditionalServiceLoc);
                    }
                }
                db.SaveChanges();
                return GetAdditionalServices(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetAdditionalServicesList
        public static List<SelectListItem> GetAdditionalServicesList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from service in db.MW_AdditionalServices
                        join service_loc in db.MW_AdditionalServices_Loc on service.ID equals service_loc.ServiceID
                        where service_loc.LanguageID == LanguageID && !service.IsDeleted
                        select new SelectListItem()
                        {
                            Text = service_loc.Name,
                            Value = service_loc.ServiceID.ToString()
                        }).ToList();
            }
        }
        #endregion


    }
}