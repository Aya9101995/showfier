using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Cars;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.CarsModels
{
    public class CarsModelsCOM
    {
        #region GetCarModels
        public List<CarsModelsModel> GetCarModels(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_model in db.MW_CarsModels
                        join car_model_loc in db.MW_CarsModels_Loc on car_model.ID equals car_model_loc.CarModelID

                        join car_make in db.MW_CarsMakes on car_model.CarMakeID equals car_make.ID
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID

                        where car_model_loc.LanguageID == languageID && !car_model.IsDeleted && car_make_loc.LanguageID == languageID && !car_make.IsDeleted
                        select new CarsModelsModel()
                        {
                            CarMakeID = car_model.CarMakeID,
                            Status = car_model.Status,
                            CarModelID = car_model.ID,
                            MakeName = car_make_loc.CarMakeName,
                            ModelName = car_model_loc.CarModelName,
                            LanguageID = languageID
                        }).ToList();
            }
        }
        #endregion

        #region DeleteCarModel
        public List<CarsModelsModel> DeleteCarModel(int CarModelID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CarsModels CarModel = db.MW_CarsModels.Where(x => x.ID == CarModelID).FirstOrDefault();
                if (CarModel != null)
                {
                    CarModel.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetCarModels(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<CarsModelsModel> ChangeStatus(int CarModelID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CarsModels CarModel = db.MW_CarsModels.Where(x => x.ID == CarModelID).FirstOrDefault();
                if (CarModel != null)
                {
                    CarModel.Status = CarModel.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetCarModels(LanguageID);
            }
        }
        #endregion

        #region Method :: GetCarModelDetails
        public CarsModelsModel GetCarModelDetails(int CarModelID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_model in db.MW_CarsModels
                        join car_model_loc in db.MW_CarsModels_Loc on car_model.ID equals car_model_loc.CarModelID
                        join car_make in db.MW_CarsMakes on car_model.CarMakeID equals car_make.ID
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID
                        where car_model_loc.LanguageID == LanguageID && !car_model.IsDeleted && car_model.ID == CarModelID
                        select new CarsModelsModel()
                        {
                            CarMakeID = car_model.CarMakeID,
                            Status = car_model.Status,
                            CarModelID = car_model.ID,
                            MakeName = car_make_loc.CarMakeName,
                            ModelName = car_model_loc.CarModelName,
                            LanguageID = LanguageID
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveCarModel
        public List<CarsModelsModel> SaveCarModel(CarsModelsModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CarsModels oCarModel = new MW_CarsModels();
                MW_CarsModels_Loc oCarModel_Loc = new MW_CarsModels_Loc();
                if (oModel.CarModelID > 0)
                {
                    oCarModel_Loc = db.MW_CarsModels_Loc.Single(x => x.CarModelID == oModel.CarModelID && x.LanguageID == oModel.LanguageID);
                    oCarModel = db.MW_CarsModels.FirstOrDefault(x => x.ID == oCarModel_Loc.CarModelID);
                }

                oCarModel.IsDeleted = false;
                oCarModel.Status = oModel.Status;
       
                oCarModel.CarMakeID = oModel.CarMakeID;
                oCarModel_Loc.CarModelName = oModel.ModelName;
                oCarModel_Loc.LanguageID = oModel.LanguageID;
                if (oModel.CarModelID == 0)
                {
                    db.MW_CarsModels.Add(oCarModel);
                    db.SaveChanges();
                    oCarModel_Loc.CarModelID = oCarModel.ID;
                    db.MW_CarsModels_Loc.Add(oCarModel_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_CarsModels_Loc oCarModelLoc = new MW_CarsModels_Loc();
                        oCarModelLoc.CarModelID = oCarModel.ID;
                        oCarModelLoc.CarModelName = oModel.ModelName;
                        oCarModelLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_CarsModels_Loc.Add(oCarModelLoc);
                    }
                }

                db.SaveChanges();
                return GetCarModels(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetCarModelsAPI
        public List<CarsModelsModel> GetCarModelsAPI(int LanguageID,int CarMake)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_model in db.MW_CarsModels
                        join car_model_loc in db.MW_CarsModels_Loc on car_model.ID equals car_model_loc.CarModelID
                        join car_make in db.MW_CarsMakes on car_model.CarMakeID equals car_make.ID
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID
                        where car_model_loc.LanguageID == LanguageID && !car_model.IsDeleted && car_model.Status == true && car_model.CarMakeID == CarMake
                        select new CarsModelsModel()
                        {
                            CarMakeID = car_model.CarMakeID,
                            Status = car_model.Status,
                            CarModelID = car_model.ID,
                            MakeName = car_make_loc.CarMakeName,
                            ModelName = car_model_loc.CarModelName
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetCarModelsList
        public static List<SelectListItem> GetCarModelsList(int LanguageID, int CarMakeID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_model in db.MW_CarsModels
                        join carModel_Loc in db.MW_CarsModels_Loc on car_model.ID equals carModel_Loc.CarModelID
                        where carModel_Loc.LanguageID == LanguageID && !car_model.IsDeleted && car_model.CarMakeID == CarMakeID
                        select new SelectListItem()
                        {
                            Text = carModel_Loc.CarModelName,
                            Value = carModel_Loc.ID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}