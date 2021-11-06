using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Cars;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Cars
{
    public class CarsCOM
    {
        #region GetCars
        public List<CarsModel> GetCars(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car in db.MW_Cars
                        join car_loc in db.MW_Cars_Loc on car.ID equals car_loc.CarID
                        join car_model in db.MW_CarsModels on car.ModelID equals car_model.ID
                        join car_model_loc in db.MW_CarsModels_Loc on car_model.ID equals car_model_loc.CarModelID
                        join car_make in db.MW_CarsMakes on car_model.CarMakeID equals car_make.ID
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID

                        join vehicle_type in db.MW_VehicleTypes on car.VehicleTypeID equals vehicle_type.ID
                        join vehicle_type_loc in db.MW_VehicleTypes_Loc on vehicle_type.ID equals vehicle_type_loc.VehicleTypeID

                        join additional_services in db.MW_CarAdditionalServices on car.ID equals additional_services.CarID into services
                        from additional_services in services.DefaultIfEmpty()

                        where car_make_loc.LanguageID == languageID && !car_make.IsDeleted && car_model_loc.LanguageID == languageID
                        && !car_model.IsDeleted && !car.IsDeleted && car_loc.languageID == languageID && vehicle_type_loc.LanguageID == languageID
                        && !vehicle_type.IsDeleted

                        select new CarsModel()
                        {
                            CarMakeID = car_make.ID,
                            Status = car.Status,
                            CarID = car.ID,
                            CarMakeName = car_make_loc.CarMakeName,
                            CarModelID = car_model.ID,
                            CarModelName = car_model_loc.CarModelName,
                            CarName = car_loc.Name,
                            CarTypeID = car.VehicleTypeID,
                            CarTypeName = vehicle_type_loc.VehicleName,
                            PlatNo = car.PlateNumber

                        }).ToList();

                //foreach (var item in lstCars)
                //{
                //    item.lstCarAdditionalServices = (from car_service in db.MW_CarAdditionalServices
                //                                     join service in db.MW_AdditionalServices on car_service.ServiceID equals service.ID
                //                                     join service_loc in db.MW_AdditionalServices_Loc on service.ID equals service_loc.ServiceID
                //                                     where car_service.CarID == item.CarID
                //                                     select new CarAdditionalServicesModel()
                //                                     {
                //                                         CarID = item.CarID,
                //                                         ServiceName = service_loc.Name,
                //                                         IsChecked = promocodesuser != null ? true : false,
                //                                         CarServiceID = car_service.ID,
                //                                         ServiceID = 
                //                                         PromoCodeID = item.PromoCodeID,
                //                                         PromoCodeUserID = promocodesuser != null ? promocodesuser.ID : 0,

                //                                     }).ToList();
                //}

            }
        }
        #endregion

        #region DeleteCar
        public List<CarsModel> DeleteCar(int CarID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Cars Car = db.MW_Cars.Where(x => x.ID == CarID).FirstOrDefault();
                if (Car != null)
                {
                    Car.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetCars(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<CarsModel> ChangeStatus(int CarID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Cars Car = db.MW_Cars.Where(x => x.ID == CarID).FirstOrDefault();
                if (Car != null)
                {
                    Car.Status = Car.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetCars(LanguageID);
            }
        }
        #endregion

        #region Method :: GetCarDetails
        public CarsModel GetCarDetails(int CarID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car in db.MW_Cars
                        join car_loc in db.MW_Cars_Loc on car.ID equals car_loc.CarID
                        join car_model in db.MW_CarsModels on car.ModelID equals car_model.ID
                        join car_model_loc in db.MW_CarsModels_Loc on car_model.ID equals car_model_loc.CarModelID
                        join car_make in db.MW_CarsMakes on car_model.CarMakeID equals car_make.ID
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID

                        join vehicle_type in db.MW_VehicleTypes on car.VehicleTypeID equals vehicle_type.ID
                        join vehicle_type_loc in db.MW_VehicleTypes_Loc on vehicle_type.ID equals vehicle_type_loc.VehicleTypeID

                        where car_make_loc.LanguageID == LanguageID && !car_make.IsDeleted && car_model_loc.LanguageID == LanguageID
                        && !car_model.IsDeleted && !car.IsDeleted && car_loc.languageID == LanguageID && vehicle_type_loc.LanguageID == LanguageID
                        && !vehicle_type.IsDeleted && car.ID == CarID
                        select new CarsModel()
                        {
                            CarMakeID = car_make.ID,
                            Status = car_make.Status,
                            CarID = car.ID,
                            CarMakeName = car_make_loc.CarMakeName,
                            CarModelID = car_model.ID,
                            CarModelName = car_model_loc.CarModelName,
                            CarName = car_loc.Name,
                            CarTypeID = car.VehicleTypeID,
                            CarTypeName = vehicle_type_loc.VehicleName,
                            PlatNo = car.PlateNumber
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveCar
        public List<CarsModel> SaveCar(CarsModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Cars oCar = new MW_Cars();
                MW_Cars_Loc oCar_Loc = new MW_Cars_Loc();
                if (oModel.CarID > 0)
                {
                    oCar_Loc = db.MW_Cars_Loc.Single(x => x.CarID == oModel.CarID && x.languageID == oModel.LanguageID);
                    oCar = db.MW_Cars.FirstOrDefault(x => x.ID == oCar_Loc.CarID);
                }

                oCar.IsDeleted = false;
                oCar.Status = oModel.Status;
                oCar_Loc.Name = oModel.CarName;
                oCar_Loc.languageID = oModel.LanguageID;
                oCar.PlateNumber = oModel.PlatNo;
                oCar.VehicleTypeID = oModel.CarTypeID;
                oCar.ModelID = oModel.CarModelID;

                if (oModel.CarID == 0)
                {
                    db.MW_Cars.Add(oCar);
                    db.SaveChanges();
                    oCar_Loc.CarID = oCar.ID;
                    db.MW_Cars_Loc.Add(oCar_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Cars_Loc oCarLoc = new MW_Cars_Loc();
                        oCarLoc.CarID = oCar.ID;
                        oCarLoc.Name = oModel.CarName;
                        oCarLoc.languageID = lstLanguages[nIndex].LanguageID;
                        db.MW_Cars_Loc.Add(oCarLoc);
                    }
                }

                foreach (var item in oModel.lstCarAdditionalServices.Where(x => x.IsChecked))
                {
                    MW_CarAdditionalServices oCarAdditionalService = new MW_CarAdditionalServices();
                    oCarAdditionalService.CarID = oCar.ID;
                    oCarAdditionalService.ServiceID = item.ServiceID;
                    db.MW_CarAdditionalServices.Add(oCarAdditionalService);
                }

                db.SaveChanges();
                return GetCars(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetCarsAPI
        public List<CarsModel> GetCarAPI(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car in db.MW_Cars
                        join car_loc in db.MW_Cars_Loc on car.ID equals car_loc.CarID
                        join car_model in db.MW_CarsModels on car.ModelID equals car_model.ID
                        join car_model_loc in db.MW_CarsModels_Loc on car_model.ID equals car_model_loc.CarModelID
                        join car_make in db.MW_CarsMakes on car_model.CarMakeID equals car_make.ID
                        join car_make_loc in db.MW_CarsMakes_Loc on car_make.ID equals car_make_loc.CarMakeID

                        join vehicle_type in db.MW_VehicleTypes on car.VehicleTypeID equals vehicle_type.ID
                        join vehicle_type_loc in db.MW_VehicleTypes_Loc on vehicle_type.ID equals vehicle_type_loc.VehicleTypeID

                        where car_make_loc.LanguageID == languageID && !car_make.IsDeleted && car_model_loc.LanguageID == languageID
                        && !car_model.IsDeleted && !car.IsDeleted && car_loc.languageID == languageID && vehicle_type_loc.LanguageID == languageID
                        && !vehicle_type.IsDeleted && car.Status == true && car_make.Status == true && car_model.Status == true && vehicle_type.Status == true
                        select new CarsModel()
                        {
                            CarMakeID = car_make.ID,
                            Status = car_make.Status,
                            CarID = car.ID,
                            CarMakeName = car_make_loc.CarMakeName,
                            CarModelID = car_model.ID,
                            CarModelName = car_model_loc.CarModelName,
                            CarName = car_loc.Name,
                            CarTypeID = car.VehicleTypeID,
                            CarTypeName = vehicle_type_loc.VehicleName,
                            PlatNo = car.PlateNumber

                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetCarsList
        public static List<SelectListItem> GetCarsList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from car in db.MW_Cars
                        join car_loc in db.MW_Cars_Loc on car.ID equals car_loc.CarID
                        where car_loc.languageID == LanguageID && !car.IsDeleted
                        select new SelectListItem()
                        {
                            Text = car_loc.Name,
                            Value = car_loc.CarID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}