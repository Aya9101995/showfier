using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Cars;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.CarsMakes
{
    public class CarsMakesCOM
    {
        #region GetCarMakes
        public List<CarsMakesModel> GetCarMakes(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_make in db.MW_CarsMakes
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID
                        where car_make_loc.LanguageID == languageID && !car_make.IsDeleted
                        select new CarsMakesModel()
                        {
                            CarMakeID = car_make.ID,
                            Status = car_make.Status,
                            Logo = car_make.Logo,
                            Name = car_make_loc.CarMakeName
                        }).ToList();
            }
        }
        #endregion

        #region DeleteCarMake
        public List<CarsMakesModel> DeleteCarMake(int CarMakeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CarsMakes CarMake = db.MW_CarsMakes.Where(x => x.ID == CarMakeID).FirstOrDefault();
                if (CarMake != null)
                {
                    CarMake.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetCarMakes(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<CarsMakesModel> ChangeStatus(int CarMakeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CarsMakes CarMake = db.MW_CarsMakes.Where(x => x.ID == CarMakeID).FirstOrDefault();
                if (CarMake != null)
                {
                    CarMake.Status = CarMake.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetCarMakes(LanguageID);
            }
        }
        #endregion

        #region Method :: GetCarMakeDetails
        public CarsMakesModel GetCarMakeDetails(int CarMakeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_make in db.MW_CarsMakes
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID
                        where car_make_loc.LanguageID == LanguageID && !car_make.IsDeleted && car_make.ID == CarMakeID
                        select new CarsMakesModel()
                        {
                            CarMakeID = car_make.ID,
                            Status = car_make.Status,
                            Logo = car_make.Logo,
                            Name = car_make_loc.CarMakeName,
                            LanguageID = LanguageID
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveCarMake
        public List<CarsMakesModel> SaveCarMake(CarsMakesModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CarsMakes oCarMake = new MW_CarsMakes();
                MW_CarsMakes_Loc oCarMake_Loc = new MW_CarsMakes_Loc();
                if (oModel.CarMakeID > 0)
                {
                    oCarMake_Loc = db.MW_CarsMakes_Loc.Single(x => x.CarMakeID == oModel.CarMakeID && x.LanguageID == oModel.LanguageID);
                    oCarMake = db.MW_CarsMakes.FirstOrDefault(x => x.ID == oCarMake_Loc.CarMakeID);
                }

                oCarMake.IsDeleted = false;
                oCarMake.Status = oModel.Status;
                oCarMake.Logo = oModel.Logo;
                oCarMake_Loc.CarMakeName = oModel.Name;
                oCarMake_Loc.LanguageID = oModel.LanguageID;
                if (oModel.CarMakeID == 0)
                {
                    db.MW_CarsMakes.Add(oCarMake);
                    db.SaveChanges();
                    oCarMake_Loc.CarMakeID = oCarMake.ID;
                    db.MW_CarsMakes_Loc.Add(oCarMake_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_CarsMakes_Loc oCarMakeLoc = new MW_CarsMakes_Loc();
                        oCarMakeLoc.CarMakeID = oCarMake.ID;
                        oCarMakeLoc.CarMakeName = oModel.Name;
                        oCarMakeLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_CarsMakes_Loc.Add(oCarMakeLoc);
                    }
                }
                db.SaveChanges();
                return GetCarMakes(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetCarMakesAPI
        public List<CarsMakesModel> GetCarMakesAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car_make in db.MW_CarsMakes
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID
                        where car_make_loc.LanguageID == LanguageID && !car_make.IsDeleted && car_make.Status == true
                        select new CarsMakesModel()
                        {
                            CarMakeID = car_make.ID,
                            Status = car_make.Status,
                            Logo = car_make.Logo,
                            Name = car_make_loc.CarMakeName
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetCarMakesList
        public static List<SelectListItem> GetCarMakesList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from CarMake in db.MW_CarsMakes
                        join carMake_Loc in db.MW_CarsMakes_Loc on CarMake.ID equals carMake_Loc.CarMakeID
                        where carMake_Loc.LanguageID == LanguageID && !CarMake.IsDeleted
                        select new SelectListItem()
                        {
                            Text = carMake_Loc.CarMakeName,
                            Value = carMake_Loc.CarMakeID.ToString()
                        }).ToList();
            }
        }
        #endregion


    }
}